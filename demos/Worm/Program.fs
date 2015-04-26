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
let xinc = [| 1; 1; 1; 0; -1; -1; -1; 0 |]
let yinc = [| -1; 0; 1; 1; 1; 0; -1; -1 |]

type Worm =
    { Orientation : int
      Head : int
      XPos : int array
      YPos : int array }
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

type Options = 
    { Nopts : int
      Opts : int array }
with
    static member make (nopts,opts) = { Nopts = nopts; Opts = opts }

let normal =
    [|
        3, [| 7; 0; 1 |]; 3, [| 0; 1; 2 |]; 3, [| 1; 2; 3 |];
        3, [| 2; 3; 4 |]; 3, [| 3; 4; 5 |]; 3, [| 4; 5; 6 |];
        3, [| 5; 6; 7 |]; 3, [| 6; 7; 0 |]
    |] |> Array.map Options.make

let upper =
    [|
        1, [| 1; 0; 0 |]; 2, [| 1; 2; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]; 2, [| 4; 5; 0 |];
        1, [| 5; 0; 0 |]; 2, [| 1; 5; 0 |]
    |] |> Array.map Options.make

let left =
    [|
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        2, [| 2; 3; 0 |]; 1, [| 3; 0; 0 |]; 2, [| 3; 7; 0 |];
        1, [| 7; 0; 0 |]; 2, [| 7; 0; 0 |]
    |] |> Array.map Options.make

let right =
    [|
        1, [| 7; 0; 0 |]; 2, [| 3; 7; 0 |]; 1, [| 3; 0; 0 |];
        2, [| 3; 4; 0 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 2, [| 6; 7; 0 |]
    |] |> Array.map Options.make

let lower =
    [|
        0, [| 0; 0; 0 |]; 2, [| 0; 1; 0 |]; 1, [| 1; 0; 0 |];
        2, [| 1; 5; 0 |]; 1, [| 5; 0; 0 |]; 2, [| 5; 6; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]
    |] |> Array.map Options.make

let upleft =
    [|
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]; 1, [| 3; 0; 0 |];
        2, [| 1; 3; 0 |]; 1, [| 1; 0; 0 |]
    |] |> Array.map Options.make

let upright =
    [|
        2, [| 3; 5; 0 |]; 1, [| 3; 0; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 1, [| 5; 0; 0 |]
    |] |> Array.map Options.make

let lowleft =
    [|
        3, [| 7; 0; 1 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        1, [| 1; 0; 0 |]; 2, [| 1; 7; 0 |]; 1, [| 7; 0; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]
    |] |> Array.map Options.make

let lowright =
    [|
        0, [| 0; 0; 0 |]; 1, [| 7; 0; 0 |]; 2, [| 5; 7; 0 |];
        1, [| 5; 0; 0 |]; 0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |];
        0, [| 0; 0; 0 |]; 0, [| 0; 0; 0 |]
    |] |> Array.map Options.make

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

let rec loop (worms: Worm array) =
    ncurses {
        for worm in worms do
            let h = worm.Head 
            let x = worm.XPos.[h]
            if x < 0 then
                worm.XPos.[h] <- 0
                worm.YPos.[h] <- bottom
                let x = 0
                let y = bottom
                do! move y x
                do! addch flavor.[n % FLAVORS]
                ref.[y].[x] ++
            else
                let y = worm.YPos.[h]

            if x > last then x <- last
            if y > bottom then y <- bottom
            let h <- h + 1
            if h = length then h <- 0
            worm.Head <- h
            if worm.XPos.[worm.Head] >= 0 then
                let x1 = worm.XPos.[h]
                let y1 = worm.YPos.[h]
                ref.[y1].[x1] --
                if y1 < LINES () && x1 < COLS then
                    decr ref.[y1].[x1]
                    if ref.[y1].[x1] = 0 then
                        do! move y1 x1
                        do! addch trail
                                    
//            if (w->xpos[w->head = h] >= 0)
//            {
//                int x1 = w->xpos[h];
//                int y1 = w->ypos[h];
//
//                if (y1 < LINES && x1 < COLS && --ref[y1][x1] == 0)
//                {
//                    move(y1, x1);
//                    addch(trail);
//                }
//            }
//
//            op = &(x == 0 ? (y == 0 ? upleft :
//                  (y == bottom ? lowleft : left)) :
//                  (x == last ? (y == 0 ? upright :
//                  (y == bottom ? lowright : right)) :
//                  (y == 0 ? upper :
//                  (y == bottom ? lower : normal))))
//                  [w->orientation];
//
//            switch (op->nopts)
//            {
//            case 0:
//                cleanup();
//                return EXIT_SUCCESS;
//            case 1:
//                w->orientation = op->opts[0];
//                break;
//            default:
//                w->orientation = op->opts[rand() % op->nopts];
//            }
//
//            move(y += yinc[w->orientation], x += xinc[w->orientation]);
//
//            if (y < 0)
//                y = 0;
//
//            addch(flavor[n % FLAVORS]);
//            ref[w->ypos[h] = y][w->xpos[h] = x]++;
//        }
//        napms(12);
//        refresh();
//    }
        
        do! napms 12
        do! refresh ()
        return! loop ()
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
        let ref = Array2D.zeroCreate<int16> (int (LINES ())) (int (COLS ()))

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
//    if (field)
//    {
//        const char *p = field;
//
//        for (y = bottom; --y >= 0;)
//            for (x = COLS; --x >= 0;)
//            {
//                addch((chtype) (*p++));
//
//                if (!*p)
//                    p = field;
//            }
//    }

        do! napms 12s
        do! refresh ()
        do! nodelay win true
        do! loop worms
        
//    for (;;)
//    {
//        int ch;
//
//        if ((ch = getch()) > 0)
//        {
//#ifdef KEY_RESIZE
//            if (ch == KEY_RESIZE)
//            {
//# ifdef PDCURSES
//                resize_term(0, 0);
//                erase();
//# endif
//                if (last != COLS - 1)
//                {
//                    for (y = 0; y <= bottom; y++)
//                    {
//                        ref[y] = realloc(ref[y], sizeof(short) * COLS);
//
//                        for (x = last + 1; x < COLS; x++)
//                            ref[y][x] = 0;
//                    }
//
//                    last = COLS - 1;
//                }
//
//                if (bottom != LINES - 1)
//                {
//                    for (y = LINES; y <= bottom; y++)
//                        free(ref[y]);
//
//                    ref = realloc(ref, sizeof(short *) * LINES);
//
//                    for (y = bottom + 1; y < LINES; y++)
//                    {
//                        ref[y] = malloc(sizeof(short) * COLS);
//
//                        for (x = 0; x < COLS; x++)
//                            ref[y][x] = 0;
//                    }
//
//                    bottom = LINES - 1;
//                }
//            }
//
//#endif /* KEY_RESIZE */
//
//            /* Make it simple to put this into single-step mode,
//               or resume normal operation - T. Dickey */
//
//            if (ch == 'q')
//            {
//                cleanup();
//                return EXIT_SUCCESS;
//            }
//            else if (ch == 's')
//                nodelay(stdscr, FALSE);
//            else if (ch == ' ')
//                nodelay(stdscr, TRUE);
//        }
//
//        for (n = 0, w = &worm[0]; n < number; n++, w++)
//        {
//            if ((x = w->xpos[h = w->head]) < 0)
//            {
//                move(y = w->ypos[h] = bottom, x = w->xpos[h] = 0);
//                addch(flavor[n % FLAVORS]);
//                ref[y][x]++;
//            }
//            else
//                y = w->ypos[h];
//
//            if (x > last)
//                x = last;
//
//            if (y > bottom)
//                y = bottom;
//
//            if (++h == length)
//                h = 0;
//
//            if (w->xpos[w->head = h] >= 0)
//            {
//                int x1 = w->xpos[h];
//                int y1 = w->ypos[h];
//
//                if (y1 < LINES && x1 < COLS && --ref[y1][x1] == 0)
//                {
//                    move(y1, x1);
//                    addch(trail);
//                }
//            }
//
//            op = &(x == 0 ? (y == 0 ? upleft :
//                  (y == bottom ? lowleft : left)) :
//                  (x == last ? (y == 0 ? upright :
//                  (y == bottom ? lowright : right)) :
//                  (y == 0 ? upper :
//                  (y == bottom ? lower : normal))))
//                  [w->orientation];
//
//            switch (op->nopts)
//            {
//            case 0:
//                cleanup();
//                return EXIT_SUCCESS;
//            case 1:
//                w->orientation = op->opts[0];
//                break;
//            default:
//                w->orientation = op->opts[rand() % op->nopts];
//            }
//
//            move(y += yinc[w->orientation], x += xinc[w->orientation]);
//
//            if (y < 0)
//                y = 0;
//
//            addch(flavor[n % FLAVORS]);
//            ref[w->ypos[h] = y][w->xpos[h] = x]++;
//        }
//        napms(12);
//        refresh();
//    }
     
        return! cleanup ()
    }

[<EntryPoint>]
let main argv =
    let config = parser.Parse argv |> config
    run config |> ignore     
    0 // return an integer exit code


