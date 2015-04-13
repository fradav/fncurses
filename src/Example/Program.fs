open Fncurses.Core

module Example =

    // Book

    let greetings () =
        ncurses {
            do! "Greetings from fncurses!".ToCharArray() 
                |> NcursesArray.iter (fun ch ->
                    ncurses { 
                        do! addch ch
                        do! refresh ()
                        do! napms 100s
                    })
        }

    let getstrtest () =
        ncurses {
             let message ="Enter a string: "
             let! row,col = getmaxyx(stdscr,row,col)
             do! mvprintw(row/2,(col-strlen(mesg))/2,"%s",mesg);
             let! str = getstr ()
             do! mvprintw(LINES - 2, 0, "You Entered: %s", str);
        }

//    let add2 () =
//        result {
//            let text1 = "Oh give me a clone!\n"
//            let text2 = "Yes a clone of my own!"
//            do! addstr text1
//            do! addstr text2
//            do! refresh ()
//        }
//
//    let add3 () =
//        result {
//            let text1 = "Oh give me a clone!\n"
//            let text2 = "Yes a clone of my own!"
//            do! addstr text1
//            do! addstr text2
//            do! move 2 0
//            do! addstr "With the Y chromosome changed to the X."
//            do! refresh ()
//        }
//
//    let annoy () =
//        result {
//            let text = [|"Do"; "you"; "find"; "this"; "silly?"|]
//            do! [|0 .. 4|]
//                |> ResultArray.iter (fun a ->
//                    result {
//                        do! [|0 .. 4|]
//                            |> ResultArray.iter (fun b ->
//                                result {
//                                    if b = a then do! attrset (A_BOLD ||| A_UNDERLINE)
//                                    // TODO: do! printw "%s" text.[b]
//                                    do! printw1 "%s" text.[b]
//                                    if b = a then do! attroff (A_BOLD ||| A_UNDERLINE)
//                                    do! addch ' '
//                                })
//                        do! addstr "\b\n"
//                    })
//            do! refresh ()
//        }
//
//    let arrowKeys (ch:int) =
//        result {
//            do!
//                match ch with
//                | KEY_DOWN -> addstr "Down\n"
//                | KEY_UP -> addstr "Up\n"
//                | KEY_LEFT -> addstr "Left\n"
//                | KEY_RIGHT -> addstr "Right\n"
//                | _ -> Result.result ()
//            do! refresh ()
//        }
//
//    let bgcolor1 () =
//        result {
//            do! start_color ()
//            do! init_pair 1s COLOR_WHITE COLOR_BLUE
//            do bkgd (COLOR_PAIR 1u)
//            do! refresh ()
//        }
//
//    let bgcolor2 () =
//        result {
//            do! start_color ()
//            do! init_pair 1s COLOR_WHITE COLOR_BLUE
//            do! init_pair 2s COLOR_GREEN COLOR_WHITE
//            do! init_pair 3s COLOR_RED COLOR_GREEN
//            do bkgd (COLOR_PAIR 1u)
//            do! addstr "I think that I shall never see\n"
//            do! addstr "a color screen as pretty as thee.\n"
//            do! addstr "For seasons may change\n"
//            do! addstr "and storms may thunder;\n"
//            do! addstr "But color text shall always wonder."
//            do! refresh ()
//            let! ch = getch ()
//
//            do bkgd (COLOR_PAIR 2u)
//            do! refresh ()
//            let! ch = getch ()
//
//            do bkgd (COLOR_PAIR 3u)
//            do! refresh ()
//        }

//    let bigpad1 () =
//        result {
//            let! p = newpad 50 100
//            do!
//                if p = null then
//                    addstr "Unable to create new pad"
//                else
//                    addstr "New pad created"
//            do! refresh ()
//        }



    // Book Reference

//    let addch () =
//        result {
//            do! addch 'H'
//            do! addch 'i'
//            do! addch '!'
//            do! refresh ()
//        }
//
//    let addchstr () =
//        result {
//            do! addchstr([|uint32 'H';uint32 'e';uint32 'l';uint32 'l';uint32 'o';0u|])
//            do! refresh ()
//        }

    // runners

let run f =
    ncurses {
        let! win = initscr ()
        do! f ()
        let! ch = wgetch win
        return! endwin ()
    }

//    let runLoop f =
//        result {
//            let! win = initscr ()
//            do! keypad win true
//            let rec loop() =
//                result {
//                    let! ch = getch ()
//                    do! f ch
//                    if ch <> int '\n' then return! loop ()
//                }
//            do! loop ()
//            return! endwin ()
//        }

[<EntryPoint>]
let main argv =
    match run Example.greetings with
    | Success _ -> 0
    | Failure reason -> printfn "%s" reason; 1
