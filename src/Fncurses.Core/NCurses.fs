namespace Fncurses.Core

[<AutoOpen>]
module NCurses = 

    open System
    open System.Reflection
    open System.Runtime.InteropServices
    open System.Text    

    [<AutoOpen>]
    module Constants =

        /// boolean false value
        [<Literal>] 
        let FALSE = 0

        /// boolean true value
        [<Literal>] 
        let TRUE = 1

        /// zero pointer value
        let NULL = IntPtr.Zero

        /// value returned on error condition
        [<Literal>] 
        let ERR = -1s

        /// value returned on successful completion
        [<Literal>] 
        let OK = 0s

        /// buffer size
        [<Literal>]
        let BUFFER_SIZE = 255s

    [<AutoOpen>]
    module Types =
       
        type ChType = System.UInt32
        type Args = obj array
        type Attr_t = ChType
        type CBool = bool
        type CChar = sbyte
        type CCharPtr = IntPtr
        type CChar_t = ChType
        type CFilePtr = IntPtr
        type CInt = int16
        type CShort = int16
        type CShortPtr = IntPtr
        type CVoid = unit
        type CVoidPtr = IntPtr
        type ChTypePtr = string
        type ScrPtr = IntPtr
        type WinPtr = IntPtr

        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type Attr_t_CShort_CVoidPtr_CInt = delegate of Attr_t * CShort * CVoidPtr -> CInt
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type Attr_t_CShort_CVoidPtr_CInt_f_CInt_CInt_CInt = delegate of Attr_t * CShort * CVoidPtr * CInt * f * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type Attr_t_CVoidPtr_CInt = delegate of Attr_t * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type Attr_tRef_CShortRef_CVoidRef_CInt = delegate of Attr_t byref * CShort byref * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CBool_CVoid = delegate of CBool -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_Args_CInt = delegate of CCharPtr * Args -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CInt = delegate of CCharPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CInt_CInt = delegate of CCharPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharBuf_CInt = delegate of byte array -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharBuf_CInt_CInt = delegate of byte array * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CVoid = delegate of CCharPtr -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CFilePtr_CFilePtr_ScrPtr = delegate of CCharPtr * CFilePtr * CFilePtr -> ScrPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CFilePtr_WinPtr = delegate of CFilePtr -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt = delegate of ChType * ChType * ChType * ChType * ChType * ChType * ChType * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChType_CInt = delegate of ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChType_CInt_CInt = delegate of ChType * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChType_CVoid = delegate of ChType -> CVoid
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type ChType_f_CInt_CInt = delegate of ChType * f * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChTypePtr_CInt = delegate of ChTypePtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ChTypePtr_CInt_CInt = delegate of ChTypePtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_Attr_t_CShort_CVoidPtr_CInt = delegate of CInt * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CChar = delegate of CInt -> CChar
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CCharPtr = delegate of CInt -> CCharPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CCharPtr_CInt_CInt = delegate of CInt * CCharPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt = delegate of CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CCharPtr_Args_CInt = delegate of CInt * CInt * CCharPtr * Args -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CCharPtr_CInt = delegate of CInt * CInt * CCharPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CCharPtr_CInt_CInt = delegate of CInt * CInt * CCharPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_ChType = delegate of CInt * CInt -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_ChType_CInt = delegate of CInt * CInt * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_ChType_CInt_CInt = delegate of CInt * CInt * ChType * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_ChTypePtr_CInt = delegate of CInt * CInt * ChTypePtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_ChTypePtr_CInt_CInt = delegate of CInt * CInt * ChTypePtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CInt = delegate of CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt = delegate of CInt * CInt * CInt * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CInt_CInt_CInt = delegate of CInt * CInt * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CInt_CInt_WinPtr = delegate of CInt * CInt * CInt * CInt -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_CVoid = delegate of CInt * CInt -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CInt_WinPtr = delegate of CInt * CInt -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CVoid = delegate of CInt -> CVoid
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type CInt_f_CInt_WinPtr_CInt_CInt = delegate of CInt * f * CInt * WinPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CIntRef_CIntRef_CVoid = delegate of CInt byref * CInt byref -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CInt = delegate of CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShort_CShort_CInt = delegate of CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShort_CShort_CShort_CInt = delegate of CShort * CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShortRef_CShortRef_CInt = delegate of CShort * CShort byref * CShort byref -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShortRef_CShortRef_CShortRef_CInt = delegate of CShort * CShort byref * CShort byref * CShort byref -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CVoidPtr_CInt = delegate of CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_Attr_t = delegate of CVoid -> Attr_t
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_CBool = delegate of CVoid -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_CChar = delegate of CVoid -> CChar
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_CCharPtr = delegate of CVoid -> CCharPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_ChType = delegate of CVoid -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_CInt = delegate of CVoid -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_CVoid = delegate of CVoid -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CVoid_WinPtr = delegate of CVoid -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ScrPtr_CVoid = delegate of ScrPtr -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ScrPtr_ScrPtr = delegate of ScrPtr -> ScrPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType_CInt = delegate of WinPtr * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_Attr_t_CShort_CVoidPtr_CInt = delegate of WinPtr * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_Attr_t_CVoidPtr_CInt = delegate of WinPtr * Attr_t * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_Attr_tRef_CShortRef_CVoidPtr_CInt = delegate of WinPtr * Attr_t byref * CShort byref * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CBool = delegate of WinPtr -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CBool_CInt = delegate of WinPtr * CBool -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CCharPtr_Args_CInt = delegate of WinPtr * CCharPtr * Args -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CCharPtr_CInt = delegate of WinPtr * CCharPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CCharPtr_CInt_CInt = delegate of WinPtr * CCharPtr * CInt -> CInt
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type WinPtr_CCharPtr_valist_CInt = delegate of WinPtr * CCharPtr * valist -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType = delegate of WinPtr -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt = delegate of WinPtr * ChType * ChType * ChType * ChType * ChType * ChType * ChType * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType_ChType_CInt = delegate of WinPtr * ChType * ChType -> CInt
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type WinPtr_ChType_CInt = delegate of WinPtr * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType_CInt_CInt = delegate of WinPtr * ChType * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChType_CVoid = delegate of WinPtr * ChType -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChTypePtr_CInt = delegate of WinPtr * ChTypePtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_ChTypePtr_CInt_CInt = delegate of WinPtr * ChTypePtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt = delegate of WinPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_Attr_t_CShort_CVoidPtr_CInt = delegate of WinPtr * CInt * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CBool = delegate of WinPtr * CInt -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt = delegate of WinPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CCharPtr_Args_CInt = delegate of WinPtr * CInt * CInt * CCharPtr * Args -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CCharPtr_CInt = delegate of WinPtr * CInt * CInt * CCharPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CCharPtr_CInt_CInt = delegate of WinPtr * CInt * CInt * CCharPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_ChType = delegate of WinPtr * CInt * CInt -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_ChType_CInt = delegate of WinPtr * CInt * CInt * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_ChType_CInt_CInt = delegate of WinPtr * CInt * CInt * ChType * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_ChTypePtr_CInt = delegate of WinPtr * CInt * CInt * ChTypePtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_ChTypePtr_CInt_CInt = delegate of WinPtr * CInt * CInt * ChTypePtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt = delegate of WinPtr * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt = delegate of WinPtr * CInt * CInt * CInt * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt_CInt = delegate of WinPtr * CInt * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt_CInt_CInt = delegate of WinPtr * CInt * CInt * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt = delegate of WinPtr * CInt * CInt * CInt * CInt * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CInt_CInt_CInt_WinPtr = delegate of WinPtr * CInt * CInt * CInt * CInt -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CInt_CVoid = delegate of WinPtr * CInt -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CIntRef_CIntRef_CVoid = delegate of WinPtr * CInt byref * CInt byref -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CShort_CVoidPtr_CInt = delegate of WinPtr * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CVoid = delegate of WinPtr -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_CFilePtr_CInt = delegate of WinPtr * CFilePtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_WinPtr = delegate of WinPtr -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_WinPtr_CInt = delegate of WinPtr * WinPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type WinPtr_WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt_CInt = delegate of WinPtr * WinPtr * CInt * CInt * CInt * CInt * CInt * CInt * CInt -> CInt

    module Imported =

        // Dynamic library loading

        let private loader = Platform.dispatch Platform.macLoader Platform.nixLoader Platform.winLoader        
        let private dllPath = 
            Platform.dispatch 
                (fun () -> Platform.macLibraryPath "libncurses.dylib") 
                (fun () -> Platform.nixLibraryPath "libncurses.dylib") 
                (fun () -> Platform.winLibraryPath "pdcurses.dll")
        System.Console.WriteLine("dllPath: {0}", dllPath)
        let private libPtr = loader.LoadLibrary(dllPath)

        module private Delegate =

            // Standard functions

            let addch = Platform.getDelegate<ChType_CInt> loader libPtr "addch"
            let addchnstr = Platform.getDelegate<ChTypePtr_CInt_CInt> loader libPtr "addchnstr"
            let addchstr = Platform.getDelegate<ChTypePtr_CInt> loader libPtr "addchstr"
            let addnstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "addnstr"
            let addstr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "addstr"
            let attroff = Platform.getDelegate<ChType_CInt> loader libPtr "attroff"
            let attron = Platform.getDelegate<ChType_CInt> loader libPtr "attron"
            let attrset = Platform.getDelegate<ChType_CInt> loader libPtr "attrset"
            let attr_get = Platform.getDelegate<Attr_tRef_CShortRef_CVoidRef_CInt> loader libPtr "attr_get"
            let attr_off = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "attr_off"
            let attr_on = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "attr_on"
            let attr_set = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "attr_set"
            let baudrate = Platform.getDelegate<CVoid_CInt> loader libPtr "baudrate"
            let beep = Platform.getDelegate<CVoid_CInt> loader libPtr "beep"
            let bkgd = Platform.getDelegate<ChType_CInt> loader libPtr "bkgd"
            let bkgdset = Platform.getDelegate<ChType_CVoid> loader libPtr "bkgdset"
            let border = Platform.getDelegate<ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt> loader libPtr "border"
            let box = Platform.getDelegate<WinPtr_ChType_ChType_CInt> loader libPtr "box"
            let can_change_color = Platform.getDelegate<CVoid_CBool> loader libPtr "can_change_color"
            let cbreak = Platform.getDelegate<CVoid_CInt> loader libPtr "cbreak"
            let chgat = Platform.getDelegate<CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "chgat"
            let clearok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "clearok"
            let clear = Platform.getDelegate<CVoid_CInt> loader libPtr "clear"
            let clrtobot = Platform.getDelegate<CVoid_CInt> loader libPtr "clrtobot"
            let clrtoeol = Platform.getDelegate<CVoid_CInt> loader libPtr "clrtoeol"
            let color_content = Platform.getDelegate<CShort_CShortRef_CShortRef_CShortRef_CInt> loader libPtr "color_content"
            let color_set = Platform.getDelegate<CShort_CVoidPtr_CInt> loader libPtr "color_set"
            let copywin = Platform.getDelegate<WinPtr_WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "copywin"
            let curs_set = Platform.getDelegate<CInt_CInt> loader libPtr "curs_set"
            let def_prog_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "def_prog_mode"
            let def_shell_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "def_shell_mode"
            let delay_output = Platform.getDelegate<CInt_CInt> loader libPtr "delay_output"
            let delch = Platform.getDelegate<CVoid_CInt> loader libPtr "delch"
            let deleteln = Platform.getDelegate<CVoid_CInt> loader libPtr "deleteln"
            let delscreen = Platform.getDelegate<ScrPtr_CVoid> loader libPtr "delscreen"
            let delwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "delwin"
            let derwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt> loader libPtr "derwin"
            let doupdate = Platform.getDelegate<CVoid_CInt> loader libPtr "doupdate"
            let dupwin = Platform.getDelegate<WinPtr_WinPtr> loader libPtr "dupwin"
            let echochar = Platform.getDelegate<ChType_CInt> loader libPtr "echochar"
            let echo = Platform.getDelegate<CVoid_CInt> loader libPtr "echo"
            let endwin = Platform.getDelegate<CVoid_CInt> loader libPtr "endwin"
            let erasechar = Platform.getDelegate<CVoid_CChar> loader libPtr "erasechar"
            let erase = Platform.getDelegate<CVoid_CInt> loader libPtr "erase"
            let filter = Platform.getDelegate<CVoid_CVoid> loader libPtr "filter"
            let flash = Platform.getDelegate<CVoid_CInt> loader libPtr "flash"
            let flushinp = Platform.getDelegate<CVoid_CInt> loader libPtr "flushinp"
            let getbkgd = Platform.getDelegate<WinPtr_ChType> loader libPtr "getbkgd"
            let getnstr = Platform.getDelegate<CCharBuf_CInt_CInt> loader libPtr "getnstr"
            let getstr = Platform.getDelegate<CCharBuf_CInt> loader libPtr "getstr"
            let getwin = Platform.getDelegate<CFilePtr_WinPtr> loader libPtr "getwin"
            let halfdelay = Platform.getDelegate<CInt_CInt> loader libPtr "halfdelay"
            let has_colors = Platform.getDelegate<CVoid_CBool> loader libPtr "has_colors"
            let has_ic = Platform.getDelegate<CVoid_CBool> loader libPtr "has_ic"
            let has_il = Platform.getDelegate<CVoid_CBool> loader libPtr "has_il"
            let hline = Platform.getDelegate<ChType_CInt_CInt> loader libPtr "hline"
            let idcok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "idcok"
            let idlok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "idlok"
            let immedok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "immedok"
            let inchnstr = Platform.getDelegate<ChTypePtr_CInt_CInt> loader libPtr "inchnstr"
            let inchstr = Platform.getDelegate<ChTypePtr_CInt> loader libPtr "inchstr"
            let inch = Platform.getDelegate<CVoid_ChType> loader libPtr "inch"
            let init_color = Platform.getDelegate<CShort_CShort_CShort_CShort_CInt> loader libPtr "init_color"
            let init_pair = Platform.getDelegate<CShort_CShort_CShort_CInt> loader libPtr "init_pair"
            let initscr = Platform.getDelegate<CVoid_WinPtr> loader libPtr "initscr"
            let innstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "innstr"
            let insch = Platform.getDelegate<ChType_CInt> loader libPtr "insch"
            let insdelln = Platform.getDelegate<CInt_CInt> loader libPtr "insdelln"
            let insertln = Platform.getDelegate<CVoid_CInt> loader libPtr "insertln"
            let insnstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "insnstr"
            let insstr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "insstr"
            let instr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "instr"
            let intrflush = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "intrflush"
            let isendwin = Platform.getDelegate<CVoid_CBool> loader libPtr "isendwin"
            let is_linetouched = Platform.getDelegate<WinPtr_CInt_CBool> loader libPtr "is_linetouched"
            let is_wintouched = Platform.getDelegate<WinPtr_CBool> loader libPtr "is_wintouched"
            let keyname = Platform.getDelegate<CInt_CCharPtr> loader libPtr "keyname"
            let keypad = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "keypad"
            let killchar = Platform.getDelegate<CVoid_CChar> loader libPtr "killchar"
            let leaveok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "leaveok"
            let longname = Platform.getDelegate<CVoid_CChar> loader libPtr "longname"
            let meta = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "meta"
            let move = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "move"
            let mvaddch = Platform.getDelegate<CInt_CInt_ChType_CInt> loader libPtr "mvaddch"
            let mvaddchnstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvaddchnstr"
            let mvaddchstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt> loader libPtr "mvaddchstr"
            let mvaddnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvaddnstr"
            let mvaddstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvaddstr"
            let mvchgat = Platform.getDelegate<CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "mvchgat"
            let mvcur = Platform.getDelegate<CInt_CInt_CInt_CInt_CInt> loader libPtr "mvcur"
            let mvdelch = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "mvdelch"
            let mvderwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvderwin"
            let mvgetch = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "mvgetch"
            let mvgetnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvgetnstr"
            let mvgetstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvgetstr"
            let mvhline = Platform.getDelegate<CInt_CInt_ChType_CInt_CInt> loader libPtr "mvhline"
            let mvinch = Platform.getDelegate<CInt_CInt_ChType> loader libPtr "mvinch"
            let mvinchnstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvinchnstr"
            let mvinchstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt> loader libPtr "mvinchstr"
            let mvinnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvinnstr"
            let mvinsch = Platform.getDelegate<CInt_CInt_ChType_CInt> loader libPtr "mvinsch"
            let mvinsnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvinsnstr"
            let mvinsstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvinsstr"
            let mvinstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvinstr"
            let mvprintw = Platform.getDelegate<CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvprintw"
            let mvscanw = Platform.getDelegate<CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvscanw"
            let mvvline = Platform.getDelegate<CInt_CInt_ChType_CInt_CInt> loader libPtr "mvvline"
            let mvwaddchnstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvwaddchnstr"
            let mvwaddchstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt> loader libPtr "mvwaddchstr"
            let mvwaddch = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt> loader libPtr "mvwaddch"
            let mvwaddnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwaddnstr"
            let mvwaddstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwaddstr"
            let mvwchgat = Platform.getDelegate<WinPtr_CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "mvwchgat"
            let mvwdelch = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwdelch"
            let mvwgetch = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwgetch"
            let mvwgetnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwgetnstr"
            let mvwgetstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwgetstr"
            let mvwhline = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt_CInt> loader libPtr "mvwhline"
            let mvwinchnstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvwinchnstr"
            let mvwinchstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt> loader libPtr "mvwinchstr"
            let mvwinch = Platform.getDelegate<WinPtr_CInt_CInt_ChType> loader libPtr "mvwinch"
            let mvwinnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwinnstr"
            let mvwinsch = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt> loader libPtr "mvwinsch"
            let mvwinsnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwinsnstr"
            let mvwinsstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwinsstr"
            let mvwinstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwinstr"
            let mvwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwin"
            let mvwprintw = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvwprintw"
            let mvwscanw = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvwscanw"
            let mvwvline = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt_CInt> loader libPtr "mvwvline"
            let napms = Platform.getDelegate<CInt_CInt> loader libPtr "napms"
            let newpad = Platform.getDelegate<CInt_CInt_WinPtr> loader libPtr "newpad"
            let newterm = Platform.getDelegate<CCharPtr_CFilePtr_CFilePtr_ScrPtr> loader libPtr "newterm"
            let newwin = Platform.getDelegate<CInt_CInt_CInt_CInt_WinPtr> loader libPtr "newwin"
            let nl = Platform.getDelegate<CVoid_CInt> loader libPtr "nl"
            let nocbreak = Platform.getDelegate<CVoid_CInt> loader libPtr "nocbreak"
            let nodelay = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "nodelay"
            let noecho = Platform.getDelegate<CVoid_CInt> loader libPtr "noecho"
            let nonl = Platform.getDelegate<CVoid_CInt> loader libPtr "nonl"
            let noqiflush = Platform.getDelegate<CVoid_CVoid> loader libPtr "noqiflush"
            let noraw = Platform.getDelegate<CVoid_CInt> loader libPtr "noraw"
            let notimeout = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "notimeout"
            let overlay = Platform.getDelegate<WinPtr_WinPtr_CInt> loader libPtr "overlay"
            let overwrite = Platform.getDelegate<WinPtr_WinPtr_CInt> loader libPtr "overwrite"
            let pair_content = Platform.getDelegate<CShort_CShortRef_CShortRef_CInt> loader libPtr "pair_content"
            let pechochar = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "pechochar"
            let pnoutrefresh = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "pnoutrefresh"
            let prefresh = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "prefresh"
            let printw = Platform.getDelegate<CCharPtr_Args_CInt> loader libPtr "printw"
            let putwin = Platform.getDelegate<WinPtr_CFilePtr_CInt> loader libPtr "putwin"
            let qiflush = Platform.getDelegate<CVoid_CVoid> loader libPtr "qiflush"
            let raw = Platform.getDelegate<CVoid_CInt> loader libPtr "raw"
            let redrawwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "redrawwin"
            let refresh = Platform.getDelegate<CVoid_CInt> loader libPtr "refresh"
            let reset_prog_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "reset_prog_mode"
            let reset_shell_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "reset_shell_mode"
            let resetty = Platform.getDelegate<CVoid_CInt> loader libPtr "resetty"
            //let ripoffline = Platform.getDelegate<CInt_f_CInt_WinPtr_CInt_CInt> loader libPtr "ripoffline"
            let savetty = Platform.getDelegate<CVoid_CInt> loader libPtr "savetty"
            let scanw = Platform.getDelegate<CCharPtr_Args_CInt> loader libPtr "scanw"
            let scr_dump = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_dump"
            let scr_init = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_init"
            let scr_restore = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_restore"
            let scr_set = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_set"
            let scrl = Platform.getDelegate<CInt_CInt> loader libPtr "scrl"
            let scroll = Platform.getDelegate<WinPtr_CInt> loader libPtr "scroll"
            let scrollok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "scrollok"
            let set_term = Platform.getDelegate<ScrPtr_ScrPtr> loader libPtr "set_term"
            let setscrreg = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "setscrreg"
            let slk_attroff = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attroff"
            let slk_attr_off = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "slk_attr_off"
            let slk_attron = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attron"
            let slk_attr_on = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "slk_attr_on"
            let slk_attrset = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attrset"
            let slk_attr_set = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "slk_attr_set"
            let slk_clear = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_clear"
            let slk_color = Platform.getDelegate<CShort_CInt> loader libPtr "slk_color"
            let slk_init = Platform.getDelegate<CInt_CInt> loader libPtr "slk_init"
            let slk_label = Platform.getDelegate<CInt_CChar> loader libPtr "slk_label"
            let slk_noutrefresh = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_noutrefresh"
            let slk_refresh = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_refresh"
            let slk_restore = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_restore"
            let slk_set = Platform.getDelegate<CInt_CCharPtr_CInt_CInt> loader libPtr "slk_set"
            let slk_touch = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_touch"
            let standend = Platform.getDelegate<CVoid_CInt> loader libPtr "standend"
            let standout = Platform.getDelegate<CVoid_CInt> loader libPtr "standout"
            let start_color = Platform.getDelegate<CVoid_CInt> loader libPtr "start_color"
            let subpad = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_WinPtr> loader libPtr "subpad"
            let subwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_WinPtr> loader libPtr "subwin"
            let syncok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "syncok"
            let termattrs = Platform.getDelegate<CVoid_ChType> loader libPtr "termattrs"
            let term_attrs = Platform.getDelegate<CVoid_Attr_t> loader libPtr "term_attrs"
            let termname = Platform.getDelegate<CVoid_CCharPtr> loader libPtr "termname"
            let timeout = Platform.getDelegate<CInt_CVoid> loader libPtr "timeout"
            let touchline = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "touchline"
            let touchwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "touchwin"
            let typeahead = Platform.getDelegate<CInt_CInt> loader libPtr "typeahead"
            let untouchwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "untouchwin"
            let use_env = Platform.getDelegate<CBool_CVoid> loader libPtr "use_env"
            let vidattr = Platform.getDelegate<ChType_CInt> loader libPtr "vidattr"
            let vid_attr = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "vid_attr"
            //let vidputs = Platform.getDelegate<ChType_f_CInt_CInt> loader libPtr "vidputs"
            //let vid_puts = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt_f_CInt_CInt_CInt> loader libPtr "vid_puts"
            let vline = Platform.getDelegate<ChType_CInt_CInt> loader libPtr "vline"
            //let vw_printw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vw_printw"
            //let vwprintw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vwprintw"
            //let vw_scanw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vw_scanw"
            //let vwscanw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vwscanw"
            let waddchnstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt_CInt> loader libPtr "waddchnstr"
            let waddchstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt> loader libPtr "waddchstr"
            let waddch = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "waddch"
            let waddnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "waddnstr"
            let waddstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "waddstr"
            let wattroff = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattroff"
            let wattron = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattron"
            let wattrset = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattrset"
            let wattr_get = Platform.getDelegate<WinPtr_Attr_tRef_CShortRef_CVoidPtr_CInt> loader libPtr "wattr_get"
            let wattr_off = Platform.getDelegate<WinPtr_Attr_t_CVoidPtr_CInt> loader libPtr "wattr_off"
            let wattr_on = Platform.getDelegate<WinPtr_Attr_t_CVoidPtr_CInt> loader libPtr "wattr_on"
            let wattr_set = Platform.getDelegate<WinPtr_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "wattr_set"
            let wbkgdset = Platform.getDelegate<WinPtr_ChType_CVoid> loader libPtr "wbkgdset"
            let wbkgd = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wbkgd"
            let wborder = Platform.getDelegate<WinPtr_ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt> loader libPtr "wborder"
            let wchgat = Platform.getDelegate<WinPtr_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "wchgat"
            let wclear = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclear"
            let wclrtobot = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclrtobot"
            let wclrtoeol = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclrtoeol"
            let wcolor_set = Platform.getDelegate<WinPtr_CShort_CVoidPtr_CInt> loader libPtr "wcolor_set"
            let wcursyncup = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wcursyncup"
            let wdelch = Platform.getDelegate<WinPtr_CInt> loader libPtr "wdelch"
            let wdeleteln = Platform.getDelegate<WinPtr_CInt> loader libPtr "wdeleteln"
            let wechochar = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wechochar"
            let werase = Platform.getDelegate<WinPtr_CInt> loader libPtr "werase"
            let wgetch = Platform.getDelegate<WinPtr_CInt> loader libPtr "wgetch"
            let wgetnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "wgetnstr"
            let wgetstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "wgetstr"
            let whline = Platform.getDelegate<WinPtr_ChType_CInt_CInt> loader libPtr "whline"
            let winchnstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt_CInt> loader libPtr "winchnstr"
            let winchstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt> loader libPtr "winchstr"
            let winch = Platform.getDelegate<WinPtr_ChType> loader libPtr "winch"
            let winnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winnstr"
            let winsch = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "winsch"
            let winsdelln = Platform.getDelegate<WinPtr_CInt_CInt> loader libPtr "winsdelln"
            let winsertln = Platform.getDelegate<WinPtr_CInt> loader libPtr "winsertln"
            let winsnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "winsnstr"
            let winsstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winsstr"
            let winstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winstr"
            let wmove = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wmove"
            let wnoutrefresh = Platform.getDelegate<WinPtr_CInt> loader libPtr "wnoutrefresh"
            let wprintw = Platform.getDelegate<WinPtr_CCharPtr_Args_CInt> loader libPtr "wprintw"
            let wredrawln = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wredrawln"
            let wrefresh = Platform.getDelegate<WinPtr_CInt> loader libPtr "wrefresh"
            let wscanw = Platform.getDelegate<WinPtr_CCharPtr_Args_CInt> loader libPtr "wscanw"
            let wscrl = Platform.getDelegate<WinPtr_CInt_CInt> loader libPtr "wscrl"
            let wsetscrreg = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wsetscrreg"
            let wstandend = Platform.getDelegate<WinPtr_CInt> loader libPtr "wstandend"
            let wstandout = Platform.getDelegate<WinPtr_CInt> loader libPtr "wstandout"
            let wsyncdown = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wsyncdown"
            let wsyncup = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wsyncup"
            let wtimeout = Platform.getDelegate<WinPtr_CInt_CVoid> loader libPtr "wtimeout"
            let wtouchln = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt> loader libPtr "wtouchln"
            let wvline = Platform.getDelegate<WinPtr_ChType_CInt_CInt> loader libPtr "wvline"

            // Quasi-standard functions

            let getyx = Platform.getDelegate<WinPtr_CIntRef_CIntRef_CVoid> loader libPtr "getyx" 
            let getparyx = Platform.getDelegate<WinPtr_CIntRef_CIntRef_CVoid> loader libPtr "getparyx"
            let getbegyx = Platform.getDelegate<WinPtr_CIntRef_CIntRef_CVoid> loader libPtr "getbegyx"
            let getmaxyx = Platform.getDelegate<WinPtr_CIntRef_CIntRef_CVoid> loader libPtr "getmaxyx"
            let getsyx = Platform.getDelegate<CIntRef_CIntRef_CVoid> loader libPtr "getsyx"
            let setsyx = Platform.getDelegate<CInt_CInt_CVoid> loader libPtr "setsyx"
            let getbegx = Platform.getDelegate<WinPtr_CInt> loader libPtr "getbegx"
            let getbegy = Platform.getDelegate<WinPtr_CInt> loader libPtr "getbegy"
            let getmaxx = Platform.getDelegate<WinPtr_CInt> loader libPtr "getmaxx"
            let getmaxy = Platform.getDelegate<WinPtr_CInt> loader libPtr "getmaxy"
            let getparx = Platform.getDelegate<WinPtr_CInt> loader libPtr "getparx"
            let getpary = Platform.getDelegate<WinPtr_CInt> loader libPtr "getpary"
            let getcurx = Platform.getDelegate<WinPtr_CInt> loader libPtr "getcurx"
            let getcury = Platform.getDelegate<WinPtr_CInt> loader libPtr "getcury"

        // Imported variable getters

        let LINES () = Platform.getCInt loader libPtr "LINES"
        let COLS () = Platform.getCInt loader libPtr "COLS"
        let stdscr () = Platform.getWinPtr loader libPtr "stdscr"
        let curscr () = Platform.getWinPtr loader libPtr "curscr"
        let SP () = Platform.getScrPtr loader libPtr "SP"
        let Mouse_status () = Platform.getMOUSE_STATUS loader libPtr "MOUSE_STATUS"
        let COLORS () = Platform.getCInt loader libPtr "COLORS"
        let COLOR_PAIRS () = Platform.getCInt loader libPtr "COLOR_PAIRS"
        let TABSIZE () = Platform.getCInt loader libPtr "TABSIZE"
        let acs_map () = Platform.getChTypeArray loader libPtr "acs_map"
        let ttytype () = Platform.getCCharArray loader libPtr "ttytype"

        // Wrapped delegates

        let addch ch = Delegate.addch.Invoke(ch)
        let addchnstr ch n = Delegate.addchnstr.Invoke(ch, n)
        let addchstr ch = Delegate.addchstr.Invoke(ch)
        let addnstr str n = Delegate.addnstr.Invoke(str, n)
        let addstr str = Delegate.addstr.Invoke(str)
        let attroff attrs = Delegate.attroff.Invoke(attrs)
        let attron attrs = Delegate.attron.Invoke(attrs)
        let attrset attrs = Delegate.attrset.Invoke(attrs)
        let attr_get () =
            let mutable attrs = 0u
            let mutable color_pair = 0s
            match Delegate.attr_get.Invoke(&attrs, &color_pair, NULL) with
            | OK -> Some (attrs, color_pair)
            | _ -> None
        let attr_off attrs = Delegate.attr_off.Invoke(attrs, NULL)
        let attr_on attrs = Delegate.attr_on.Invoke(attrs, NULL)
        let attr_set attrs pair = Delegate.attr_set.Invoke(attrs, pair, NULL)
        let baudrate () = Delegate.baudrate.Invoke()
        let beep () = Delegate.beep.Invoke()
        let bkgd ch = Delegate.bkgd.Invoke(ch)
        let bkgdset ch = Delegate.bkgdset.Invoke(ch)
        let border ls rs ts bs tl tr bl br = Delegate.border.Invoke(ls, rs, ts, bs, tl, tr, bl, br)
        let box win verch horch = Delegate.box.Invoke(win, verch, horch)
        let can_change_color () = Delegate.can_change_color.Invoke()
        let cbreak () = Delegate.cbreak.Invoke()
        let chgat n attr color opts = Delegate.chgat.Invoke(n, attr, color, opts)
        let clearok win bf = Delegate.clearok.Invoke(win, bf)
        let clear () = Delegate.clear.Invoke()
        let clrtobot () = Delegate.clrtobot.Invoke()
        let clrtoeol () = Delegate.clrtoeol.Invoke()
        let color_content color =
            let mutable r = 0s
            let mutable g = 0s
            let mutable b = 0s
            match Delegate.color_content.Invoke(color, &r, &g, &b) with
            | OK -> Some (r,g,b)
            | _ -> None   
        let color_set color_pair_number opts = Delegate.color_set.Invoke(color_pair_number, opts)
        let copywin scrwin dstwin sminrow smincol dminrow dmincol dmaxrow dmaxcol overlay = Delegate.copywin.Invoke(scrwin, dstwin, sminrow, smincol, dminrow, dmincol, dmaxrow, dmaxcol, overlay)
        let curs_set visibility = Delegate.curs_set.Invoke(visibility)
        let def_prog_mode () = Delegate.def_prog_mode.Invoke()
        let def_shell_mode () = Delegate.def_shell_mode.Invoke()
        let delay_output ms = Delegate.delay_output.Invoke(ms)
        let delch () = Delegate.delch.Invoke()
        let deleteln () = Delegate.deleteln.Invoke()
        let delscreen sp = Delegate.delscreen.Invoke(sp)
        let delwin win = Delegate.delwin.Invoke(win)
        let derwin orig nlines ncols begin_y begin_x = Delegate.derwin.Invoke(orig, nlines, ncols, begin_y, begin_x)
        let doupdate () = Delegate.doupdate.Invoke()
        let dupwin win = Delegate.dupwin.Invoke(win)
        let echochar ch = Delegate.echochar.Invoke(ch)
        let echo () = Delegate.echo.Invoke()
        let endwin () = Delegate.endwin.Invoke()
        let erasechar () = Delegate.erasechar.Invoke()
        let erase () = Delegate.erase.Invoke()
        let filter () = Delegate.filter.Invoke()
        let flash () = Delegate.flash.Invoke()
        let flushinp () = Delegate.flushinp.Invoke()
        let getbkgd win = Delegate.getbkgd.Invoke(win)
        let getnstr (n:CInt) = 
            // http://stackoverflow.com/questions/12273961/release-unmanaged-memory-from-managed-c-sharp-with-pointer-of-it
            // http://stackoverflow.com/questions/11508260/passing-stringbuilder-to-dll-function-expecting-char-pointer
            let buffer = Array.zeroCreate<byte> (int n)
            match Delegate.getnstr.Invoke(buffer, n) with
            | OK -> Some (Encoding.ASCII.GetString(buffer))
            | _ -> None
        let getstr () = 
            // getstr is dangerous - it can be the cause of buffer 
            // overruns because it cannot know the size of the buffer being
            // used. Use getnstr instead which passes in the buffer size.
            getnstr BUFFER_SIZE
        let getwin filep = Delegate.getwin.Invoke(filep)
        let halfdelay tenths = Delegate.halfdelay.Invoke(tenths)
        let has_colors () = Delegate.has_colors.Invoke()
        let has_ic () = Delegate.has_ic.Invoke()
        let has_il () = Delegate.has_il.Invoke()
        let hline ch n = Delegate.hline.Invoke(ch, n)
        let idcok win bf = Delegate.idcok.Invoke(win, bf)
        let idlok win bf = Delegate.idlok.Invoke(win, bf)
        let immedok win bf = Delegate.immedok.Invoke(win, bf)
        //let inchnstr = Delegate.inchnstr.Invoke() // <ChTypePtr_CInt_CInt>
        //let inchstr = Delegate.inchstr.Invoke() // <ChTypePtr_CInt>
        let inch () = Delegate.inch.Invoke()
        let init_color color r g b = Delegate.init_color.Invoke(color, r, g, b)
        let init_pair pair f b = Delegate.init_pair.Invoke(pair, f, b)
        let initscr () = Delegate.initscr.Invoke()
        //let innstr = Delegate.innstr.Invoke() // <CCharPtr_CInt_CInt>
        let insch ch = Delegate.insch.Invoke(ch)
        let insdelln n = Delegate.insdelln.Invoke(n)
        let insertln () = Delegate.insertln.Invoke()
        let insnstr str n = Delegate.insnstr.Invoke(str, n)
        let insstr str = Delegate.insstr.Invoke(str)
        //let instr = Delegate.instr.Invoke() // <CCharPtr_CInt>
        let intrflush win bf = Delegate.intrflush.Invoke(win, bf)
        let isendwin () = Delegate.isendwin.Invoke()
        let is_linetouched win line = Delegate.is_linetouched.Invoke(win, line)
        let is_wintouched win = Delegate.is_wintouched.Invoke(win)
        let keyname c = Delegate.keyname.Invoke(c)
        let keypad win bf = Delegate.keypad.Invoke(win, bf)
        let killchar () = Delegate.killchar.Invoke()
        let leaveok win bf = Delegate.leaveok.Invoke(win, bf)
        let longname () = Delegate.longname.Invoke()
        let meta win bf = Delegate.meta.Invoke(win, bf)
        let move y x = Delegate.move.Invoke(y, x)
        let mvaddch y x ch = Delegate.mvaddch.Invoke(y, x, ch)
        let mvaddchnstr y x chstr n = Delegate.mvaddchnstr.Invoke(y, x, chstr, n)
        let mvaddchstr y x chstr = Delegate.mvaddchstr.Invoke(y, x, chstr)
        let mvaddnstr y x str n = Delegate.mvaddnstr.Invoke(y, x, str, n)
        let mvaddstr y x str = Delegate.mvaddstr.Invoke(y, x, str)
        let mvchgat y x n attr color opts = Delegate.mvchgat.Invoke(y, x, n, attr, color, opts)
        let mvcur oldrow oldcol newrow newcol = Delegate.mvcur.Invoke(oldrow, oldcol, newrow, newcol)
        let mvdelch y x = Delegate.mvdelch.Invoke(y, x)
        let mvderwin win par_y par_x = Delegate.mvderwin.Invoke(win, par_y, par_x)
        let mvgetch y x = Delegate.mvgetch.Invoke(y, x)
        //let mvgetnstr = Delegate.mvgetnstr.Invoke() // <CInt_CInt_CCharPtr_CInt_CInt>
        //let mvgetstr = Delegate.mvgetstr.Invoke() // <CInt_CInt_CCharPtr_CInt>
        let mvhline y x ch n = Delegate.mvhline.Invoke(y, x, ch, n)
        let mvinch y x = Delegate.mvinch.Invoke(y, x)
        //let mvinchnstr = Delegate.mvinchnstr.Invoke() // <CInt_CInt_ChTypePtr_CInt_CInt>
        //let mvinchstr = Delegate.mvinchstr.Invoke() // <CInt_CInt_ChTypePtr_CInt>
        //let mvinnstr = Delegate.mvinnstr.Invoke() // <CInt_CInt_CCharPtr_CInt_CInt>
        let mvinsch y x ch = Delegate.mvinsch.Invoke(y, x, ch)
        let mvinsnstr y x str n = Delegate.mvinsnstr.Invoke(y, x, str, n)
        let mvinsstr y x str = Delegate.mvinsstr.Invoke(y, x, str)
        //let mvinstr = Delegate.mvinstr.Invoke() // <CInt_CInt_CCharPtr_CInt>
        //let mvprintw = Delegate.mvprintw.Invoke() // <CInt_CInt_CCharPtr_Args_CInt>
        //let mvscanw = Delegate.mvscanw.Invoke() // <CInt_CInt_CCharPtr_Args_CInt>
        let mvvline y x ch n = Delegate.mvvline.Invoke(y, x, ch, n)
        let mvwaddchnstr win y x chstr n = Delegate.mvwaddchnstr.Invoke(win, y, x, chstr, n)
        let mvwaddchstr win y x chstr = Delegate.mvwaddchstr.Invoke(win, y, x, chstr)
        let mvwaddch win y x ch = Delegate.mvwaddch.Invoke(win, y, x, ch)
        let mvwaddnstr win y x str n = Delegate.mvwaddnstr.Invoke(win, y, x, str, n)
        let mvwaddstr win y x str = Delegate.mvwaddstr.Invoke(win, y, x, str)
        let mvwchgat win y x n attr color opts = Delegate.mvwchgat.Invoke(win, y, x, n, attr, color, opts)
        let mvwdelch win y x = Delegate.mvwdelch.Invoke(win, y, x)
        let mvwgetch win y x = Delegate.mvwgetch.Invoke(win, y, x)
        //let mvwgetnstr = Delegate.mvwgetnstr.Invoke() // <WinPtr_CInt_CInt_CCharPtr_CInt_CInt>
        //let mvwgetstr = Delegate.mvwgetstr.Invoke() // <WinPtr_CInt_CInt_CCharPtr_CInt>
        let mvwhline win y x ch n = Delegate.mvwhline.Invoke(win, y, x, ch, n)
        //let mvwinchnstr = Delegate.mvwinchnstr.Invoke() // <WinPtr_CInt_CInt_ChTypePtr_CInt_CInt>
        //let mvwinchstr = Delegate.mvwinchstr.Invoke() // <WinPtr_CInt_CInt_ChTypePtr_CInt>
        let mvwinch win y x = Delegate.mvwinch.Invoke(win, y, x)
        //let mvwinnstr = Delegate.mvwinnstr.Invoke() // <WinPtr_CInt_CInt_CCharPtr_CInt_CInt>
        let mvwinsch win y x ch = Delegate.mvwinsch.Invoke(win, y, x, ch)
        let mvwinsnstr win y x str n = Delegate.mvwinsnstr.Invoke(win, y, x, str, n)
        let mvwinsstr win y x str = Delegate.mvwinsstr.Invoke(win, y, x, str)
        //let mvwinstr = Delegate.mvwinstr.Invoke() // <WinPtr_CInt_CInt_CCharPtr_CInt>
        let mvwin win y x = Delegate.mvwin.Invoke(win y x)
        //let mvwprintw = Delegate.mvwprintw.Invoke() // <WinPtr_CInt_CInt_CCharPtr_Args_CInt>
        //let mvwscanw = Delegate.mvwscanw.Invoke() // <WinPtr_CInt_CInt_CCharPtr_Args_CInt>
        let mvwvline win y x ch n = Delegate.mvwvline.Invoke(win, y, x, ch, n)
        let napms ms = Delegate.napms.Invoke(ms)
        let newpad nlines ncols = Delegate.newpad.Invoke(nlines, ncols)
        let newterm ``type`` outfd infd = Delegate.newterm.Invoke(``type``, outfd, infd)
        let newwin nlines ncols begin_y begin_x = Delegate.newwin.Invoke(nlines, ncols, begin_y, begin_x)
        let nl () = Delegate.nl.Invoke()
        let nocbreak () = Delegate.nocbreak.Invoke()
        let nodelay win bf = Delegate.nodelay.Invoke(win, bf)
        let noecho () = Delegate.noecho.Invoke()
        let nonl () = Delegate.nonl.Invoke()
        let noqiflush () = Delegate.noqiflush.Invoke()
        let noraw () = Delegate.noraw.Invoke()
        let notimeout win bf = Delegate.notimeout.Invoke(win, bf)
        let overlay scrwin dstwin = Delegate.overlay.Invoke(scrwin, dstwin)
        let overwrite scrwin dstwin = Delegate.overwrite.Invoke(scrwin, dstwin)
        let pair_content pair =
            let mutable f = 0s
            let mutable b = 0s
            match Delegate.pair_content.Invoke(pair, &f, &b) with
            | OK -> Some (f, b)
            | _ -> None
        let pechochar pad ch = Delegate.pechochar.Invoke(pad, ch)
        let pnoutrefresh pad pminrow pmincol sminrow smincol smaxrow smaxcol = Delegate.pnoutrefresh.Invoke(pad, pminrow, pmincol, sminrow, smincol, smaxrow, smaxcol)
        let prefresh pad pminrow pmincol sminrow smincol smaxrow smaxcol = Delegate.prefresh.Invoke(pad, pminrow, pmincol, sminrow, smincol, smaxrow, smaxcol)
        //let printw = Delegate.printw.Invoke() // <CCharPtr_Args_CInt>
        let putwin win filep = Delegate.putwin.Invoke(win, filep)
        let qiflush () = Delegate.qiflush.Invoke()
        let raw () = Delegate.raw.Invoke()
        let redrawwin win = Delegate.redrawwin.Invoke(win)
        let refresh () = Delegate.refresh.Invoke()
        let reset_prog_mode () = Delegate.reset_prog_mode.Invoke()
        let reset_shell_mode () = Delegate.reset_shell_mode.Invoke()
        let resetty () = Delegate.resetty.Invoke()
        //let ripoffline = Delegate.ripoffline.Invoke() // <CInt_f_CInt_WinPtr_CInt_CInt>
        let savetty () = Delegate.savetty.Invoke()
        //let scanw = Delegate.scanw.Invoke() // <CCharPtr_Args_CInt>
        let scr_dump filename = Delegate.scr_dump.Invoke(filename)
        let scr_init filename = Delegate.scr_init.Invoke(filename)
        let scr_restore filename = Delegate.scr_restore.Invoke(filename)
        let scr_set filename = Delegate.scr_set.Invoke(filename)
        let scrl n = Delegate.scrl.Invoke(n)
        let scroll win = Delegate.scroll.Invoke(win)
        let scrollok win bf = Delegate.scrollok.Invoke(win, bf)
        let set_term ``new`` = Delegate.set_term.Invoke(``new``)
        let setscrreg top bot = Delegate.setscrreg.Invoke(top, bot)
        let slk_attroff attrs = Delegate.slk_attroff.Invoke(attrs)
        let slk_attr_off attrs opts = Delegate.slk_attr_off.Invoke(attrs, opts)
        let slk_attron attrs = Delegate.slk_attron.Invoke(attrs)
        let slk_attr_on attrs opts = Delegate.slk_attr_on.Invoke(attrs, opts)
        let slk_attrset attrs = Delegate.slk_attrset.Invoke(attrs)
        let slk_attr_set attrs color_pair_number opts = Delegate.slk_attr_set.Invoke(attrs, color_pair_number, opts)
        let slk_clear () = Delegate.slk_clear.Invoke()
        let slk_color color_pair_number = Delegate.slk_color.Invoke(color_pair_number)
        let slk_init fmt = Delegate.slk_init.Invoke(fmt)
        let slk_label labnum = Delegate.slk_label.Invoke(labnum)
        let slk_noutrefresh () = Delegate.slk_noutrefresh.Invoke()
        let slk_refresh () = Delegate.slk_refresh.Invoke()
        let slk_restore () = Delegate.slk_restore.Invoke()
        let slk_set labnum label fmt = Delegate.slk_set.Invoke(labnum, label, fmt)
        let slk_touch () = Delegate.slk_touch.Invoke()
        let standend () = Delegate.standend.Invoke()
        let standout () = Delegate.standout.Invoke()
        let start_color () = Delegate.start_color.Invoke()
        let subpad orig nlines ncols begin_y begin_x = Delegate.subpad.Invoke(orig, nlines, ncols, begin_y, begin_x)
        let subwin orig nlines ncols begin_y begin_x = Delegate.subwin.Invoke(orig, nlines, ncols, begin_y, begin_x)
        let syncok win bf = Delegate.syncok.Invoke(win, bf)
        let termattrs () = Delegate.termattrs.Invoke()
        let term_attrs () = Delegate.term_attrs.Invoke()
        let termname () = Delegate.termname.Invoke()
        let timeout delay = Delegate.timeout.Invoke(delay)
        let touchline win start count = Delegate.touchline.Invoke(win, start, count)
        let touchwin win = Delegate.touchwin.Invoke(win)
        let typeahead fd = Delegate.typeahead.Invoke(fd)
        let untouchwin win = Delegate.untouchwin.Invoke(win)
        let use_env f = Delegate.use_env.Invoke(f)
        let vidattr attrs = Delegate.vidattr.Invoke(attrs)
        let vid_attr attrs pair opts = Delegate.vid_attr.Invoke(attrs, pair, opts)
        //let vidputs = Delegate.vidputs.Invoke() // <ChType_f_CInt_CInt>
        //let vid_puts = Delegate.vid_puts.Invoke() // <Attr_t_CShort_CVoidPtr_CInt_f_CInt_CInt_CInt>
        let vline ch n = Delegate.vline.Invoke(ch, n)
        //let vw_printw = Delegate.vw_printw.Invoke() // <WinPtr_CCharPtr_CVAList_CInt>
        //let vwprintw = Delegate.vwprintw.Invoke() // <WinPtr_CCharPtr_CVAList_CInt>
        //let vw_scanw = Delegate.vw_scanw.Invoke() // <WinPtr_CCharPtr_CVAList_CInt>
        //let vwscanw = Delegate.vwscanw.Invoke() // <WinPtr_CCharPtr_CVAList_CInt>
        let waddchnstr win chstr n = Delegate.waddchnstr.Invoke(win, chstr, n)
        let waddchstr win chstr = Delegate.waddchstr.Invoke(win, chstr)
        let waddch win ch = Delegate.waddch.Invoke(win, ch)
        let waddnstr win str n= Delegate.waddnstr.Invoke(win, str, n)
        let waddstr win str = Delegate.waddstr.Invoke(win, str)
        let wattroff win attrs = Delegate.wattroff.Invoke(win, attrs)
        let wattron win attrs = Delegate.wattron.Invoke(win, attrs)
        let wattrset win attrs = Delegate.wattrset.Invoke(win, attrs)
        let wattr_get win =
            let mutable attrs = 0u
            let mutable color_pair = 0s
            match Delegate.wattr_get.Invoke(win, &attrs, &color_pair, NULL) with
            | OK -> Some (attrs, color_pair)
            | _ -> None
        let wattr_off win attrs opts = Delegate.wattr_off.Invoke(win, attrs, opts)
        let wattr_on win attrs opts = Delegate.wattr_on.Invoke(win, attrs, opts)
        let wattr_set win attrs pair opts = Delegate.wattr_set.Invoke(win, attrs, pair, opts)
        let wbkgdset win ch = Delegate.wbkgdset.Invoke(win, ch)
        let wbkgd win ch = Delegate.wbkgd.Invoke(win, ch)
        let wborder win ls rs ts bs tl tr bl br = Delegate.wborder.Invoke(win, ls, rs, ts, bs, tl, tr, bl, br)
        let wchgat win n attr color opts = Delegate.wchgat.Invoke(win n attr color opts)
        let wclear win = Delegate.wclear.Invoke(win)
        let wclrtobot win = Delegate.wclrtobot.Invoke(win)
        let wclrtoeol win = Delegate.wclrtoeol.Invoke(win)
        let wcolor_set win color_pair_number opts = Delegate.wcolor_set.Invoke(win, color_pair_number, opts)
        let wcursyncup win = Delegate.wcursyncup.Invoke(win)
        let wdelch win = Delegate.wdelch.Invoke(win)
        let wdeleteln win = Delegate.wdeleteln.Invoke(win)
        let wechochar win ch = Delegate.wechochar.Invoke(win, ch)
        let werase win = Delegate.werase.Invoke(win)
        let wgetch win = Delegate.wgetch.Invoke(win)
        //let wgetnstr = Delegate.wgetnstr.Invoke() // <WinPtr_CCharPtr_CInt_CInt>
        //let wgetstr = Delegate.wgetstr.Invoke() // <WinPtr_CCharPtr_CInt>
        let whline win ch n = Delegate.whline.Invoke(win, ch, n)
        //let winchnstr = Delegate.winchnstr.Invoke() // <WinPtr_ChTypePtr_CInt_CInt>
        //let winchstr = Delegate.winchstr.Invoke() // <WinPtr_ChTypePtr_CInt>
        let winch win = Delegate.winch.Invoke(win)
        //let winnstr = Delegate.winnstr.Invoke() // <WinPtr_CCharPtr_CInt>
        let winsch win ch = Delegate.winsch.Invoke(win, ch)
        let winsdelln win n = Delegate.winsdelln.Invoke(win, n)
        let winsertln win = Delegate.winsertln.Invoke(win)
        let winsnstr win str n = Delegate.winsnstr.Invoke(win, str, n)
        let winsstr win str = Delegate.winsstr.Invoke(win, str)
        //let winstr = Delegate.winstr.Invoke() // <WinPtr_CCharPtr_CInt>
        let wmove win y x = Delegate.wmove.Invoke(win, y, x)
        let wnoutrefresh win = Delegate.wnoutrefresh.Invoke(win)
        //let wprintw = Delegate.wprintw.Invoke() // <WinPtr_CCharPtr_Args_CInt>
        let wredrawln win beg_line num_lines = Delegate.wredrawln.Invoke(win, beg_line, num_lines)
        let wrefresh win = Delegate.wrefresh.Invoke(win)
        //let wscanw = Delegate.wscanw.Invoke() // <WinPtr_CCharPtr_Args_CInt>
        let wscrl win n = Delegate.wscrl.Invoke(win, n)
        let wsetscrreg win top bot = Delegate.wsetscrreg.Invoke(win, top, bot)
        let wstandend win = Delegate.wstandend.Invoke(win)
        let wstandout win = Delegate.wstandout.Invoke(win)
        let wsyncdown win = Delegate.wsyncdown.Invoke(win)
        let wsyncup win = Delegate.wsyncup.Invoke(win)
        let wtimeout win delay = Delegate.wtimeout.Invoke(win, delay)
        let wtouchln win y n changed = Delegate.wtouchln.Invoke(win, y, n, changed)
        let wvline win ch n = Delegate.wvline.Invoke(win, ch, n)
        let getyx win =
            let mutable y = 0s
            let mutable x = 0s
            Delegate.getyx.Invoke(win, &y, &x)
            y,x
        let getparyx win =
            let mutable y = 0s
            let mutable x = 0s
            Delegate.getparyx.Invoke(win, &y, &x)
            y,x
        let getbegyx win =
            let mutable y = 0s
            let mutable x = 0s
            Delegate.getbegyx.Invoke(win, &y, &x)
            y,x
        let getmaxyx win =
            let mutable y = 0s
            let mutable x = 0s
            Delegate.getmaxyx.Invoke(win, &y, &x)
            y,x
        let getsyx () =
            let mutable y = 0s
            let mutable x = 0s
            Delegate.getsyx.Invoke(&y, &x)
            y,x
        let setsyx y x = Delegate.setsyx.Invoke(y, x)
        let getbegx win = Delegate.getbegx.Invoke(win)
        let getbegy win = Delegate.getbegy.Invoke(win)
        let getmaxx win = Delegate.getmaxx.Invoke(win)
        let getmaxy win = Delegate.getmaxy.Invoke(win)
        let getparx win = Delegate.getparx.Invoke(win)
        let getpary win = Delegate.getpary.Invoke(win)
        let getcurx win = Delegate.getcurx.Invoke(win)
        let getcury win = Delegate.getcury.Invoke(win)

    module Check =

        let cptrResult fname result =
            if result = NULL 
            then Result.error (sprintf "%s returned NULL" fname)
            else Result.result result

        let cintResult fname result = 
            if result = ERR
            then Result.error (sprintf "%s returned ERR" fname)
            else Result.result result

        let unitResult fname result = 
            if result = ERR
            then Result.error (sprintf "%s returned ERR" fname)
            else Result.result ()

        let optionResult fname result =
            match result with
            | Some x -> Result.result x
            | _ -> Result.error (sprintf "%s returned none" fname)

    let initscr () = Imported.initscr() |> Check.cptrResult "initscr"
    // TODO: getch incompatible with windows? use wgetch instead
    let getch () = raise <| NotImplementedException()
    let wgetch win = Imported.wgetch(win) |> Check.cintResult "wgetch"
    let addch (ch:char) = Imported.addch(System.Convert.ToUInt32 ch) |> Check.unitResult "addch"
    let napms ms = Imported.napms(ms) |> Check.unitResult "napms"
    let refresh () = Imported.refresh() |> Check.unitResult "refresh"
    let endwin () = Imported.endwin() |> Check.cintResult "endwin"
    let getmaxyx win = Imported.getmaxyx win |> Result.result
    let getstr () = Imported.getstr() |> Check.optionResult "getstr"