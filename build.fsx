// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Git
open Fake.AssemblyInfoFile
open Fake.ReleaseNotesHelper
open System
open System.IO

// --------------------------------------------------------------------------------------
// Types
//
// Copied from https://github.com/freya-fs/freya/blob/master/build.fsx
// --------------------------------------------------------------------------------------

type Solution = 
    { Name: string
      Metadata: Metadata
      Structure: Structure
      VersionControl: VersionControl }
and Metadata = 
    { Summary: string
      Description: string
      Authors: string list
      Keywords: string list
      Info: Info }
and Info = 
    { ReadMe: string
      License: string
      Notes: string }
and Structure = 
    { Solution: string
      Projects: Projects }
and Projects = 
    { Source: SourceProject list
      Test: TestProject list }
and SourceProject = 
    { Name: string
      Dependencies: Dependency list }
and Dependency =
    | Package of string
    | Local of string
and TestProject = 
    { Name: string }
and VersionControl = 
    { Owner: string
      Name: string 
      Source: string
      Raw: string }

// --------------------------------------------------------------------------------------
// Solution
// --------------------------------------------------------------------------------------
        
let solution = 
    { Name = "Fncurses"
      Metadata = 
        { Summary = "Fncurses - An F# wrapper for the native ncurses library"
          Description = "Fncurses"
          Authors = [ "Simon Cousins (@simontcousins)" ]
          Keywords = [ "f#"; "fsharp"; "curses" ]
          Info = { ReadMe = "README.md"; License = "LICENSE.txt"; Notes = "RELEASE_NOTES.md" } }
      Structure = 
        { Solution = "Fncurses.sln"
          Projects = 
            { Source = 
                [ { Name = "Fncurses.Core"
                    Dependencies = 
                        [ Package "FSharp.Core" ] }
                  { Name = "Example"
                    Dependencies = 
                        [ Package "FSharp.Core"
                          Local "Fncurses.Core" ] } ]
              Test = [ { Name = "Fncurses.Core.Tests" } ] } }
      VersionControl = 
        { Owner = "simontcousins"
          Name = "fncurses" 
          Source = "https://github.com/simontcousins/fncurses.git"
          Raw = "https://raw.github.com/simontcousins" } }

// --------------------------------------------------------------------------------------
// Properties
// --------------------------------------------------------------------------------------

let release =
    parseReleaseNotes (File.ReadAllLines solution.Metadata.Info.Notes)

let assemblyVersion =
    release.AssemblyVersion

let nugetVersion =
    match isLocalBuild, release.NugetVersion.Contains "-" with
    | false, true -> sprintf "%s-%s" release.NugetVersion buildVersion
    | false, _ -> sprintf "%s.%s" release.NugetVersion buildVersion
    | _ -> release.NugetVersion

let notes =
    String.concat Environment.NewLine release.Notes

// --------------------------------------------------------------------------------------
// Helpers
// --------------------------------------------------------------------------------------

let dependencies (x: SourceProject) =
    x.Dependencies 
    |> List.choose (function | Package x -> Some (x, GetPackageVersion "packages" x)
                             | Local x -> Some (x, nugetVersion)
                             | _ -> None)

let extensions =
    [ 
        "dll"
        "pdb"
        "xml" 
    ]

let files (x: SourceProject) =
    let managed =
        extensions
        |> List.map (fun ext ->
            sprintf @"..\bin\%s.%s" x.Name ext,
            Some "lib/net45", 
            None)
    let all = managed
    trace (sprintf "files = %A" all)
    all

let projectFile (x: SourceProject) =
    sprintf @"src/%s/%s.fsproj" x.Name x.Name

let tags (s: Solution) =
    String.concat " " s.Metadata.Keywords

let assemblyInfo (x: SourceProject) =
    sprintf @"src/%s/AssemblyInfo.fs" x.Name

let testAssembly (x: TestProject) =
    sprintf "tests/%s/bin/Release/%s.dll" x.Name x.Name

// --------------------------------------------------------------------------------------
// Targets
// --------------------------------------------------------------------------------------

#if MONO
#else
#load "packages/SourceLink.Fake/Tools/Fake.fsx"
open SourceLink

Target "Publish.Debug" (fun _ ->
    let baseUrl = sprintf "%s/%s/{0}/%%var2%%" solution.VersionControl.Raw (solution.Name.ToLowerInvariant ())

    solution.Structure.Projects.Source
    |> List.iter (fun project ->
        use git = new GitRepo __SOURCE_DIRECTORY__

        let release = VsProj.LoadRelease (projectFile project)
        let files = release.Compiles -- "**/AssemblyInfo.fs"

        git.VerifyChecksums files
        release.VerifyPdbChecksums files
        release.CreateSrcSrv baseUrl git.Revision (git.Paths files)
        
        Pdbstr.exec release.OutputFilePdb release.OutputFilePdbSrcSrv))

Target "Publish.MetaPackage" (fun _ ->
    NuGet (fun x ->
        { x with
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Authors = solution.Metadata.Authors
            Dependencies =
                solution.Structure.Projects.Source
                |> List.map (fun project -> project.Name, nugetVersion)
            Description = solution.Metadata.Description
            OutputPath = "bin"
            Project = solution.Name
            Publish = hasBuildParam "nugetkey"
            ReleaseNotes = notes
            Summary = solution.Metadata.Summary
            Tags = tags solution
            Version = nugetVersion }) ("nuget/" + solution.Name + ".nuspec"))

Target "Publish.Packages" (fun _ ->
    solution.Structure.Projects.Source 
    |> List.iter (fun project ->
        NuGet (fun x ->
            { x with
                AccessKey = getBuildParamOrDefault "nugetkey" ""
                Authors = solution.Metadata.Authors
                Dependencies = dependencies project
                Description = solution.Metadata.Description
                Files = files project
                OutputPath = "bin"
                Project = project.Name
                Publish = hasBuildParam "nugetkey"
                ReleaseNotes = notes
                Summary = solution.Metadata.Summary
                Tags = tags solution
                Version = nugetVersion }) ("nuget/" + solution.Name + ".nuspec")))

#endif

Target "Source.AssemblyInfo" (fun _ ->
    solution.Structure.Projects.Source
    |> List.iter (fun project ->
        CreateFSharpAssemblyInfo (assemblyInfo project)
            [ 
                Attribute.Description solution.Metadata.Summary
                Attribute.FileVersion assemblyVersion
                Attribute.Product project.Name
                Attribute.Title project.Name
                Attribute.Version assemblyVersion 
            ]))

Target "Source.Build" (fun _ ->
    build (fun parameters ->
        { parameters with
            Properties =
                [ 
                    "Optimize",      environVarOrDefault "Build.Optimize"      "True"
                    "DebugSymbols",  environVarOrDefault "Build.DebugSymbols"  "True"
                    "Configuration", environVarOrDefault "Build.Configuration" "Release" 
                ]
            Targets =
                [ 
                    "Build" 
                ]
            Verbosity = Some Normal 
        }) solution.Structure.Solution)

Target "Libs.CopyNative" (fun _ ->
    CopyRecursive "lib" "bin/lib" true |> tracefn "%A")

Target "Source.Clean" (fun _ ->
    CleanDirs [ "bin"; "temp" ])

Target "Source.Test" (fun _ ->
    try
        solution.Structure.Projects.Test
        |> List.map (fun project -> testAssembly project)
        |> NUnit (fun x ->
            { x with
                DisableShadowCopy = true
                TimeOut = TimeSpan.FromMinutes 20.
                OutputFile = "bin/TestResults.xml" 
            })
    finally
        AppVeyor.UploadTestResultsXml AppVeyor.TestResultsType.NUnit "bin")

// --------------------------------------------------------------------------------------
// Documentation
// --------------------------------------------------------------------------------------

Target "CleanDocs" (fun _ ->
    CleanDirs ["docs/output"]
)

Target "GenerateReferenceDocs" (fun _ ->
    if not <| executeFSIWithArgs "docs/tools" "generate.fsx" ["--define:RELEASE"; "--define:REFERENCE"] [] then
      failwith "generating reference documentation failed"
)

let generateHelp' fail debug =
    let args =
        if debug then ["--define:HELP"]
        else ["--define:RELEASE"; "--define:HELP"]
    if executeFSIWithArgs "docs/tools" "generate.fsx" args [] then
        traceImportant "Help generated"
    else
        if fail then
            failwith "generating help documentation failed"
        else
            traceImportant "generating help documentation failed"

let generateHelp fail =
    generateHelp' fail false

Target "GenerateHelp" (fun _ ->
    DeleteFile "docs/content/release-notes.md"
    CopyFile "docs/content/" "RELEASE_NOTES.md"
    Rename "docs/content/release-notes.md" "docs/content/RELEASE_NOTES.md"

    DeleteFile "docs/content/license.md"
    CopyFile "docs/content/" "LICENSE.txt"
    Rename "docs/content/license.md" "docs/content/LICENSE.txt"

    generateHelp true
)

Target "GenerateHelpDebug" (fun _ ->
    DeleteFile "docs/content/release-notes.md"
    CopyFile "docs/content/" "RELEASE_NOTES.md"
    Rename "docs/content/release-notes.md" "docs/content/RELEASE_NOTES.md"

    DeleteFile "docs/content/license.md"
    CopyFile "docs/content/" "LICENSE.txt"
    Rename "docs/content/license.md" "docs/content/LICENSE.txt"

    generateHelp' true true
)

Target "KeepRunning" (fun _ ->    
    use watcher = new FileSystemWatcher(DirectoryInfo("docs/content").FullName,"*.*")
    watcher.EnableRaisingEvents <- true
    watcher.Changed.Add(fun e -> generateHelp false)
    watcher.Created.Add(fun e -> generateHelp false)
    watcher.Renamed.Add(fun e -> generateHelp false)
    watcher.Deleted.Add(fun e -> generateHelp false)

    traceImportant "Waiting for help edits. Press any key to stop."

    System.Console.ReadKey() |> ignore

    watcher.EnableRaisingEvents <- false
    watcher.Dispose()
)

Target "GenerateDocs" DoNothing

let createIndexFsx lang =
    let content = """(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../../bin"

(**
Fncurses ({0})
=========================
*)
"""
    let targetDir = "docs/content" @@ lang
    let targetFile = targetDir @@ "index.fsx"
    ensureDirectory targetDir
    System.IO.File.WriteAllText(targetFile, System.String.Format(content, lang))

Target "AddLangDocs" (fun _ ->
    let args = System.Environment.GetCommandLineArgs()
    if args.Length < 4 then
        failwith "Language not specified."

    args.[3..]
    |> Seq.iter (fun lang ->
        if lang.Length <> 2 && lang.Length <> 3 then
            failwithf "Language must be 2 or 3 characters (ex. 'de', 'fr', 'ja', 'gsw', etc.): %s" lang

        let templateFileName = "template.cshtml"
        let templateDir = "docs/tools/templates"
        let langTemplateDir = templateDir @@ lang
        let langTemplateFileName = langTemplateDir @@ templateFileName

        if System.IO.File.Exists(langTemplateFileName) then
            failwithf "Documents for specified language '%s' have already been added." lang

        ensureDirectory langTemplateDir
        Copy langTemplateDir [ templateDir @@ templateFileName ]

        createIndexFsx lang)
)

Target "ReleaseDocs" (fun _ ->
    let tempDocsDir = "temp/gh-pages"
    CleanDir tempDocsDir
    Repository.cloneSingleBranch "" solution.VersionControl.Source "gh-pages" tempDocsDir

    CopyRecursive "docs/output" tempDocsDir true |> tracefn "%A"
    StageAll tempDocsDir
    Git.Commit.Commit tempDocsDir (sprintf "Update generated documentation for version %s" release.NugetVersion)
    Branches.push tempDocsDir
)

// --------------------------------------------------------------------------------------
// Builds
// --------------------------------------------------------------------------------------

Target "Default" DoNothing
Target "Source" DoNothing
Target "Publish" DoNothing

"Source"
#if MONO
#else
//==> "Publish.Debug"
//==> "Publish.Packages"
//==> "Publish.MetaPackage"
#endif
==> "Publish"

"Source.Clean"
==> "Source.AssemblyInfo"
==> "Source.Build"
==> "Source.Test"
==> "Source"
==> "Libs.CopyNative"
=?> ("GenerateReferenceDocs",isLocalBuild && not isMono)
=?> ("GenerateDocs",isLocalBuild && not isMono)
==> "Default"
=?> ("ReleaseDocs",isLocalBuild && not isMono)

"Source"
==> "Publish"
==> "Default"

"CleanDocs"
  ==> "GenerateHelp"
  ==> "GenerateReferenceDocs"
  ==> "GenerateDocs"

"CleanDocs"
  ==> "GenerateHelpDebug"

"GenerateHelp"
  ==> "KeepRunning"

RunTargetOrDefault "Default"
