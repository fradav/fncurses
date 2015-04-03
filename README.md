# fncurses

fncurses is an F# wrapper for the ncurses native library.

    open Fncurses.Core
    
    NCurses.initLib @"..\..\lib\native\windows\amd64\pdcurses.dll"
    
    let add1 () =
        result {
            do! "Greetings from NCurses!".ToCharArray() 
                |> ResultArray.iter (fun ch ->
                    result { 
                        do! addch ch
                        do! refresh ()
                        do! napms 100
                    })
        }
    
    let run f =
        result {
            let! win = initscr ()
            do! f ()
            let! ch = wgetch win
            return! endwin ()
        }
    
    run add1
    
## Maintainer(s)

- [@simontcousins](https://github.com/simontcousins)
