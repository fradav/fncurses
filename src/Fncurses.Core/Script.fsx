System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
#r "../../bin/Fncurses.Core.dll"
open Fncurses.Core

let add1 () =
    ncurses {
        do! "Greetings from NCurses!".ToCharArray() 
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

run add1

// Resources

// native dependencies:
// https://github.com/aspnet/dnx/issues/402
// https://github.com/aspnet/KestrelHttpServer/blob/e4b9bd265c75704529409638fd9cdfac504a93ef/src/Microsoft.AspNet.Server.Kestrel/KestrelEngine.cs#L26
// https://github.com/aspnet/KestrelHttpServer/blob/dev/src/Microsoft.AspNet.Server.Kestrel/Networking/Libuv.cs#L23
// https://github.com/aspnet/KestrelHttpServer/blob/dev/src/Microsoft.AspNet.Server.Kestrel/Networking/PlatformApis.cs

// dumpbin
// http://stackoverflow.com/questions/14560866/window-command-to-tell-whether-a-dll-file-is-32-bit-or-64-bit

// 64 bit native compilation:
// http://win-builds.org/doku.php/download_and_installation_from_windows
// http://notk.org/~adrien/wb_temp/temp/documentation.html#toolchain_switching

// 64 bit pdcurses
// http://www.projectpluto.com/win32a.htm#download

// pdcurses text doc
// http://pdcurses.sourceforge.net/doc/PDCurses.txt

// pinvoke dllmapping on mono
// http://www.mono-project.com/docs/advanced/pinvoke/

// relative paths in interactive sessions
// http://stackoverflow.com/questions/10917300/how-can-i-get-f-interractive-window-to-use-the-same-path-as-the-project

// git: make current commit the only commit (initial commit)
// http://stackoverflow.com/questions/9683279/make-the-current-commit-the-only-initial-commit-in-a-git-repository
