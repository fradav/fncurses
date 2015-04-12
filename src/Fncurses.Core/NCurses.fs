namespace Fncurses.Core

[<AutoOpen>]
module NCurses = 

    open System
    open System.Reflection
    open System.Runtime.InteropServices    

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

    [<AutoOpen>]
    module Types =
       
        type ChType = System.UInt32
        type Args = obj array
        type Attr_t = ChType
        type Attr_tPtr = IntPtr
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
        type Attr_tPtr_CShortPtr_CVoidPtr_CInt = delegate of Attr_tPtr * CShortPtr * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CBool_CVoid = delegate of CBool -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_Args_CInt = delegate of CCharPtr * Args -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CInt = delegate of CCharPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CCharPtr_CInt_CInt = delegate of CCharPtr * CInt -> CInt
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
        type CInt_CInt_WinPtr = delegate of CInt * CInt -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CInt_CVoid = delegate of CInt -> CVoid
        //[<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        //type CInt_f_CInt_WinPtr_CInt_CInt = delegate of CInt * f * CInt * WinPtr * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CInt = delegate of CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShort_CShort_CInt = delegate of CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShort_CShort_CShort_CInt = delegate of CShort * CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShortPtr_CShortPtr_CInt = delegate of CShort * CShortPtr * CShortPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type CShort_CShortPtr_CShortPtr_CShortPtr_CInt = delegate of CShort * CShortPtr * CShortPtr * CShortPtr -> CInt
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
        type WinPtr_Attr_tPtr_CShortPtr_CVoidPtr_CInt = delegate of WinPtr * Attr_tPtr * CShortPtr * CVoidPtr -> CInt
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
        let private libPtr = loader.LoadLibrary(dllPath)

        module private Delegate =

            // int     addch(const ChType);
            let addch = Platform.getDelegate<ChType_CInt> loader libPtr "addch"
            // int     addchnstr(const ChType *, int);
            let addchnstr = Platform.getDelegate<ChTypePtr_CInt_CInt> loader libPtr "addchnstr"
            // int     addchstr(const ChType *);
            let addchstr = Platform.getDelegate<ChTypePtr_CInt> loader libPtr "addchstr"
            // int     addnstr(const char *, int);
            let addnstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "addnstr"
            // int     addstr(const char *);
            let addstr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "addstr"
            // int     attroff(ChType);
            let attroff = Platform.getDelegate<ChType_CInt> loader libPtr "attroff"
            // int     attron(ChType);
            let attron = Platform.getDelegate<ChType_CInt> loader libPtr "attron"
            // int     attrset(ChType);
            let attrset = Platform.getDelegate<ChType_CInt> loader libPtr "attrset"
            // int     attr_get(attr_t *, short *, void *);
            let attr_get = Platform.getDelegate<Attr_tPtr_CShortPtr_CVoidPtr_CInt> loader libPtr "attr_get"
            // int     attr_off(attr_t, void *);
            let attr_off = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "attr_off"
            // int     attr_on(attr_t, void *);
            let attr_on = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "attr_on"
            // int     attr_set(attr_t, short, void *);
            let attr_set = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "attr_set"
            // int     baudrate(void);
            let baudrate = Platform.getDelegate<CVoid_CInt> loader libPtr "baudrate"
            // int     beep(void);
            let beep = Platform.getDelegate<CVoid_CInt> loader libPtr "beep"
            // int     bkgd(ChType);
            let bkgd = Platform.getDelegate<ChType_CInt> loader libPtr "bkgd"
            // void    bkgdset(ChType);
            let bkgdset = Platform.getDelegate<ChType_CVoid> loader libPtr "bkgdset"
            // int     border(ChType, ChType, ChType, ChType, ChType, ChType, ChType, ChType);
            let border = Platform.getDelegate<ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt> loader libPtr "border"
            // int     box(WINDOW *, ChType, ChType);
            let box = Platform.getDelegate<WinPtr_ChType_ChType_CInt> loader libPtr "box"
            // bool    can_change_color(void);
            let can_change_color = Platform.getDelegate<CVoid_CBool> loader libPtr "can_change_color"
            // int     cbreak(void); 
            let cbreak = Platform.getDelegate<CVoid_CInt> loader libPtr "cbreak"
            // int     chgat(int, attr_t, short, const void *);
            let chgat = Platform.getDelegate<CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "chgat"
            // int     clearok(WINDOW *, bool);
            let clearok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "clearok"
            // int     clear(void);
            let clear = Platform.getDelegate<CVoid_CInt> loader libPtr "clear"
            // int     clrtobot(void);
            let clrtobot = Platform.getDelegate<CVoid_CInt> loader libPtr "clrtobot"
            // int     clrtoeol(void);
            let clrtoeol = Platform.getDelegate<CVoid_CInt> loader libPtr "clrtoeol"
            // int     color_content(short, short *, short *, short *);
            let color_content = Platform.getDelegate<CShort_CShortPtr_CShortPtr_CShortPtr_CInt> loader libPtr "color_content"
            // int     color_set(short, void *);
            let color_set = Platform.getDelegate<CShort_CVoidPtr_CInt> loader libPtr "color_set"
            // int     copywin(const WINDOW *, WINDOW *, int, int, int, int, int, int, int);
            let copywin = Platform.getDelegate<WinPtr_WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "copywin"
            // int     curs_set(int);
            let curs_set = Platform.getDelegate<CInt_CInt> loader libPtr "curs_set"
            // int     def_prog_mode(void);
            let def_prog_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "def_prog_mode"
            // int     def_shell_mode(void);
            let def_shell_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "def_shell_mode"
            // int     delay_output(int);
            let delay_output = Platform.getDelegate<CInt_CInt> loader libPtr "delay_output"
            // int     delch(void);
            let delch = Platform.getDelegate<CVoid_CInt> loader libPtr "delch"
            // int     deleteln(void);
            let deleteln = Platform.getDelegate<CVoid_CInt> loader libPtr "deleteln"
            // void    delscreen(SCREEN *); 
            let delscreen = Platform.getDelegate<ScrPtr_CVoid> loader libPtr "delscreen"
            // int     delwin(WINDOW *);
            let delwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "delwin"
            // WINDOW *derwin(WINDOW *, int, int, int, int);
            let derwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt> loader libPtr "derwin"
            // int     doupdate(void);
            let doupdate = Platform.getDelegate<CVoid_CInt> loader libPtr "doupdate"
            // WINDOW *dupwin(WINDOW *);
            let dupwin = Platform.getDelegate<WinPtr_WinPtr> loader libPtr "dupwin"
            // int     echochar(const ChType);
            let echochar = Platform.getDelegate<ChType_CInt> loader libPtr "echochar"
            // int     echo(void);
            let echo = Platform.getDelegate<CVoid_CInt> loader libPtr "echo"
            // int     endwin(void);
            let endwin = Platform.getDelegate<CVoid_CInt> loader libPtr "endwin"
            // char    erasechar(void);
            let erasechar = Platform.getDelegate<CVoid_CChar> loader libPtr "erasechar"
            // int     erase(void);
            let erase = Platform.getDelegate<CVoid_CInt> loader libPtr "erase"
            // void    filter(void);
            let filter = Platform.getDelegate<CVoid_CVoid> loader libPtr "filter"
            // int     flash(void);
            let flash = Platform.getDelegate<CVoid_CInt> loader libPtr "flash"
            // int     flushinp(void);
            let flushinp = Platform.getDelegate<CVoid_CInt> loader libPtr "flushinp"
            // ChType  getbkgd(WINDOW *);
            let getbkgd = Platform.getDelegate<WinPtr_ChType> loader libPtr "getbkgd"
            // int     getnstr(char *, int);
            let getnstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "getnstr"
            // int     getstr(char *);
            let getstr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "getstr"
            // WINDOW *getwin(FILE *);
            let getwin = Platform.getDelegate<CFilePtr_WinPtr> loader libPtr "getwin"
            // int     halfdelay(int);
            let halfdelay = Platform.getDelegate<CInt_CInt> loader libPtr "halfdelay"
            // bool    has_colors(void);
            let has_colors = Platform.getDelegate<CVoid_CBool> loader libPtr "has_colors"
            // bool    has_ic(void);
            let has_ic = Platform.getDelegate<CVoid_CBool> loader libPtr "has_ic"
            // bool    has_il(void);
            let has_il = Platform.getDelegate<CVoid_CBool> loader libPtr "has_il"
            // int     hline(ChType, int);
            let hline = Platform.getDelegate<ChType_CInt_CInt> loader libPtr "hline"
            // void    idcok(WINDOW *, bool);
            let idcok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "idcok"
            // int     idlok(WINDOW *, bool);
            let idlok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "idlok"
            // void    immedok(WINDOW *, bool);
            let immedok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "immedok"
            // int     inchnstr(ChType *, int);
            let inchnstr = Platform.getDelegate<ChTypePtr_CInt_CInt> loader libPtr "inchnstr"
            // int     inchstr(ChType *);
            let inchstr = Platform.getDelegate<ChTypePtr_CInt> loader libPtr "inchstr"
            // ChType  inch(void);
            let inch = Platform.getDelegate<CVoid_ChType> loader libPtr "inch"
            // int     init_color(short, short, short, short);
            let init_color = Platform.getDelegate<CShort_CShort_CShort_CShort_CInt> loader libPtr "init_color"
            // int     init_pair(short, short, short);
            let init_pair = Platform.getDelegate<CShort_CShort_CShort_CInt> loader libPtr "init_pair"
            // WINDOW *initscr(void);
            let initscr = Platform.getDelegate<CVoid_WinPtr> loader libPtr "initscr"
            // int     innstr(char *, int);
            let innstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "innstr"
            // int     insch(ChType);
            let insch = Platform.getDelegate<ChType_CInt> loader libPtr "insch"
            // int     insdelln(int);
            let insdelln = Platform.getDelegate<CInt_CInt> loader libPtr "insdelln"
            // int     insertln(void);
            let insertln = Platform.getDelegate<CVoid_CInt> loader libPtr "insertln"
            // int     insnstr(const char *, int);
            let insnstr = Platform.getDelegate<CCharPtr_CInt_CInt> loader libPtr "insnstr"
            // int     insstr(const char *);
            let insstr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "insstr"
            // int     instr(char *);
            let instr = Platform.getDelegate<CCharPtr_CInt> loader libPtr "instr"
            // int     intrflush(WINDOW *, bool);
            let intrflush = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "intrflush"
            // bool    isendwin(void);
            let isendwin = Platform.getDelegate<CVoid_CBool> loader libPtr "isendwin"
            // bool    is_linetouched(WINDOW *, int);
            let is_linetouched = Platform.getDelegate<WinPtr_CInt_CBool> loader libPtr "is_linetouched"
            // bool    is_wintouched(WINDOW *);
            let is_wintouched = Platform.getDelegate<WinPtr_CBool> loader libPtr "is_wintouched"
            // char   *keyname(int);
            let keyname = Platform.getDelegate<CInt_CCharPtr> loader libPtr "keyname"
            // int     keypad(WINDOW *, bool);
            let keypad = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "keypad"
            // char    killchar(void);
            let killchar = Platform.getDelegate<CVoid_CChar> loader libPtr "killchar"
            // int     leaveok(WINDOW *, bool);
            let leaveok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "leaveok"
            // char   *longname(void);
            let longname = Platform.getDelegate<CVoid_CChar> loader libPtr "longname"
            // int     meta(WINDOW *, bool);
            let meta = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "meta"
            // int     move(int, int);
            let move = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "move"
            // int     mvaddch(int, int, const ChType);
            let mvaddch = Platform.getDelegate<CInt_CInt_ChType_CInt> loader libPtr "mvaddch"
            // int     mvaddchnstr(int, int, const ChType *, int);
            let mvaddchnstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvaddchnstr"
            // int     mvaddchstr(int, int, const ChType *);
            let mvaddchstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt> loader libPtr "mvaddchstr"
            // int     mvaddnstr(int, int, const char *, int);
            let mvaddnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvaddnstr"
            // int     mvaddstr(int, int, const char *);
            let mvaddstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvaddstr"
            // int     mvchgat(int, int, int, attr_t, short, const void *);
            let mvchgat = Platform.getDelegate<CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "mvchgat"
            // int     mvcur(int, int, int, int);
            let mvcur = Platform.getDelegate<CInt_CInt_CInt_CInt_CInt> loader libPtr "mvcur"
            // int     mvdelch(int, int);
            let mvdelch = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "mvdelch"
            // int     mvderwin(WINDOW *, int, int);
            let mvderwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvderwin"
            // int     mvgetch(int, int);
            let mvgetch = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "mvgetch"
            // int     mvgetnstr(int, int, char *, int);
            let mvgetnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvgetnstr"
            // int     mvgetstr(int, int, char *);
            let mvgetstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvgetstr"
            // int     mvhline(int, int, ChType, int);
            let mvhline = Platform.getDelegate<CInt_CInt_ChType_CInt_CInt> loader libPtr "mvhline"
            // ChType  mvinch(int, int);
            let mvinch = Platform.getDelegate<CInt_CInt_ChType> loader libPtr "mvinch"
            // int     mvinchnstr(int, int, ChType *, int);
            let mvinchnstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvinchnstr"
            // int     mvinchstr(int, int, ChType *);
            let mvinchstr = Platform.getDelegate<CInt_CInt_ChTypePtr_CInt> loader libPtr "mvinchstr"
            // int     mvinnstr(int, int, char *, int);
            let mvinnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvinnstr"
            // int     mvinsch(int, int, ChType);
            let mvinsch = Platform.getDelegate<CInt_CInt_ChType_CInt> loader libPtr "mvinsch"
            // int     mvinsnstr(int, int, const char *, int);
            let mvinsnstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvinsnstr"
            // int     mvinsstr(int, int, const char *);
            let mvinsstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvinsstr"
            // int     mvinstr(int, int, char *);
            let mvinstr = Platform.getDelegate<CInt_CInt_CCharPtr_CInt> loader libPtr "mvinstr"
            // int     mvprintw(int, int, const char *, ...);
            let mvprintw = Platform.getDelegate<CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvprintw"
            // int     mvscanw(int, int, const char *, ...);
            let mvscanw = Platform.getDelegate<CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvscanw"
            // int     mvvline(int, int, ChType, int);
            let mvvline = Platform.getDelegate<CInt_CInt_ChType_CInt_CInt> loader libPtr "mvvline"
            // int     mvwaddchnstr(WINDOW *, int, int, const ChType *, int);
            let mvwaddchnstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvwaddchnstr"
            // int     mvwaddchstr(WINDOW *, int, int, const ChType *);
            let mvwaddchstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt> loader libPtr "mvwaddchstr"
            // int     mvwaddch(WINDOW *, int, int, const ChType);
            let mvwaddch = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt> loader libPtr "mvwaddch"
            // int     mvwaddnstr(WINDOW *, int, int, const char *, int);
            let mvwaddnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwaddnstr"
            // int     mvwaddstr(WINDOW *, int, int, const char *);
            let mvwaddstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwaddstr"
            // int     mvwchgat(WINDOW *, int, int, int, attr_t, short, const void *);
            let mvwchgat = Platform.getDelegate<WinPtr_CInt_CInt_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "mvwchgat"
            // int     mvwdelch(WINDOW *, int, int);
            let mvwdelch = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwdelch"
            // int     mvwgetch(WINDOW *, int, int);
            let mvwgetch = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwgetch"
            // int     mvwgetnstr(WINDOW *, int, int, char *, int);
            let mvwgetnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwgetnstr"
            // int     mvwgetstr(WINDOW *, int, int, char *);
            let mvwgetstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwgetstr"
            // int     mvwhline(WINDOW *, int, int, ChType, int);
            let mvwhline = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt_CInt> loader libPtr "mvwhline"
            // int     mvwinchnstr(WINDOW *, int, int, ChType *, int);
            let mvwinchnstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt_CInt> loader libPtr "mvwinchnstr"
            // int     mvwinchstr(WINDOW *, int, int, ChType *);
            let mvwinchstr = Platform.getDelegate<WinPtr_CInt_CInt_ChTypePtr_CInt> loader libPtr "mvwinchstr"
            // ChType  mvwinch(WINDOW *, int, int);
            let mvwinch = Platform.getDelegate<WinPtr_CInt_CInt_ChType> loader libPtr "mvwinch"
            // int     mvwinnstr(WINDOW *, int, int, char *, int);
            let mvwinnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwinnstr"
            // int     mvwinsch(WINDOW *, int, int, ChType);
            let mvwinsch = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt> loader libPtr "mvwinsch"
            // int     mvwinsnstr(WINDOW *, int, int, const char *, int);
            let mvwinsnstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt_CInt> loader libPtr "mvwinsnstr"
            // int     mvwinsstr(WINDOW *, int, int, const char *);
            let mvwinsstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwinsstr"
            // int     mvwinstr(WINDOW *, int, int, char *);
            let mvwinstr = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_CInt> loader libPtr "mvwinstr"
            // int     mvwin(WINDOW *, int, int);
            let mvwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "mvwin"
            // int     mvwprintw(WINDOW *, int, int, const char *, ...);
            let mvwprintw = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvwprintw"
            // int     mvwscanw(WINDOW *, int, int, const char *, ...);
            let mvwscanw = Platform.getDelegate<WinPtr_CInt_CInt_CCharPtr_Args_CInt> loader libPtr "mvwscanw"
            // int     mvwvline(WINDOW *, int, int, ChType, int);
            let mvwvline = Platform.getDelegate<WinPtr_CInt_CInt_ChType_CInt_CInt> loader libPtr "mvwvline"
            // int     napms(int);
            let napms = Platform.getDelegate<CInt_CInt> loader libPtr "napms"
            // WINDOW *newpad(int, int);
            let newpad = Platform.getDelegate<CInt_CInt_WinPtr> loader libPtr "newpad"
            // SCREEN *newterm(const char *, FILE *, FILE *);
            let newterm = Platform.getDelegate<CCharPtr_CFilePtr_CFilePtr_ScrPtr> loader libPtr "newterm"
            // WINDOW *newwin(int, int, int, int);
            let newwin = Platform.getDelegate<CInt_CInt_CInt_CInt_WinPtr> loader libPtr "newwin"
            // int     nl(void);
            let nl = Platform.getDelegate<CVoid_CInt> loader libPtr "nl"
            // int     nocbreak(void);
            let nocbreak = Platform.getDelegate<CVoid_CInt> loader libPtr "nocbreak"
            // int     nodelay(WINDOW *, bool);
            let nodelay = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "nodelay"
            // int     noecho(void);
            let noecho = Platform.getDelegate<CVoid_CInt> loader libPtr "noecho"
            // int     nonl(void);
            let nonl = Platform.getDelegate<CVoid_CInt> loader libPtr "nonl"
            // void    noqiflush(void);
            let noqiflush = Platform.getDelegate<CVoid_CVoid> loader libPtr "noqiflush"
            // int     noraw(void);
            let noraw = Platform.getDelegate<CVoid_CInt> loader libPtr "noraw"
            // int     notimeout(WINDOW *, bool);
            let notimeout = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "notimeout"
            // int     overlay(const WINDOW *, WINDOW *);
            let overlay = Platform.getDelegate<WinPtr_WinPtr_CInt> loader libPtr "overlay"
            // int     overwrite(const WINDOW *, WINDOW *);
            let overwrite = Platform.getDelegate<WinPtr_WinPtr_CInt> loader libPtr "overwrite"
            // int     pair_content(short, short *, short *);
            let pair_content = Platform.getDelegate<CShort_CShortPtr_CShortPtr_CInt> loader libPtr "pair_content"
            // int     pechochar(WINDOW *, ChType);
            let pechochar = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "pechochar"
            // int     pnoutrefresh(WINDOW *, int, int, int, int, int, int);
            let pnoutrefresh = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "pnoutrefresh"
            // int     prefresh(WINDOW *, int, int, int, int, int, int);
            let prefresh = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_CInt_CInt_CInt> loader libPtr "prefresh"
            // int     printw(const char *, ...);
            let printw = Platform.getDelegate<CCharPtr_Args_CInt> loader libPtr "printw"
            // int     putwin(WINDOW *, FILE *);
            let putwin = Platform.getDelegate<WinPtr_CFilePtr_CInt> loader libPtr "putwin"
            // void    qiflush(void);
            let qiflush = Platform.getDelegate<CVoid_CVoid> loader libPtr "qiflush"
            // int     raw(void);
            let raw = Platform.getDelegate<CVoid_CInt> loader libPtr "raw"
            // int     redrawwin(WINDOW *);
            let redrawwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "redrawwin"
            // int     refresh(void);
            let refresh = Platform.getDelegate<CVoid_CInt> loader libPtr "refresh"
            // int     reset_prog_mode(void);
            let reset_prog_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "reset_prog_mode"
            // int     reset_shell_mode(void);
            let reset_shell_mode = Platform.getDelegate<CVoid_CInt> loader libPtr "reset_shell_mode"
            // int     resetty(void);
            let resetty = Platform.getDelegate<CVoid_CInt> loader libPtr "resetty"
            // int     ripoffline(int, int ( *)(WINDOW *, int));
            //let ripoffline = Platform.getDelegate<CInt_f_CInt_WinPtr_CInt_CInt> loader libPtr "ripoffline"
            // int     savetty(void);
            let savetty = Platform.getDelegate<CVoid_CInt> loader libPtr "savetty"
            // int     scanw(const char *, ...);
            let scanw = Platform.getDelegate<CCharPtr_Args_CInt> loader libPtr "scanw"
            // int     scr_dump(const char *);
            let scr_dump = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_dump"
            // int     scr_init(const char *);
            let scr_init = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_init"
            // int     scr_restore(const char *);
            let scr_restore = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_restore"
            // int     scr_set(const char *);
            let scr_set = Platform.getDelegate<CCharPtr_CInt> loader libPtr "scr_set"
            // int     scrl(int);
            let scrl = Platform.getDelegate<CInt_CInt> loader libPtr "scrl"
            // int     scroll(WINDOW *);
            let scroll = Platform.getDelegate<WinPtr_CInt> loader libPtr "scroll"
            // int     scrollok(WINDOW *, bool);
            let scrollok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "scrollok"
            // SCREEN *set_term(SCREEN *);
            let set_term = Platform.getDelegate<ScrPtr_ScrPtr> loader libPtr "set_term"
            // int     setscrreg(int, int);
            let setscrreg = Platform.getDelegate<CInt_CInt_CInt> loader libPtr "setscrreg"
            // int     slk_attroff(const ChType);
            let slk_attroff = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attroff"
            // int     slk_attr_off(const attr_t, void *);
            let slk_attr_off = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "slk_attr_off"
            // int     slk_attron(const ChType);
            let slk_attron = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attron"
            // int     slk_attr_on(const attr_t, void *);
            let slk_attr_on = Platform.getDelegate<Attr_t_CVoidPtr_CInt> loader libPtr "slk_attr_on"
            // int     slk_attrset(const ChType);
            let slk_attrset = Platform.getDelegate<ChType_CInt> loader libPtr "slk_attrset"
            // int     slk_attr_set(const attr_t, short, void *);
            let slk_attr_set = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "slk_attr_set"
            // int     slk_clear(void);
            let slk_clear = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_clear"
            // int     slk_color(short);
            let slk_color = Platform.getDelegate<CShort_CInt> loader libPtr "slk_color"
            // int     slk_init(int);
            let slk_init = Platform.getDelegate<CInt_CInt> loader libPtr "slk_init"
            // char   *slk_label(int);
            let slk_label = Platform.getDelegate<CInt_CChar> loader libPtr "slk_label"
            // int     slk_noutrefresh(void);
            let slk_noutrefresh = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_noutrefresh"
            // int     slk_refresh(void);
            let slk_refresh = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_refresh"
            // int     slk_restore(void);
            let slk_restore = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_restore"
            // int     slk_set(int, const char *, int);
            let slk_set = Platform.getDelegate<CInt_CCharPtr_CInt_CInt> loader libPtr "slk_set"
            // int     slk_touch(void);
            let slk_touch = Platform.getDelegate<CVoid_CInt> loader libPtr "slk_touch"
            // int     standend(void);
            let standend = Platform.getDelegate<CVoid_CInt> loader libPtr "standend"
            // int     standout(void);
            let standout = Platform.getDelegate<CVoid_CInt> loader libPtr "standout"
            // int     start_color(void);
            let start_color = Platform.getDelegate<CVoid_CInt> loader libPtr "start_color"
            // WINDOW *subpad(WINDOW *, int, int, int, int);
            let subpad = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_WinPtr> loader libPtr "subpad"
            // WINDOW *subwin(WINDOW *, int, int, int, int);
            let subwin = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt_WinPtr> loader libPtr "subwin"
            // int     syncok(WINDOW *, bool);
            let syncok = Platform.getDelegate<WinPtr_CBool_CInt> loader libPtr "syncok"
            // ChType  termattrs(void);
            let termattrs = Platform.getDelegate<CVoid_ChType> loader libPtr "termattrs"
            // attr_t  term_attrs(void);
            let term_attrs = Platform.getDelegate<CVoid_Attr_t> loader libPtr "term_attrs"
            // char   *termname(void);
            let termname = Platform.getDelegate<CVoid_CCharPtr> loader libPtr "termname"
            // void    timeout(int);
            let timeout = Platform.getDelegate<CInt_CVoid> loader libPtr "timeout"
            // int     touchline(WINDOW *, int, int);
            let touchline = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "touchline"
            // int     touchwin(WINDOW *);
            let touchwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "touchwin"
            // int     typeahead(int);
            let typeahead = Platform.getDelegate<CInt_CInt> loader libPtr "typeahead"
            // int     untouchwin(WINDOW *);
            let untouchwin = Platform.getDelegate<WinPtr_CInt> loader libPtr "untouchwin"
            // void    use_env(bool);
            let use_env = Platform.getDelegate<CBool_CVoid> loader libPtr "use_env"
            // int     vidattr(ChType);
            let vidattr = Platform.getDelegate<ChType_CInt> loader libPtr "vidattr"
            // int     vid_attr(attr_t, short, void *);
            let vid_attr = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt> loader libPtr "vid_attr"
            // int     vidputs(ChType, int ( *)(int));
            //let vidputs = Platform.getDelegate<ChType_f_CInt_CInt> loader libPtr "vidputs"
            // int     vid_puts(attr_t, short, void *, int ( *)(int));
            //let vid_puts = Platform.getDelegate<Attr_t_CShort_CVoidPtr_CInt_f_CInt_CInt_CInt> loader libPtr "vid_puts"
            // int     vline(ChType, int);
            let vline = Platform.getDelegate<ChType_CInt_CInt> loader libPtr "vline"
            // int     vw_printw(WINDOW *, const char *, va_list);
            //let vw_printw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vw_printw"
            // int     vwprintw(WINDOW *, const char *, va_list);
            //let vwprintw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vwprintw"
            // int     vw_scanw(WINDOW *, const char *, va_list);
            //let vw_scanw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vw_scanw"
            // int     vwscanw(WINDOW *, const char *, va_list);
            //let vwscanw = Platform.getDelegate<WinPtr_CCharPtr_CVAList_CInt> loader libPtr "vwscanw"
            // int     waddchnstr(WINDOW *, const ChType *, int);
            let waddchnstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt_CInt> loader libPtr "waddchnstr"
            // int     waddchstr(WINDOW *, const ChType *);
            let waddchstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt> loader libPtr "waddchstr"
            // int     waddch(WINDOW *, const ChType);
            let waddch = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "waddch"
            // int     waddnstr(WINDOW *, const char *, int);
            let waddnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "waddnstr"
            // int     waddstr(WINDOW *, const char *);
            let waddstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "waddstr"
            // int     wattroff(WINDOW *, ChType);
            let wattroff = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattroff"
            // int     wattron(WINDOW *, ChType);
            let wattron = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattron"
            // int     wattrset(WINDOW *, ChType);
            let wattrset = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wattrset"
            // int     wattr_get(WINDOW *, attr_t *, short *, void *);
            let wattr_get = Platform.getDelegate<WinPtr_Attr_tPtr_CShortPtr_CVoidPtr_CInt> loader libPtr "wattr_get"
            // int     wattr_off(WINDOW *, attr_t, void *);
            let wattr_off = Platform.getDelegate<WinPtr_Attr_t_CVoidPtr_CInt> loader libPtr "wattr_off"
            // int     wattr_on(WINDOW *, attr_t, void *);
            let wattr_on = Platform.getDelegate<WinPtr_Attr_t_CVoidPtr_CInt> loader libPtr "wattr_on"
            // int     wattr_set(WINDOW *, attr_t, short, void *);
            let wattr_set = Platform.getDelegate<WinPtr_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "wattr_set"
            // void    wbkgdset(WINDOW *, ChType);
            let wbkgdset = Platform.getDelegate<WinPtr_ChType_CVoid> loader libPtr "wbkgdset"
            // int     wbkgd(WINDOW *, ChType);
            let wbkgd = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wbkgd"
            // int     wborder(WINDOW *, ChType, ChType, ChType, ChType, ChType, ChType, ChType, ChType);
            let wborder = Platform.getDelegate<WinPtr_ChType_ChType_ChType_ChType_ChType_ChType_ChType_ChType_CInt> loader libPtr "wborder"
            // int     wchgat(WINDOW *, int, attr_t, short, const void *);
            let wchgat = Platform.getDelegate<WinPtr_CInt_Attr_t_CShort_CVoidPtr_CInt> loader libPtr "wchgat"
            // int     wclear(WINDOW *);
            let wclear = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclear"
            // int     wclrtobot(WINDOW *);
            let wclrtobot = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclrtobot"
            // int     wclrtoeol(WINDOW *);
            let wclrtoeol = Platform.getDelegate<WinPtr_CInt> loader libPtr "wclrtoeol"
            // int     wcolor_set(WINDOW *, short, void *);
            let wcolor_set = Platform.getDelegate<WinPtr_CShort_CVoidPtr_CInt> loader libPtr "wcolor_set"
            // void    wcursyncup(WINDOW *);
            let wcursyncup = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wcursyncup"
            // int     wdelch(WINDOW *);
            let wdelch = Platform.getDelegate<WinPtr_CInt> loader libPtr "wdelch"
            // int     wdeleteln(WINDOW *);
            let wdeleteln = Platform.getDelegate<WinPtr_CInt> loader libPtr "wdeleteln"
            // int     wechochar(WINDOW *, const ChType);
            let wechochar = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "wechochar"
            // int     werase(WINDOW *);
            let werase = Platform.getDelegate<WinPtr_CInt> loader libPtr "werase"
            // int     wgetch(WINDOW *);
            let wgetch = Platform.getDelegate<WinPtr_CInt> loader libPtr "wgetch"
            // int     wgetnstr(WINDOW *, char *, int);
            let wgetnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "wgetnstr"
            // int     wgetstr(WINDOW *, char *);
            let wgetstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "wgetstr"
            // int     whline(WINDOW *, ChType, int);
            let whline = Platform.getDelegate<WinPtr_ChType_CInt_CInt> loader libPtr "whline"
            // int     winchnstr(WINDOW *, ChType *, int);
            let winchnstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt_CInt> loader libPtr "winchnstr"
            // int     winchstr(WINDOW *, ChType *);
            let winchstr = Platform.getDelegate<WinPtr_ChTypePtr_CInt> loader libPtr "winchstr"
            // ChType  winch(WINDOW *);
            let winch = Platform.getDelegate<WinPtr_ChType> loader libPtr "winch"
            // int     winnstr(WINDOW *, char *, int);
            let winnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winnstr"
            // int     winsch(WINDOW *, ChType);
            let winsch = Platform.getDelegate<WinPtr_ChType_CInt> loader libPtr "winsch"
            // int     winsdelln(WINDOW *, int);
            let winsdelln = Platform.getDelegate<WinPtr_CInt_CInt> loader libPtr "winsdelln"
            // int     winsertln(WINDOW *);
            let winsertln = Platform.getDelegate<WinPtr_CInt> loader libPtr "winsertln"
            // int     winsnstr(WINDOW *, const char *, int);
            let winsnstr = Platform.getDelegate<WinPtr_CCharPtr_CInt_CInt> loader libPtr "winsnstr"
            // int     winsstr(WINDOW *, const char *);
            let winsstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winsstr"
            // int     winstr(WINDOW *, char *);
            let winstr = Platform.getDelegate<WinPtr_CCharPtr_CInt> loader libPtr "winstr"
            // int     wmove(WINDOW *, int, int);
            let wmove = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wmove"
            // int     wnoutrefresh(WINDOW *);
            let wnoutrefresh = Platform.getDelegate<WinPtr_CInt> loader libPtr "wnoutrefresh"
            // int     wprintw(WINDOW *, const char *, ...);
            let wprintw = Platform.getDelegate<WinPtr_CCharPtr_Args_CInt> loader libPtr "wprintw"
            // int     wredrawln(WINDOW *, int, int);
            let wredrawln = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wredrawln"
            // int     wrefresh(WINDOW *);
            let wrefresh = Platform.getDelegate<WinPtr_CInt> loader libPtr "wrefresh"
            // int     wscanw(WINDOW *, const char *, ...);
            let wscanw = Platform.getDelegate<WinPtr_CCharPtr_Args_CInt> loader libPtr "wscanw"
            // int     wscrl(WINDOW *, int);
            let wscrl = Platform.getDelegate<WinPtr_CInt_CInt> loader libPtr "wscrl"
            // int     wsetscrreg(WINDOW *, int, int);
            let wsetscrreg = Platform.getDelegate<WinPtr_CInt_CInt_CInt> loader libPtr "wsetscrreg"
            // int     wstandend(WINDOW *);
            let wstandend = Platform.getDelegate<WinPtr_CInt> loader libPtr "wstandend"
            // int     wstandout(WINDOW *);
            let wstandout = Platform.getDelegate<WinPtr_CInt> loader libPtr "wstandout"
            // void    wsyncdown(WINDOW *);
            let wsyncdown = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wsyncdown"
            // void    wsyncup(WINDOW *);
            let wsyncup = Platform.getDelegate<WinPtr_CVoid> loader libPtr "wsyncup"
            // void    wtimeout(WINDOW *, int);
            let wtimeout = Platform.getDelegate<WinPtr_CInt_CVoid> loader libPtr "wtimeout"
            // int     wtouchln(WINDOW *, int, int, int);
            let wtouchln = Platform.getDelegate<WinPtr_CInt_CInt_CInt_CInt> loader libPtr "wtouchln"
            // int     wvline(WINDOW *, ChType, int);
            let wvline = Platform.getDelegate<WinPtr_ChType_CInt_CInt> loader libPtr "wvline"

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
            let mutable opts = 0
            match Delegate.attr_get.Invoke(&attrs, &color_pair, &opts) with
            | OK -> Choice1Of2 (attrs, color_pair, opts)
            | err -> Choice2Of2 err
        let attr_off attrs opts = Delegate.attr_off.Invoke(attrs, opts)
        let attr_on attrs opts = Delegate.attr_on.Invoke(attrs, opts)
        let attr_set attrs pair opts = Delegate.attr_set.Invoke(attrs, pair, opts)
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
        //let getnstr = Delegate.getnstr.Invoke() // <CCharPtr_CInt_CInt>
        //let getstr = Delegate.getstr.Invoke() // <CCharPtr_CInt>
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
            let mutable opts = 0
            match Delegate.wattr_get.Invoke(win, &attrs, &color_pair, &opts) with
            | OK -> Some (attrs, color_pair, opts)
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

    let initscr () = Imported.initscr() |> Check.cptrResult "initscr"
    // TODO: getch incompatible with windows? use wgetch instead
    let getch () = raise <| NotImplementedException()
    let wgetch win = Imported.wgetch(win) |> Check.cintResult "wgetch"
    let addch (ch:char) = Imported.addch(System.Convert.ToUInt32 ch) |> Check.unitResult "addch"
    let napms ms = Imported.napms(ms) |> Check.unitResult "napms"
    let refresh () = Imported.refresh() |> Check.unitResult "refresh"
    let endwin () = Imported.endwin() |> Check.cintResult "endwin"
