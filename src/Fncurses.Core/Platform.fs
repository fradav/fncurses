namespace Fncurses.Core

[<RequireQualifiedAccess>]
module internal Platform =

    open System
    open System.IO
    open System.Runtime.InteropServices

    module Imported =

       module Windows =

            [<DllImport("kernel32")>]
            extern IntPtr LoadLibrary(string dllToLoad);

            [<DllImport("kernel32")>]
            extern bool FreeLibrary(IntPtr hModule);

            [<DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)>]
            extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        module Nix =

            [<DllImport("libdl", CallingConvention = CallingConvention.Cdecl)>]
            extern IntPtr dlopen(String fileName, int flags);
            
            [<DllImport("libdl", CallingConvention = CallingConvention.Cdecl)>]
            extern IntPtr dlsym(IntPtr handle, String symbol);

            [<DllImport("libdl", CallingConvention = CallingConvention.Cdecl)>]
            extern int dlclose(IntPtr handle);

            [<DllImport("libdl", CallingConvention = CallingConvention.Cdecl)>]
            extern IntPtr dlerror();

            let LoadLibrary dllToLoad = 
                dlopen(dllToLoad, 2)

            let FreeLibrary hModule = 
                dlclose(hModule) = 0

            let GetProcAddress (hModule, procedureName) =
                dlerror() |> ignore
                let res = dlsym(hModule, procedureName)
                let errPtr = dlerror()
                if errPtr = IntPtr.Zero then res else IntPtr.Zero

    type ILibraryLoader =
        abstract LoadLibrary : string -> IntPtr
        abstract FreeLibrary : IntPtr -> bool
        abstract GetProcAddress : IntPtr * string -> IntPtr

    let nixLoader () =
        { new ILibraryLoader with
            member this.LoadLibrary dllPath = 
                let libPtr = Imported.Nix.LoadLibrary dllPath
                if libPtr = IntPtr.Zero then
                    failwith (sprintf "Unable to load %s. Make sure libncurses is installed." dllPath)
                libPtr
            member this.FreeLibrary hModule = Imported.Nix.FreeLibrary hModule
            member this.GetProcAddress (hModule, procedureName) = Imported.Nix.GetProcAddress (hModule, procedureName) }

    let macLoader () =
        { new ILibraryLoader with
            member this.LoadLibrary dllPath = 
                let libPtr = Imported.Nix.LoadLibrary dllPath
                if libPtr = IntPtr.Zero then
                    failwith (sprintf "Unable to load %s" dllPath)
                libPtr
            member this.FreeLibrary hModule = Imported.Nix.FreeLibrary hModule
            member this.GetProcAddress (hModule, procedureName) = Imported.Nix.GetProcAddress (hModule, procedureName) }

    let winLoader () =
        { new ILibraryLoader with
            member this.LoadLibrary dllPath = 
                let libPtr = Imported.Windows.LoadLibrary dllPath
                if libPtr = IntPtr.Zero then
                    failwith (sprintf "Unable to load %s" dllPath)
                libPtr
            member this.FreeLibrary hModule = 
                Imported.Windows.FreeLibrary hModule
            member this.GetProcAddress (hModule, procedureName) = 
                Imported.Windows.GetProcAddress (hModule, procedureName) }

#if INTERACTIVE
    let root = __SOURCE_DIRECTORY__ + @"..\.."
#else
    let root = AppDomain.CurrentDomain.BaseDirectory
#endif

    let nixLibraryPath dll =
        "/usr/lib/libncursesw.so"

    let macLibraryPath dll = 
        Path.Combine(root,"lib","native","darwin","universal",dll)

    let winLibraryPath dll = 
        Path.Combine(root,"lib","native","windows",(if IntPtr.Size = 4 then "x86" else "amd64"),dll)
               
    let dispatch macF nixF winF =
        match Environment.OSVersion.Platform with
        | PlatformID.Win32NT 
        | PlatformID.Win32S 
        | PlatformID.Win32Windows 
        | PlatformID.WinCE
        | PlatformID.Xbox -> winF ()
        | PlatformID.Unix -> nixF ()
        | PlatformID.MacOSX -> macF ()
        | _ -> failwith (sprintf "unrecognised platform ID %A" Environment.OSVersion.Platform)

    let getDelegate<'T when 'T :> Delegate> (loader: ILibraryLoader) libPtr functionName =
        let procAddress = loader.GetProcAddress(libPtr, functionName)
        if procAddress <> IntPtr.Zero then
            Marshal.GetDelegateForFunctionPointer(procAddress, typeof<'T>) :?> 'T
        else
            failwith (sprintf "cannot find imported function %s" functionName)

    let getVariable (loader: ILibraryLoader) libPtr reader variableName =
        let procAddress = loader.GetProcAddress(libPtr, variableName)
        if procAddress <> IntPtr.Zero then
            reader procAddress
        else
            failwith (sprintf "cannot find imported variable %s" variableName)

    let getCInt (loader: ILibraryLoader) libPtr variableName =
        getVariable loader libPtr Marshal.ReadInt16 variableName
 
    let getWinPtr (loader: ILibraryLoader) libPtr variableName =
        getVariable loader libPtr Marshal.ReadIntPtr variableName
 
    let getScrPtr (loader: ILibraryLoader) libPtr variableName =
        getVariable loader libPtr Marshal.ReadIntPtr variableName
 
    let getMOUSE_STATUS (loader: ILibraryLoader) libPtr variableName =
        //getVariable loader libPtr Marshal.ReadInt16 variableName
        raise <| NotImplementedException()
 
    let getChTypeArray (loader: ILibraryLoader) libPtr variableName =
        //getVariable loader libPtr Marshal.ReadInt16 variableName
        raise <| NotImplementedException()

    let getCCharArray (loader: ILibraryLoader) libPtr variableName =
        //getVariable loader libPtr Marshal.PtrToStringAnsi variableName
        raise <| NotImplementedException()
 