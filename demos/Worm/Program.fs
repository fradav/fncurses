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
let xinc = [| 1s; 1s; 1s; 0s; -1s; -1s; -1s; 0s |]
let yinc = [| -1s; 0s; 1s; 1s; 1s; 0s; -1s; -1s |]

type Worm =
    { Orientation : int
      Head : int
      XPos : CInt array
      YPos : CInt array }
with
    static member empty length =
        { Orientation = 0
          Head = 0
          XPos = Array.create length -1
          YPos = Array.create length -1 }
        
let field = ""
let length = 16
let number = 3
let trail = ChType.ofChar ' '
let rand = System.Random()


type Bearing =
    | NW = 6 | N = 7 | NE = 0
    |  W = 5         |  E = 1
    | SW = 4 | S = 3 | SE = 2

type Position =
    |    TopLeft = 0 |    Top = 1 |    TopRight = 2
    |       Left = 3 | Normal = 4 |       Right = 5
    | BottomLeft = 6 | Bottom = 7 | BottomRight = 8
        
let position bottom last y x =
    match y, x with
    | 0s, 0s                             -> Position.TopLeft
    |  y, 0s when y = bottom             -> Position.BottomLeft
    |  _, 0s                             -> Position.Left
    | 0s,  x when x = last               -> Position.TopRight
    |  y,  x when x = last && y = bottom -> Position.BottomRight
    |  _,  x when x = last               -> Position.Right
    | 0s,  _                             -> Position.Top
    |  y,  _ when y = bottom             -> Position.Bottom
    |  _,  _                             -> Position.Normal
    
let nextBearing (rand: System.Random) (bearingOptions: Bearing [] [,]) bottom last y x (orientation: Bearing) =
    let position = position bottom last y x
    let possibleBearings = bearingOptions.[int position, int orientation]
    match possibleBearings.Length with
    | 0 -> Result.error (sprintf "no bearing options for position %A and orientation %A" position orientation)
    | 1 -> Result.result possibleBearings.[0]
    | n -> Result.result possibleBearings.[rand.Next(0, n - 1)]

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

type Configuration = 
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
    Configuration.make(field, length, number, ChType.ofChar trail)

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

let updateWorm bottom last length trail (worm: Worm) ch (grid: CInt[,]) =
    ncurses {
        let mutable x = 0s
        let mutable y = 0s
        let mutable h = worm.Head
        x <- worm.XPos.[h]
        
        // Correct overshoot left.
        if x < 0s then
            x <- 0s; worm.XPos.[h] <- x
            y <- bottom; worm.YPos.[h] <- y
            do! move y x
            do! addch ch
            grid.[int y, int x] <- grid.[int y, int x] + 1s
        else
            y <- worm.YPos.[h]

        // Correct overshoot right. 
        if x > last then x <- last

        // Correct overshoot lower.
        if y > bottom then y <- bottom

        h <- h + 1
        if h = length then h <- 0

        if worm.XPos.[h] >= 0s then
            let x1 = worm.XPos.[h]
            let y1 = worm.YPos.[h]

            if y1 < LINES () && x1 < COLS () then
                grid.[int y1, int x1] <- grid.[int y1, int x1] - 1s
                if grid.[int y1, int x1] = 0s then
                    do! move y1 x1
                    do! addch trail

        let options =
            match x, y with
            | 0s, 0s -> upleft
            | 0s, y when y = bottom  -> lowleft
            | 0s, _ -> left
            | x, 0s when x = last -> upright
            | x, y when x = last && y = bottom -> lowright
            | x, _ when x = last -> right
            | _, 0s -> upper
            | _, y when y = bottom -> lower
            | _, _ -> normal

        let op = options.[worm.Orientation]

        let! orientation =
            match op.Nopts with
            | 0 -> Result.error "no orientation options"
            | 1 -> Result.result op.Opts.[0]
            | n -> Result.result op.Opts.[1] // TODO: random 0..n

        y <- y + yinc.[orientation]
        x <- x + xinc.[orientation]
        
        do! move y x

        if y < 0s then y <- 0s

        do! addch ch
        grid.[int y,int x] <- grid.[int y,int x] + 1s 
        return ()

//            move(y += yinc[w->orientation], x += xinc[w->orientation]);
//
//            if (y < 0)
//                y = 0;
//
//            addch(flavor[n % FLAVORS]);
//            ref[w->ypos[h] = y][w->xpos[h] = x]++;
    }

let rec loop (worms: Worm array) =
    ncurses {
        let! quit = checkUserInput ()

        if quit then
            return 0
        else
            for worm in worms do
                do! updateWorm worm
            do! napms 12s
            do! refresh ()
            return! loop worms
    }    

let run (config: Configuration) =
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
        let grid = Array2D.zeroCreate<CInt> (int (LINES ())) (int (COLS ()))

//#ifdef BADCORNER
//    /* if addressing the lower right corner doesn't work in your curses */
//
//    ref[bottom][last] = 1;
//#endif

        let worms =
            [|
                for i in 1 .. config.Number do
                    yield Worm.empty config.Length
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


