namespace System
open System.Reflection

[<assembly: AssemblyDescriptionAttribute("Fncurses - An F# wrapper for the native ncurses library")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
[<assembly: AssemblyProductAttribute("Fncurses.Core")>]
[<assembly: AssemblyTitleAttribute("Fncurses.Core")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
