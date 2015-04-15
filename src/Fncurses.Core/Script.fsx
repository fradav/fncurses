System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
#r "../../bin/Fncurses.Core.dll"
open Fncurses.Core

let loader = Platform.winLoader ()
let dllPath = @"..\..\lib\native\windows\amd64\pdcurses.dll"
let libPtr = loader.LoadLibrary(dllPath)

let add1 () =
    ncurses {
        do! "Greetings from NCurses!".ToCharArray() 
            |> NcursesArray.iter (fun ch ->
                ncurses { 
                    do! addch ch
                    do! refresh ()
                    do! napms 100s
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

open System

let test ([<ParamArray>] arr : 'a array) =
    if arr.Length = 0 then invalidArg "arr" "must be greate than zero" else 0

let log (s : string) = s
let logger fmt = Printf.kprintf id fmt
let foo = logger "%d %s %b" 10 "123" true

open System
open System.Text
open System.Text.RegularExpressions
open Microsoft.FSharp.Reflection


let check f x = if f x then x
                else failwithf "format failure \"%s\"" x


let parseDecimal x = Decimal.Parse(x, System.Globalization.CultureInfo.InvariantCulture)


let parsers = dict [
                 'b', Boolean.Parse >> box
                 'd', int >> box
                 'i', int >> box
                 's', box
                 'u', uint32 >> int >> box
                 'x', check (String.forall Char.IsLower) >> ((+) "0x") >> int >> box
                 'X', check (String.forall Char.IsUpper) >> ((+) "0x") >> int >> box
                 'o', ((+) "0o") >> int >> box
                 'e', float >> box // no check for correct format for floats
                 'E', float >> box
                 'f', float >> box
                 'F', float >> box
                 'g', float >> box
                 'G', float >> box
                 'M', parseDecimal >> box
                 'c', char >> box
                ]


// array of all possible formatters, i.e. [|"%b"; "%d"; ...|]
let separators =
   parsers.Keys
   |> Seq.map (fun c -> "%" + sprintf "%c" c) 
   |> Seq.toArray


// Creates a list of formatter characters from a format string,
// for example "(%s,%d)" -> ['s', 'd']
let rec getFormatters xs =
   match xs with
   | '%'::'%'::xr -> getFormatters xr
   | '%'::x::xr -> if parsers.ContainsKey x then x::getFormatters xr
                   else failwithf "Unknown formatter %%%c" x
   | x::xr -> getFormatters xr
   | [] -> []


let sscanf (pf:PrintfFormat<_,_,_,_,'t>) s : 't =
  let formatStr = pf.Value.Replace("%%", "%")
  let constants = formatStr.Split(separators, StringSplitOptions.None)
  let regex = Regex("^" + String.Join("(.*?)", constants |> Array.map Regex.Escape) + "$")
  let formatters = pf.Value.ToCharArray() // need original string here (possibly with "%%"s)
                   |> Array.toList |> getFormatters 
  let groups = 
    regex.Match(s).Groups 
    |> Seq.cast<Group> 
    |> Seq.skip 1
  let matches =
    (groups, formatters)
    ||> Seq.map2 (fun g f -> g.Value |> parsers.[f])
    |> Seq.toArray

  if matches.Length = 1 then matches.[0] :?> 't
  else FSharpValue.MakeTuple(matches, typeof<'t>) :?> 't

// some basic testing
let (a,b) = sscanf "(%%%s,%M)" "(%hello, 4.3)"
let (x,y,z) = sscanf "%s-%s-%s" "test-this-string"
let (c,d,e,f,g,h,i) = sscanf "%b-%d-%i,%u,%x,%X,%o" "false-42--31,13,ff,FF,42"
let (j,k,l,m,n,o,p) = sscanf "%f %F %g %G %e %E %c" "1 2.1 3.4 .3 43.2e32 0 f"



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

// sscanf
// http://www.fssnip.net/raw/4I

// memory
// http://stackoverflow.com/questions/12273961/release-unmanaged-memory-from-managed-c-sharp-with-pointer-of-it
// http://stackoverflow.com/questions/11508260/passing-stringbuilder-to-dll-function-expecting-char-pointer

// ExtCore Control: add as a paket file reference
