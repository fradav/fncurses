# fncurses

fncurses is an F# wrapper for the ncurses native library.

    open Fncurses.Core
    
    let helloworld () =
        ncurses {
            do! "hello, world".ToCharArray() 
                |> ResultArray.iter (fun ch ->
                    result { 
                        do! addch ch
                        do! refresh ()
                        do! napms 100
                    })
        }
    
    let run f =
        ncurses {
            let! win = initscr ()
            do! f ()
            let! ch = wgetch win
            return! endwin ()
        }
    
    run helloworld
    
## Maintainer(s)

- [@simontcousins](https://github.com/simontcousins)
