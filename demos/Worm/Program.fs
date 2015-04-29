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

let flavor = [| 'O'; '*'; '#'; '$'; '%'; '0'; '@' |] |> Array.map ChType.ofChar
        
type Boundary =
    { Top : CInt
      Right : CInt
      Bottom : CInt
      Left : CInt }
with
    static member make top right bottom left =
        { Top = top; Right = right; Bottom = bottom; Left = left }    

type Coordinate =
  { Y : CInt
    X : CInt }
with
  static member make y x =
    { Y = y; X = x }
  static member empty =
    Coordinate.make -1s -1s

type Bearing =
  | NW = 6 | N = 7 | NE = 0
  |  W = 5         |  E = 1
  | SW = 4 | S = 3 | SE = 2

type Position =
  |    TopLeft = 0 |    Top = 1 |    TopRight = 2
  |       Left = 3 | Normal = 4 |       Right = 5
  | BottomLeft = 6 | Bottom = 7 | BottomRight = 8

type Worm =
    { Orientation : Bearing
      HeadIndex : int
      Body : Coordinate array }
with
    static member empty length =
        { Orientation = Bearing.N
          HeadIndex = 0
          Body = Array.create length Coordinate.empty }
        
let field = ""
let length = 16
let number = 3
let trail = ChType.ofChar ' '
let rand = System.Random()

//                           NE     E      SE     S       SW       W        NW       N    
let bearingIncrements =  [| -1s,1s; 0s,1s; 1s,1s; 1s,0s;  1s,-1s;  0s,-1s; -1s,-1s; -1s,0s |]

let isInBoundary boundary coordinate =
    coordinate.Y >= boundary.Top && coordinate.Y <= boundary.Bottom &&
    coordinate.X >= boundary.Left && coordinate.X <= boundary.Right
        
let (|CoordinatePosition|_|) boundary coordinate =
    if isInBoundary boundary coordinate then
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
    
let nextBearing (rand: System.Random) (bearingOptions: Bearing [] [,]) boundary (orientation: Bearing) =
    function | CoordinatePosition boundary position ->
                 let possibleBearings = bearingOptions.[int position, int orientation]
                 match possibleBearings.Length with
                 | 0 -> Result.error (sprintf "no bearing options for position %A and orientation %A" position orientation)
                 | 1 -> Result.result possibleBearings.[0]
                 | n -> Result.result possibleBearings.[rand.Next(0, n - 1)]
             | coordinate -> Result.error (sprintf "the coordinate %A is out-of-bounds" coordinate)
        
let cleanup () =
    ncurses {
        do! standend ()
        do! refresh ()
        do! curs_set 1s
        return! endwin ()
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
            | Field _ -> "field."
            | Length _ -> "specify the worm length."
            | Number _ -> "specify the number of worms."
            | Trail _ -> "trail."

type Environment = 
    { Field: string
      Length: int
      Number: int
      Trail: ChType }
with
    static member make (field,length,number,trail) =
        {
            Field = field
            Length = length
            Number = number
            Trail = trail
        } 

let parser = UnionArgParser.Create<Arguments>()

let usage = parser.Usage()

let config (args:ArgParseResults<Arguments>) = 
    let field = if args.Contains <@ Field @> then "WORM" else ""
    let length = args.GetResult <@ Length @>
    let number = args.GetResult <@ Number @>
    let trail = if args.Contains <@ Trail @> then ' ' else '.'
    Environment.make(field, length, number, ChType.ofChar trail)

let SET_COLOR(num, fg, bg) =
   ncurses {
       do! init_pair (num + CInt.one) fg bg
       do flavor.[int num] <- flavor.[int num] ||| Color.COLOR_PAIR(num + CInt.one) ||| Attribute.A_BOLD
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

let updateWorm boundary length trailCh wormCh (refCounts: CInt[,]) (worm: Worm) =
    ncurses {
        let head = worm.Body.[worm.HeadIndex]
        let tail = worm.Body.[(worm.HeadIndex + 1) % length]
        
        // Replace the worm character at the tail coordinate with the trail character.
        if isInBoundary boundary tail then
            refCounts.[int tail.Y, int tail.X] <- refCounts.[int tail.Y, int tail.X] - 1s
            if refCounts.[int tail.Y, int tail.X] = 0s then
                do! move tail.Y tail.X
                do! addch trailCh

        // Work out the next head coordinate.
        let! nextBearing = nextBearing rand bearingOptions boundary worm.Orientation head
        let yIncrement,xIncrement = bearingIncrements.[int nextBearing]
        let nextHead = Coordinate.make (head.Y + yIncrement) (head.X + xIncrement)

        // Add the worm character at the next head coordinate.
        if isInBoundary boundary nextHead then
            do! move nextHead.Y nextHead.X
            do! addch wormCh
            refCounts.[int nextHead.Y,int nextHead.X] <- refCounts.[int nextHead.Y,int nextHead.X] + 1s

        // Return an update worm.
        return { worm with
                   Orientation = nextBearing
                   HeadIndex = (worm.HeadIndex + 1) % length
                   (* Body = ??? *) }
    }

let rec loop (worms: Worm array) =
    ncurses {
        let! quit = checkUserInput ()

        if quit then
            return 0
        else
            let! worms' = NcursesArray.map updateWorm worms |> Result.mapError (fun ss -> String.concat "\n" ss)
            //for worm in worms do
            //    do! updateWorm worm
            do! napms 12s
            do! refresh ()
            return! loop worms'
    }    

let run (env: Environment) =
    ncurses {
        let! win = initscr ()
        //srand(seed);     
        do! noecho ()
        do! cbreak () 
        do! nonl () 
        do! keypad win true    
        do! curs_set 0s     
        let bottom = LINES () - 1s;
        let last = COLS () - 1s;
        do! initColors()
        let refCounts = Array2D.zeroCreate<CInt> (int (LINES ())) (int (COLS ()))

//#ifdef BADCORNER
//    /* if addressing the lower right corner doesn't work in your curses */
//
//    ref[bottom][last] = 1;
//#endif

        let worms =
            [|
                for i in 1 .. env.Number do
                    yield Worm.empty env.Length
            |]
        
        // TODO: use field string as a repeated background???
        do! napms 12s
        do! refresh ()
        // NOTE: in nodelay mode if no input is waiting then getch returns err
        do! nodelay win true  
        let! result = loop worms     
        return! cleanup ()
    }

[<EntryPoint>]
let main argv =
    let config = parser.Parse argv |> config
    run config |> ignore     
    0 // return an integer exit code


