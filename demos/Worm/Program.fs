(****************************************************************************
 * Copyright (c) 2005 Free Software Foundation, Inc.                        *
 *                                                                          *
 * Permission is hereby granted, free of charge, to any person obtaining a  *
 * copy of this software and associated documentation files (the            *
 * "Software"), to deal in the Software without restriction, including      *
 * without limitation the rights to use, copy, modify, merge, publish,      *
 * distribute, distribute with modifications, sublicense, and/or sell       *
 * copies of the Software, and to permit persons to whom the Software is    *
 * furnished to do so, subject to the following conditions:                 *
 *                                                                          *
 * The above copyright notice and this permission notice shall be included  *
 * in all copies or substantial portions of the Software.                   *
 *                                                                          *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS  *
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF               *
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.   *
 * IN NO EVENT SHALL THE ABOVE COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,   *
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR    *
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR    *
 * THE USE OR OTHER DEALINGS IN THE SOFTWARE.                               *
 *                                                                          *
 * Except as contained in this notice, the name(s) of the above copyright   *
 * holders shall not be used in advertising or otherwise to promote the     *
 * sale, use or other dealings in this Software without prior written       *
 * authorization.                                                           *
 ****************************************************************************/

/*

         @@@        @@@    @@@@@@@@@@     @@@@@@@@@@@    @@@@@@@@@@@@
         @@@        @@@   @@@@@@@@@@@@    @@@@@@@@@@@@   @@@@@@@@@@@@@
         @@@        @@@  @@@@      @@@@   @@@@           @@@@ @@@  @@@@
         @@@   @@   @@@  @@@        @@@   @@@            @@@  @@@   @@@
         @@@  @@@@  @@@  @@@        @@@   @@@            @@@  @@@   @@@
         @@@@ @@@@ @@@@  @@@        @@@   @@@            @@@  @@@   @@@
          @@@@@@@@@@@@   @@@@      @@@@   @@@            @@@  @@@   @@@
           @@@@  @@@@     @@@@@@@@@@@@    @@@            @@@  @@@   @@@
            @@    @@       @@@@@@@@@@     @@@            @@@  @@@   @@@

                                 Eric P. Scott
                          Caltech High Energy Physics
                                 October, 1980

                           Color by Eric S. Raymond
                                  July, 1995

Options:
        -f                      fill screen with copies of 'WORM' at start.
        -l <n>                  set worm length
        -n <n>                  set number of worms
        -t                      make worms leave droppings

  $Id: worm.c,v 1.16 2008/07/13 16:08:17 wmcbrine Exp $
*)

open Fncurses.Core

[<AutoOpen>]
module DomainTypes =
                
    type Boundary =
        { Top : CInt
          Right : CInt
          Bottom : CInt
          Left : CInt }
    
    type Coordinate =
        { Y : CInt
          X : CInt }
     
    type Bearing =
        | NW = 6 | N = 7 | NE = 0
        |  W = 5         |  E = 1
        | SW = 4 | S = 3 | SE = 2
    
    type Position =
        |    TopLeft = 0 |    Top = 1 |    TopRight = 2
        |       Left = 3 | Normal = 4 |       Right = 5
        | BottomLeft = 6 | Bottom = 7 | BottomRight = 8
    
    type Worm =
        { Character : char
          Bearing : Bearing
          HeadIndex : int
          Body : Coordinate array }        

    type Configuration = 
        { Random: System.Random
          Field: string
          WormLength: int
          WormCount: int
          TrailCharacter: char
          WormCharacters: char array }


module Boundary =

  let make (top, right, bottom, left) =
      { Top = top
        Right = right
        Bottom = bottom
        Left = left }    

  let contains boundary coordinate =
      coordinate.Y >= boundary.Top && coordinate.Y <= boundary.Bottom &&
      coordinate.X >= boundary.Left && coordinate.X <= boundary.Right


module Coordinate =

    let make (y, x) =
        { Y = y
          X = x }
        
    let empty = make (-1s, -1s)

    let (|Position|_|) boundary coordinate =
      if Boundary.contains boundary coordinate then
        match coordinate.Y, coordinate.X with
        | 0s, 0s                                                -> Position.TopLeft
        |  y, 0s when y = boundary.Bottom                       -> Position.BottomLeft
        |  _, 0s                                                -> Position.Left
        | 0s,  x when x = boundary.Right                        -> Position.TopRight
        |  y,  x when x = boundary.Right && y = boundary.Bottom -> Position.BottomRight
        |  _,  x when x = boundary.Right                        -> Position.Right
        | 0s,  _                                                -> Position.Top
        |  y,  _ when y = boundary.Bottom                       -> Position.Bottom
        |  _,  _                                                -> Position.Normal
        |> Some
      else
            None
        

module Configuration =

    let make (field, wormLength, wormCount, trailCharacter, wormCharacters) =
        { Random = System.Random()
          Field = field
          WormLength = wormLength
          WormCount = wormCount
          TrailCharacter = trailCharacter
          WormCharacters = wormCharacters } 


module Worm =
    
    let bearingOptions =
        array2D    
            [| [| [||]; [||]; [||]; [||]; [||]; [|Bearing.S|]; [|Bearing.E; Bearing.S|]; [|Bearing.E|] |]
               [| [|Bearing.E|]; [|Bearing.E; Bearing.SE|]; [||]; [||]; [||]; [|Bearing.SW; Bearing.W|]; [|Bearing.W|]; [|Bearing.E; Bearing.W|]|]
               [| [|Bearing.S; Bearing.W|]; [|Bearing.S|]; [||]; [||]; [||]; [||]; [||]; [|Bearing.W|]|]
               [| [||]; [||]; [||]; [|Bearing.SE; Bearing.S|]; [|Bearing.S|]; [|Bearing.S; Bearing.N|]; [|Bearing.N|]; [|Bearing.N; Bearing.NE|]|]
               [| [|Bearing.N; Bearing.NE; Bearing.E|]; [|Bearing.NE; Bearing.E; Bearing.SE|]; [|Bearing.E; Bearing.SE; Bearing.S|]; [|Bearing.SE; Bearing.S; Bearing.SW|]; [|Bearing.S; Bearing.SW; Bearing.W|]; [|Bearing.SW; Bearing.W; Bearing.NW|]; [|Bearing.W; Bearing.NW; Bearing.N|]; [|Bearing.NW; Bearing.N; Bearing.NE|]|]
               [| [|Bearing.N|]; [|Bearing.S; Bearing.N|]; [|Bearing.S|]; [|Bearing.S; Bearing.SW|]; [||]; [||]; [||]; [|Bearing.NW; Bearing.N|]|]
               [| [|Bearing.N; Bearing.NE; Bearing.E|]; [||]; [||]; [|Bearing.E|]; [|Bearing.E; Bearing.N|]; [|Bearing.N|]; [||]; [||]|]
               [| [||]; [|Bearing.NE; Bearing.E|]; [|Bearing.E|]; [|Bearing.E; Bearing.W|]; [|Bearing.W|]; [|Bearing.W; Bearing.NW|]; [||]; [||]|]
               [| [||]; [|Bearing.N|]; [|Bearing.W; Bearing.N|]; [|Bearing.W|]; [||]; [||]; [||]; [||]|] |]

    //                           NE     E      SE     S       SW       W        NW       N    
    let bearingIncrements =  [| -1s,1s; 0s,1s; 1s,1s; 1s,0s;  1s,-1s;  0s,-1s; -1s,-1s; -1s,0s |]
           
    let empty length ch =
        { Character = ch
          Bearing = Bearing.N
          HeadIndex = 0
          Body = Array.create length Coordinate.empty }

    let head worm =
        worm.Body.[worm.HeadIndex]

    let tail worm =
        worm.Body.[(worm.HeadIndex + 1) % worm.Body.Length]
        
    let nextBearing (random: System.Random) boundary (bearing: Bearing) =
        function | Coordinate.Position boundary position ->
                       let possibleNextBearings = bearingOptions.[int position, int bearing]
                       match possibleNextBearings.Length with
                       | 0 -> Result.error (sprintf "no possible next bearing for position %A and bearing %A" position bearing)
                       | 1 -> Result.result possibleNextBearings.[0]
                       | n -> Result.result possibleNextBearings.[random.Next(0, n - 1)]
                 | coordinate -> Result.error (sprintf "the coordinate %A is out-of-bounds" coordinate)        

    let wiggle random boundary worm =
        ncurses {
            let head = head worm
            let! nextBearing = nextBearing random boundary worm.Bearing head
            let yIncrement,xIncrement = bearingIncrements.[int nextBearing]
            let nextHead = Coordinate.make (head.Y + yIncrement, head.X + xIncrement)
            let nextHeadIndex = (worm.HeadIndex + 1) % worm.Body.Length
            let nextBody = Array.copy worm.Body
            nextBody.[nextHeadIndex] <- nextHead
            return
                { worm with
                    Bearing = nextBearing
                    HeadIndex = nextHeadIndex
                    Body = nextBody }
        }
        
let cleanup () =
    ncurses {
        do! standend ()
        do! refresh ()
        do! curs_set 1s
        return! endwin ()
    }

let SET_COLOR (num, fg, bg) =
   ncurses {
       do! init_pair (num + CInt.one) fg bg
       // TODO: what does flavor do?
       //do flavor.[int num] <- flavor.[int num] ||| Color.COLOR_PAIR(num + CInt.one) ||| Attribute.A_BOLD
   }

let initColors () =
    ncurses {
        if has_colors () then
            do! start_color ()
            // TODO: Choice.bimap???
            let bg = 
                match use_default_colors () with
                | Success _ -> -1s
                | Failure _ -> Color.COLOR_BLACK
            do! SET_COLOR(0s, Color.COLOR_GREEN, bg)
            do! SET_COLOR(1s, Color.COLOR_RED, bg)
            do! SET_COLOR(2s, Color.COLOR_CYAN, bg)
            do! SET_COLOR(3s, Color.COLOR_WHITE, bg)
            do! SET_COLOR(4s, Color.COLOR_MAGENTA, bg)
            do! SET_COLOR(5s, Color.COLOR_BLUE, bg)
            do! SET_COLOR(6s, Color.COLOR_YELLOW, bg)
    }

let checkUserInput () =
    ncurses {
        match getch () with
        | Success ch ->
            match char ch with
            | 'q' ->
                // Quit worms. 
                return true
            | 's' ->
                // Enter single-step mode. 
                do! nodelay (stdscr ()) false
                return false
            | ' ' -> 
                // Leave single-step mode.
                do! nodelay (stdscr ()) true
                return false
            | _ ->
                // Continue. 
                return false
        | _ ->
            // No user input, so continue. 
            return false
    }

let display coordinate ch =
    ncurses {
        do! move coordinate.Y coordinate.X
        do! addch ch
    }

let decrementRefCount (refCounts: CInt[,]) coordinate =
    let refCount = refCounts.[int coordinate.Y, int coordinate.X] - 1s
    refCounts.[int coordinate.Y, int coordinate.X] <- refCount
    refCount
                
let incrementRefCount (refCounts: CInt[,]) coordinate =
    let refCount = refCounts.[int coordinate.Y, int coordinate.X] + 1s
    refCounts.[int coordinate.Y, int coordinate.X] <- refCount

let wiggleWorm config random boundary (refCounts: CInt[,]) worm =
    ncurses {
        let! wiggledWorm = Worm.wiggle random boundary worm
        let tail = Worm.tail worm
        let head = Worm.head wiggledWorm

        if Boundary.contains boundary tail then
            let tailRefCount = decrementRefCount refCounts tail
            if tailRefCount = 0s then
                do! display tail config.TrailCharacter
        
        if Boundary.contains boundary head then
            do! display head wiggledWorm.Character
            incrementRefCount refCounts head

        return wiggledWorm
    }

let rec loop config random boundary refCounts worms =
    ncurses {
        let! quit = checkUserInput ()

        if quit then
            return 0
        else
            let! wiggledWorms = NcursesArray.map (wiggleWorm config random boundary refCounts) worms
            do! napms 12s
            do! refresh ()
            return! loop config random boundary refCounts wiggledWorms
    }    

let displayField boundary (field: string) =
    ncurses {
        let n = ref 0
        for y in boundary.Top .. boundary.Bottom do
            for x in boundary.Left .. boundary.Right do
                do! move y x
                do! addch field.[!n % field.Length]
                incr n
    }

let run config =
    ncurses {
        let! win = initscr ()
        let random = System.Random()     
        do! noecho ()
        do! cbreak () 
        do! nonl () 
        do! keypad win true    
        do! curs_set 0s
        let boundary = Boundary.make (0s, COLS () - 1s, LINES () - 1s, 0s)     
        do! initColors()
        let refCounts = Array2D.zeroCreate<CInt> (int (LINES ())) (int (COLS ()))
        let worms =
            [| for i in 1 .. config.WormCount do
                   let ch = config.WormCharacters.[i % config.WormCharacters.Length]
                   yield Worm.empty config.WormLength ch |]
        
        if not <| System.String.IsNullOrWhiteSpace(config.Field) then
            do! displayField boundary config.Field

        do! napms 12s
        do! refresh ()
        do! nodelay win true  
        let! result = loop config random boundary refCounts worms     
        return! cleanup ()
    }


open Nessos.UnionArgParser

type Arguments =
  | Field
  | Length of int
  | Number of int
  | Trail
with
  interface IArgParserTemplate with
    member this.Usage =
      match this with
      | Field _ -> "specify the background field."
      | Length _ -> "specify the worm length."
      | Number _ -> "specify the number of worms."
      | Trail _ -> "display worm trails."

let parser = UnionArgParser.Create<Arguments>()
let usage = parser.Usage()

let config (args:ArgParseResults<Arguments>) = 
  let field = if args.Contains <@ Field @> then "WORM" else ""
  let wormLength = args.GetResult <@ Length @>
  let wormCount = args.GetResult <@ Number @>
  let trailCharacter = if args.Contains <@ Trail @> then ' ' else '.'
  let wormCharacters = [| 'O'; '*'; '#'; '$'; '%'; '0'; '@' |]        
  Configuration.make(field, wormLength, wormCount, trailCharacter, wormCharacters)

[<EntryPoint>]
let main argv =
    let config = parser.Parse argv |> config
    run config |> ignore     
    0 // TODO: handle computation result
