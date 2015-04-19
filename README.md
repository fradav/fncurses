# fncurses

fncurses is an F# wrapper for the ncurses native library.

## Building

- Build fncurses using the use the FAKE script:

  * On Windows run: *build.cmd* [![Build status](https://ci.appveyor.com/api/projects/status/4nal23vo4334tsd2?svg=true)](https://ci.appveyor.com/project/simontcousins/fncurses) 
  * On Mono run: *build.sh*

    open Fncurses.Core
    
    let helloworld () =
        ncurses {
            do! "hello, world".ToCharArray() 
                |> NcursesArray.iter (fun ch ->
                    ncurses { 
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
