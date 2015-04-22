open Fncurses.Core

module Example =

    let helloworld () =
        ncurses {
            do! "Greetings from fncurses!".ToCharArray() 
                |> NcursesArray.iter (fun ch ->
                    ncurses {
                        do! addch ch
                        do! refresh ()
                        do! napms 100s
                    })
        }

    let stringinputoutput () =
        ncurses {
            let message ="Enter a string: "
            let! row,col = getmaxyx <| stdscr ()
            let y = row / 2s
            let x = (col - int16 message.Length) / 2s
            do! mvprintw y x "%s" message
            let! str = getstr ()
            do! mvprintw (LINES () - 2s) 0s "You Entered: %s" str
        }

    let annoy () =
        ncurses {
            let text = [|"Do"; "you"; "find"; "this"; "silly?"|]
            do! [|0 .. 4|]
                |> NcursesArray.iter (fun a ->
                    ncurses {
                        do! [|0 .. 4|]
                            |> NcursesArray.iter (fun b ->
                                ncurses {
                                    if b = a then do! attrset (Attribute.A_BOLD ||| Attribute.A_UNDERLINE)
                                    do! printw "%s" text.[b]
                                    if b = a then do! attroff (Attribute.A_BOLD ||| Attribute.A_UNDERLINE)
                                    do! addch ' '
                                })
                        do! addstr "\b\n"
                    })
            do! refresh ()
        }

    let attributes () =
        ncurses {
            do!
                [|
                    "A_NORMAL",Attribute.A_NORMAL
                    "A_STANDOUT",Attribute.A_STANDOUT
                    "A_UNDERLINE",Attribute.A_UNDERLINE
                    "A_REVERSE",Attribute.A_REVERSE
                    "A_BLINK",Attribute.A_BLINK
                    "A_DIM",Attribute.A_DIM
                    "A_BOLD",Attribute.A_BOLD
                    "A_ALTCHARSET",Attribute.A_ALTCHARSET
                    "A_INVIS",Attribute.A_INVIS
                    "A_PROTECT",Attribute.A_PROTECT
                |] |> NcursesArray.iter (fun (text,attribute) ->
                    ncurses {
                        do! attrset attribute
                        do! printw "%s" text
                        do! attroff attribute
                        do! addch '\n'
                    })
            }


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

// TODO: set the environment variables when initscr is called or just use getter per variable?

[<EntryPoint>]
let main argv =
    match run Example.attributes with
    | Success _ -> 0
    | Failure reason -> printfn "%s" reason; 1
