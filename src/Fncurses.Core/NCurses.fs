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
       
        type WinPtr = IntPtr
        type ScrPtr = IntPtr
        type ChType = System.UInt32
        type ChTypePtr = string
        type CharPtr = string
        type CChar_t = ChType
        type Attr_t = ChType
        type CInt = int16
        type CChar = sbyte
        type Attr_tPtr = IntPtr
        type CShort = int16
        type CShortPtr = IntPtr
        type CVoid = unit
        type CVoidPtr = IntPtr
        type CBool = bool
        type CCharPtr = IntPtr
        type CFilePtr = IntPtr

        // Delegate types

        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_winptr = delegate of CVoid -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_cint = delegate of CVoid -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtype_cint = delegate of ChType -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint = delegate of CInt -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_cint = delegate of WinPtr -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtypeptr_cint = delegate of ChTypePtr -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtypeptr_cint_cint = delegate of ChTypePtr * CInt -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ccharptr_cint_cint = delegate of CharPtr * CInt -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ccharptr_cint = delegate of CharPtr -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type attrtptr_cshortptr_cvoidptr_cint = delegate of Attr_tPtr * CShortPtr * CVoidPtr -> CInt      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type attrt_cvoidptr_cint = delegate of Attr_t * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type attrt_cshort_cvoidptr_cint = delegate of Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtype_cvoid = delegate of ChType -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtype_chtype_chtype_chtype_chtype_chtype_chtype_chtype_cint = delegate of ChType * ChType * ChType * ChType * ChType * ChType * ChType * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_chtype_chtype_cint = delegate of WinPtr * ChType * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_cbool = delegate of CVoid -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_attrt_cshort_cvoidptr_cint = delegate of CInt * Attr_t * CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_cbool_cint = delegate of WinPtr * CBool -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cshort_cshortptr_cshortptr_cshortptr_cint = delegate of CShort * CShortPtr * CShortPtr * CShortPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cshort_cvoidptr_cint = delegate of CShort * CVoidPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_winptr_cint_cint_cint_cint_cint_cint_cint_cint = delegate of WinPtr * WinPtr * CInt * CInt * CInt * CInt * CInt * CInt * CInt -> CInt 
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type scrptr_cvoid = delegate of ScrPtr -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_cint_cint_cint_cint_cint = delegate of WinPtr * CInt * CInt * CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_winptr = delegate of WinPtr -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_cchar = delegate of CVoid -> CChar
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_cvoid = delegate of CVoid -> CVoid
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_chtype = delegate of WinPtr -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cfileptr_winptr = delegate of CFilePtr -> WinPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type chtype_cint_cint = delegate of ChType * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cvoid_chtype = delegate of CVoid -> ChType
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cshort_cshort_cshort_cshort_cint = delegate of CShort * CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cshort_cshort_cshort_cint = delegate of CShort * CShort * CShort -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_cint_cbool = delegate of WinPtr * CInt -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type winptr_cbool = delegate of WinPtr -> CBool
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_ccharptr = delegate of CInt -> CCharPtr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_cint = delegate of CInt * CInt -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_chtype_cint = delegate of CInt * CInt * ChType -> CInt
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_chtypeptr_cint_cint = delegate of CInt * CInt * ChTypePtr * CInt -> CInt 
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_chtypeptr_cint = delegate of CInt * CInt * ChTypePtr -> CInt 
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_ccharptr_cint_cint = delegate of CInt * CInt * CCharPtr * CInt -> CInt 
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type cint_cint_ccharptr_cint = delegate of CInt * CInt * CCharPtr -> CInt 

    module Imported =

        // Dynamic library loading

        let loader = Platform.dispatch Platform.macLoader Platform.nixLoader Platform.winLoader        
        let dllPath = 
            Platform.dispatch 
                (fun () -> Platform.macLibraryPath "libncurses.dylib") 
                (fun () -> Platform.nixLibraryPath "libncurses.dylib") 
                (fun () -> Platform.winLibraryPath "pdcurses.dll")
        let libPtr = loader.LoadLibrary(dllPath)

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
        
        // Imported delegates

        let _initscr = Platform.getDelegate<cvoid_winptr> loader libPtr "initscr"
        //let _addch = Platform.getDelegate<chtype_cint> loader libPtr "addch"
        let _napms = Platform.getDelegate<cint_cint> loader libPtr "napms"
        let _refresh = Platform.getDelegate<cvoid_cint> loader libPtr "refresh"
        let _endwin = Platform.getDelegate<cvoid_cint> loader libPtr "endwin"
        let _wgetch = Platform.getDelegate<winptr_cint> loader libPtr "wgetch"

        // int     addch(const chtype);
        let _addch = Platform.getDelegate<chtype_cint> loader libPtr "addch"
        // int     addchnstr(const chtype *, int);
        let _addchnstr = Platform.getDelegate<chtypeptr_cint_cint> loader libPtr "addchnstr"
        // int     addchstr(const chtype *);
        let _addchstr = Platform.getDelegate<chtypeptr_cint> loader libPtr "addchstr"
        // int     addnstr(const char *, int);
        let _addnstr = Platform.getDelegate<ccharptr_cint_cint> loader libPtr "addnstr"
        // int     addstr(const char *);
        let _addstr = Platform.getDelegate<ccharptr_cint> loader libPtr "addstr"
        // int     attroff(chtype);
        let _attroff = Platform.getDelegate<chtype_cint> loader libPtr "attroff"
        // int     attron(chtype);
        let _attron = Platform.getDelegate<chtype_cint> loader libPtr "attron"
        // int     attrset(chtype);
        let _attrset = Platform.getDelegate<chtype_cint> loader libPtr "attrset"
        // int     attr_get(attr_t *, short *, void *);
        let _attr_get = Platform.getDelegate<attrtptr_cshortptr_cvoidptr_cint> loader libPtr "attr_get"
        // int     attr_off(attr_t, void *);
        let _attr_off = Platform.getDelegate<attrt_cvoidptr_cint> loader libPtr "attr_off"
        // int     attr_on(attr_t, void *);
        let _attr_on = Platform.getDelegate<attrt_cvoidptr_cint> loader libPtr "attr_on"
        // int     attr_set(attr_t, short, void *);
        let _attr_set = Platform.getDelegate<attrt_cshort_cvoidptr_cint> loader libPtr "attr_set"
        // int     baudrate(void);
        let _baudrate = Platform.getDelegate<cvoid_cint> loader libPtr "baudrate"
        // int     beep(void);
        let _beep = Platform.getDelegate<chtype_cint> loader libPtr "beep"
        // int     bkgd(chtype);
        let _bkgd = Platform.getDelegate<chtype_cint> loader libPtr "bkgd"
        // void    bkgdset(chtype);
        let _bkgdset = Platform.getDelegate<chtype_cvoid> loader libPtr "bkgdset"
        // int     border(chtype, chtype, chtype, chtype, chtype, chtype, chtype, chtype);
        let _border = Platform.getDelegate<chtype_chtype_chtype_chtype_chtype_chtype_chtype_chtype_cint> loader libPtr "border"
        // int     box(WINDOW *, chtype, chtype);
        let _box = Platform.getDelegate<winptr_chtype_chtype_cint> loader libPtr "box"
        // bool    can_change_color(void);
        let _can_change_color = Platform.getDelegate<cvoid_cbool> loader libPtr "can_change_color"
        // int     cbreak(void); 
        let _cbreak = Platform.getDelegate<cvoid_cint> loader libPtr "cbreak"
        // int     chgat(int, attr_t, short, const void *);
        let _chgat = Platform.getDelegate<cint_attrt_cshort_cvoidptr_cint> loader libPtr "chgat"
        // int     clearok(WINDOW *, bool);
        let _clearok = Platform.getDelegate<winptr_cbool_cint> loader libPtr "clearok"
        // int     clear(void);
        let _clear = Platform.getDelegate<cvoid_cint> loader libPtr "clear"
        // int     clrtobot(void);
        let _clrtobot = Platform.getDelegate<cvoid_cint> loader libPtr "clrtobot"
        // int     clrtoeol(void);
        let _clrtoeol = Platform.getDelegate<cvoid_cint> loader libPtr "clrtoeol"
        // int     color_content(short, short *, short *, short *);
        let _color_content = Platform.getDelegate<cshort_cshortptr_cshortptr_cshortptr_cint> loader libPtr "color_content"
        // int     color_set(short, void *);
        let _color_set = Platform.getDelegate<cshort_cvoidptr_cint> loader libPtr "color_set"
        // int     copywin(const WINDOW *, WINDOW *, int, int, int, int, int, int, int);
        let _copywin = Platform.getDelegate<winptr_winptr_cint_cint_cint_cint_cint_cint_cint_cint> loader libPtr "copywin"
        // int     curs_set(int);
        let _curs_set = Platform.getDelegate<cint_cint> loader libPtr "curs_set"
        // int     def_prog_mode(void);
        let _def_prog_mode = Platform.getDelegate<cvoid_cint> loader libPtr "def_prog_mode"
        // int     def_shell_mode(void);
        let _def_shell_mode = Platform.getDelegate<cvoid_cint> loader libPtr "def_shell_mode"
        // int     delay_output(int);
        let _delay_output = Platform.getDelegate<cint_cint> loader libPtr "delay_output"
        // int     delch(void);
        let _delch = Platform.getDelegate<cvoid_cint> loader libPtr "delch"
        // int     deleteln(void);
        let _deleteln = Platform.getDelegate<cvoid_cint> loader libPtr "deleteln"
        // void    delscreen(SCREEN *); 
        let _delscreen = Platform.getDelegate<scrptr_cvoid> loader libPtr "delscreen"
        // int     delwin(WINDOW *);
        let _delwin = Platform.getDelegate<winptr_cint> loader libPtr "delwin"
        // WINDOW *derwin(WINDOW *, int, int, int, int);
        let _derwin = Platform.getDelegate<winptr_cint_cint_cint_cint_cint> loader libPtr "derwin"
        // int     doupdate(void);
        let _doupdate = Platform.getDelegate<cvoid_cint> loader libPtr "doupdate"
        // WINDOW *dupwin(WINDOW *);
        let _dupwin = Platform.getDelegate<winptr_winptr> loader libPtr "dupwin"
        // int     echochar(const chtype);
        let _echochar = Platform.getDelegate<chtype_cint> loader libPtr "echochar"
        // int     echo(void);
        let _echo = Platform.getDelegate<cvoid_cint> loader libPtr "echo"
        // int     endwin(void);
        let _endwin = Platform.getDelegate<cvoid_cint> loader libPtr "endwin"
        // char    erasechar(void);
        let _erasechar = Platform.getDelegate<cvoid_cchar> loader libPtr "erasechar"
        // int     erase(void);
        let _erase = Platform.getDelegate<cvoid_cint> loader libPtr "erase"
        // void    filter(void);
        let _filter = Platform.getDelegate<cvoid_cvoid> loader libPtr "filter"
        // int     flash(void);
        let _flash = Platform.getDelegate<cvoid_cint> loader libPtr "flash"
        // int     flushinp(void);
        let _flushinp = Platform.getDelegate<cvoid_cint> loader libPtr "flushinp"
        // chtype  getbkgd(WINDOW *);
        let _getbkgd = Platform.getDelegate<winptr_chtype> loader libPtr "getbkgd"
        // int     getnstr(char *, int);
        let _getnstr = Platform.getDelegate<ccharptr_cint_cint> loader libPtr "getnstr"
        // int     getstr(char *);
        let _getstr = Platform.getDelegate<ccharptr_cint> loader libPtr "getstr"
        // WINDOW *getwin(FILE *);
        let _getwin = Platform.getDelegate<cfileptr_winptr> loader libPtr "getwin"
        // int     halfdelay(int);
        let _halfdelay = Platform.getDelegate<cint_cint> loader libPtr "halfdelay"
        // bool    has_colors(void);
        let _has_colors = Platform.getDelegate<cvoid_cbool> loader libPtr "has_colors"
        // bool    has_ic(void);
        let _has_ic = Platform.getDelegate<cvoid_cbool> loader libPtr "has_ic"
        // bool    has_il(void);
        let _has_il = Platform.getDelegate<cvoid_cbool> loader libPtr "has_il"
        // int     hline(chtype, int);
        let _hline = Platform.getDelegate<chtype_cint_cint> loader libPtr "hline"
        // void    idcok(WINDOW *, bool);
        let _idcok = Platform.getDelegate<winptr_cbool_cint> loader libPtr "idcok"
        // int     idlok(WINDOW *, bool);
        let _idlok = Platform.getDelegate<winptr_cbool_cint> loader libPtr "idlok"
        // void    immedok(WINDOW *, bool);
        let _immedok = Platform.getDelegate<winptr_cbool_cint> loader libPtr "immedok"
        // int     inchnstr(chtype *, int);
        let _inchnstr = Platform.getDelegate<chtypeptr_cint_cint> loader libPtr "inchnstr"
        // int     inchstr(chtype *);
        let _inchstr = Platform.getDelegate<chtypeptr_cint> loader libPtr "inchstr"
        // chtype  inch(void);
        let _inch = Platform.getDelegate<cvoid_chtype> loader libPtr "inch"
        // int     init_color(short, short, short, short);
        let _init_color = Platform.getDelegate<cshort_cshort_cshort_cshort_cint> loader libPtr "init_color"
        // int     init_pair(short, short, short);
        let _init_pair = Platform.getDelegate<cshort_cshort_cshort_cint> loader libPtr "init_pair"
        // WINDOW *initscr(void);
        let _initscr = Platform.getDelegate<cvoid_winptr> loader libPtr "initscr"
        // int     innstr(char *, int);
        let _innstr = Platform.getDelegate<ccharptr_cint_cint> loader libPtr "innstr"
        // int     insch(chtype);
        let _insch = Platform.getDelegate<chtype_cint> loader libPtr "insch"
        // int     insdelln(int);
        let _insdelln = Platform.getDelegate<cint_cint> loader libPtr "insdelln"
        // int     insertln(void);
        let _insertln = Platform.getDelegate<cvoid_cint> loader libPtr "insertln"
        // int     insnstr(const char *, int);
        let _insnstr = Platform.getDelegate<ccharptr_cint_cint> loader libPtr "insnstr"
        // int     insstr(const char *);
        let _insstr = Platform.getDelegate<ccharptr_cint> loader libPtr "insstr"
        // int     instr(char *);
        let _instr = Platform.getDelegate<ccharptr_cint> loader libPtr "instr"
        // int     intrflush(WINDOW *, bool);
        let _intrflush = Platform.getDelegate<winptr_cbool_cint> loader libPtr "intrflush"
        // bool    isendwin(void);
        let _isendwin = Platform.getDelegate<cvoid_cbool> loader libPtr "isendwin"
        // bool    is_linetouched(WINDOW *, int);
        let _is_linetouched = Platform.getDelegate<winptr_cint_cbool> loader libPtr "is_linetouched"
        // bool    is_wintouched(WINDOW *);
        let _is_wintouched = Platform.getDelegate<winptr_cbool> loader libPtr "is_wintouched"
        // char   *keyname(int);
        let _keyname = Platform.getDelegate<cint_ccharptr> loader libPtr "keyname"
        // int     keypad(WINDOW *, bool);
        let _keypad = Platform.getDelegate<winptr_cbool_cint> loader libPtr "keypad"
        // char    killchar(void);
        let _killchar = Platform.getDelegate<cvoid_cchar> loader libPtr "killchar"
        // int     leaveok(WINDOW *, bool);
        let _leaveok = Platform.getDelegate<winptr_cbool_cint> loader libPtr "leaveok"
        // char   *longname(void);
        let _longname = Platform.getDelegate<cvoid_cchar> loader libPtr "longname"
        // int     meta(WINDOW *, bool);
        let _meta = Platform.getDelegate<winptr_cbool_cint> loader libPtr "meta"
        // int     move(int, int);
        let _move = Platform.getDelegate<cint_cint_cint> loader libPtr "move"
        // int     mvaddch(int, int, const chtype);
        let _mvaddch = Platform.getDelegate<cint_cint_chtype_cint> loader libPtr "mvaddch"
        // int     mvaddchnstr(int, int, const chtype *, int);
        let _mvaddchnstr = Platform.getDelegate<cint_cint_chtypeptr_cint_cint> loader libPtr "mvaddchnstr"
        // int     mvaddchstr(int, int, const chtype *);
        let _mvaddchstr = Platform.getDelegate<cint_cint_chtypeptr_cint> loader libPtr "mvaddchstr"
        // int     mvaddnstr(int, int, const char *, int);
        let _mvaddnstr = Platform.getDelegate<cint_cint_ccharptr_cint_cint> loader libPtr "mvaddnstr"
        // int     mvaddstr(int, int, const char *);
        let _mvaddstr = Platform.getDelegate<cint_cint_ccharptr_cint> loader libPtr "mvaddstr"
        // int     mvchgat(int, int, int, attr_t, short, const void *);
        let _mvchgat = Platform.getDelegate<> loader libPtr "mvchgat"
        // int     mvcur(int, int, int, int);
        let _mvcur = Platform.getDelegate<> loader libPtr "mvcur"
        // int     mvdelch(int, int);
        let _mvdelch = Platform.getDelegate<> loader libPtr "mvdelch"
        // int     mvderwin(WINDOW *, int, int);
        let _mvderwin = Platform.getDelegate<> loader libPtr "mvderwin"
        // int     mvgetch(int, int);
        let _mvgetch = Platform.getDelegate<> loader libPtr "mvgetch"
        // int     mvgetnstr(int, int, char *, int);
        let _mvgetnstr = Platform.getDelegate<> loader libPtr "mvgetnstr"
        // int     mvgetstr(int, int, char *);
        let _mvgetstr = Platform.getDelegate<> loader libPtr "mvgetstr"
        // int     mvhline(int, int, chtype, int);
        let _mvhline = Platform.getDelegate<> loader libPtr "mvhline"
        // chtype  mvinch(int, int);
        let _mvinch = Platform.getDelegate<> loader libPtr "mvinch"
        // int     mvinchnstr(int, int, chtype *, int);
        let _mvinchnstr = Platform.getDelegate<> loader libPtr "mvinchnstr"
        // int     mvinchstr(int, int, chtype *);
        let _mvinchstr = Platform.getDelegate<> loader libPtr "mvinchstr"
        // int     mvinnstr(int, int, char *, int);
        let _mvinnstr = Platform.getDelegate<> loader libPtr "mvinnstr"
        // int     mvinsch(int, int, chtype);
        let _mvinsch = Platform.getDelegate<> loader libPtr "mvinsch"
        // int     mvinsnstr(int, int, const char *, int);
        let _mvinsnstr = Platform.getDelegate<> loader libPtr "mvinsnstr"
        // int     mvinsstr(int, int, const char *);
        let _mvinsstr = Platform.getDelegate<> loader libPtr "mvinsstr"
        // int     mvinstr(int, int, char *);
        let _mvinstr = Platform.getDelegate<> loader libPtr "mvinstr"
        // int     mvprintw(int, int, const char *, ...);
        let _mvprintw = Platform.getDelegate<> loader libPtr "mvprintw"
        // int     mvscanw(int, int, const char *, ...);
        let _mvscanw = Platform.getDelegate<> loader libPtr "mvscanw"
        // int     mvvline(int, int, chtype, int);
        let _mvvline = Platform.getDelegate<> loader libPtr "mvvline"
        // int     mvwaddchnstr(WINDOW *, int, int, const chtype *, int);
        let _mvwaddchnstr = Platform.getDelegate<> loader libPtr "mvwaddchnstr"
        // int     mvwaddchstr(WINDOW *, int, int, const chtype *);
        let _mvwaddchstr = Platform.getDelegate<> loader libPtr "mvwaddchstr"
        // int     mvwaddch(WINDOW *, int, int, const chtype);
        let _mvwaddch = Platform.getDelegate<> loader libPtr "mvwaddch"
        // int     mvwaddnstr(WINDOW *, int, int, const char *, int);
        let _mvwaddnstr = Platform.getDelegate<> loader libPtr "mvwaddnstr"
        // int     mvwaddstr(WINDOW *, int, int, const char *);
        let _mvwaddstr = Platform.getDelegate<> loader libPtr "mvwaddstr"
        // int     mvwchgat(WINDOW *, int, int, int, attr_t, short, const void *);
        let _mvwchgat = Platform.getDelegate<> loader libPtr "mvwchgat"
        // int     mvwdelch(WINDOW *, int, int);
        let _mvwdelch = Platform.getDelegate<> loader libPtr "mvwdelch"
        // int     mvwgetch(WINDOW *, int, int);
        let _mvwgetch = Platform.getDelegate<> loader libPtr "mvwgetch"
        // int     mvwgetnstr(WINDOW *, int, int, char *, int);
        let _mvwgetnstr = Platform.getDelegate<> loader libPtr "mvwgetnstr"
        // int     mvwgetstr(WINDOW *, int, int, char *);
        let _mvwgetstr = Platform.getDelegate<> loader libPtr "mvwgetstr"
        // int     mvwhline(WINDOW *, int, int, chtype, int);
        let _mvwhline = Platform.getDelegate<> loader libPtr "mvwhline"
        // int     mvwinchnstr(WINDOW *, int, int, chtype *, int);
        let _mvwinchnstr = Platform.getDelegate<> loader libPtr "mvwinchnstr"
        // int     mvwinchstr(WINDOW *, int, int, chtype *);
        let _mvwinchstr = Platform.getDelegate<> loader libPtr "mvwinchstr"
        // chtype  mvwinch(WINDOW *, int, int);
        let _mvwinch = Platform.getDelegate<> loader libPtr "mvwinch"
        // int     mvwinnstr(WINDOW *, int, int, char *, int);
        let _mvwinnstr = Platform.getDelegate<> loader libPtr "mvwinnstr"
        // int     mvwinsch(WINDOW *, int, int, chtype);
        let _mvwinsch = Platform.getDelegate<> loader libPtr "mvwinsch"
        // int     mvwinsnstr(WINDOW *, int, int, const char *, int);
        let _mvwinsnstr = Platform.getDelegate<> loader libPtr "mvwinsnstr"
        // int     mvwinsstr(WINDOW *, int, int, const char *);
        let _mvwinsstr = Platform.getDelegate<> loader libPtr "mvwinsstr"
        // int     mvwinstr(WINDOW *, int, int, char *);
        let _mvwinstr = Platform.getDelegate<> loader libPtr "mvwinstr"
        // int     mvwin(WINDOW *, int, int);
        let _mvwin = Platform.getDelegate<> loader libPtr "mvwin"
        // int     mvwprintw(WINDOW *, int, int, const char *, ...);
        let _mvwprintw = Platform.getDelegate<> loader libPtr "mvwprintw"
        // int     mvwscanw(WINDOW *, int, int, const char *, ...);
        let _mvwscanw = Platform.getDelegate<> loader libPtr "mvwscanw"
        // int     mvwvline(WINDOW *, int, int, chtype, int);
        let _mvwvline = Platform.getDelegate<> loader libPtr "mvwvline"
        // int     napms(int);
        let _napms = Platform.getDelegate<> loader libPtr "napms"
        // WINDOW *newpad(int, int);
        let _newpad = Platform.getDelegate<> loader libPtr "newpad"
        // SCREEN *newterm(const char *, FILE *, FILE *);
        let _newterm = Platform.getDelegate<> loader libPtr "newterm"
        // WINDOW *newwin(int, int, int, int);
        let _newwin = Platform.getDelegate<> loader libPtr "newwin"
        // int     nl(void);
        let _nl = Platform.getDelegate<> loader libPtr "nl"
        // int     nocbreak(void);
        let _nocbreak = Platform.getDelegate<> loader libPtr "nocbreak"
        // int     nodelay(WINDOW *, bool);
        let _nodelay = Platform.getDelegate<> loader libPtr "nodelay"
        // int     noecho(void);
        let _noecho = Platform.getDelegate<> loader libPtr "noecho"
        // int     nonl(void);
        let _nonl = Platform.getDelegate<> loader libPtr "nonl"
        // void    noqiflush(void);
        let _noqiflush = Platform.getDelegate<> loader libPtr "noqiflush"
        // int     noraw(void);
        let _noraw = Platform.getDelegate<> loader libPtr "noraw"
        // int     notimeout(WINDOW *, bool);
        let _notimeout = Platform.getDelegate<> loader libPtr "notimeout"
        // int     overlay(const WINDOW *, WINDOW *);
        let _overlay = Platform.getDelegate<> loader libPtr "overlay"
        // int     overwrite(const WINDOW *, WINDOW *);
        let _overwrite = Platform.getDelegate<> loader libPtr "overwrite"
        // int     pair_content(short, short *, short *);
        let _pair_content = Platform.getDelegate<> loader libPtr "pair_content"
        // int     pechochar(WINDOW *, chtype);
        let _pechochar = Platform.getDelegate<> loader libPtr "pechochar"
        // int     pnoutrefresh(WINDOW *, int, int, int, int, int, int);
        let _pnoutrefresh = Platform.getDelegate<> loader libPtr "pnoutrefresh"
        // int     prefresh(WINDOW *, int, int, int, int, int, int);
        let _prefresh = Platform.getDelegate<> loader libPtr "prefresh"
        // int     printw(const char *, ...);
        let _printw = Platform.getDelegate<> loader libPtr "printw"
        // int     putwin(WINDOW *, FILE *);
        let _putwin = Platform.getDelegate<> loader libPtr "putwin"
        // void    qiflush(void);
        let _qiflush = Platform.getDelegate<> loader libPtr "qiflush"
        // int     raw(void);
        let _raw = Platform.getDelegate<> loader libPtr "raw"
        // int     redrawwin(WINDOW *);
        let _redrawwin = Platform.getDelegate<> loader libPtr "redrawwin"
        // int     refresh(void);
        let _refresh = Platform.getDelegate<> loader libPtr "refresh"
        // int     reset_prog_mode(void);
        let _reset_prog_mode = Platform.getDelegate<> loader libPtr "reset_prog_mode"
        // int     reset_shell_mode(void);
        let _reset_shell_mode = Platform.getDelegate<> loader libPtr "reset_shell_mode"
        // int     resetty(void);
        let _resetty = Platform.getDelegate<> loader libPtr "resetty"
        // int     ripoffline(int, int (*)(WINDOW *, int));
        let _ripoffline = Platform.getDelegate<> loader libPtr "ripoffline"
        // int     savetty(void);
        let _savetty = Platform.getDelegate<> loader libPtr "savetty"
        // int     scanw(const char *, ...);
        let _scanw = Platform.getDelegate<> loader libPtr "scanw"
        // int     scr_dump(const char *);
        let _scr_dump = Platform.getDelegate<> loader libPtr "scr_dump"
        // int     scr_init(const char *);
        let _scr_init = Platform.getDelegate<> loader libPtr "scr_init"
        // int     scr_restore(const char *);
        let _scr_restore = Platform.getDelegate<> loader libPtr "scr_restore"
        // int     scr_set(const char *);
        let _scr_set = Platform.getDelegate<> loader libPtr "scr_set"
        // int     scrl(int);
        let _scrl = Platform.getDelegate<> loader libPtr "scrl"
        // int     scroll(WINDOW *);
        let _scroll = Platform.getDelegate<> loader libPtr "scroll"
        // int     scrollok(WINDOW *, bool);
        let _scrollok = Platform.getDelegate<> loader libPtr "scrollok"
        // SCREEN *set_term(SCREEN *);
        let _set_term = Platform.getDelegate<> loader libPtr "set_term"
        // int     setscrreg(int, int);
        let _setscrreg = Platform.getDelegate<> loader libPtr "setscrreg"
        // int     slk_attroff(const chtype);
        let _slk_attroff = Platform.getDelegate<> loader libPtr "slk_attroff"
        // int     slk_attr_off(const attr_t, void *);
        let _slk_attr_off = Platform.getDelegate<> loader libPtr "slk_attr_off"
        // int     slk_attron(const chtype);
        let _slk_attron = Platform.getDelegate<> loader libPtr "slk_attron"
        // int     slk_attr_on(const attr_t, void *);
        let _slk_attr_on = Platform.getDelegate<> loader libPtr "slk_attr_on"
        // int     slk_attrset(const chtype);
        let _slk_attrset = Platform.getDelegate<> loader libPtr "slk_attrset"
        // int     slk_attr_set(const attr_t, short, void *);
        let _slk_attr_set = Platform.getDelegate<> loader libPtr "slk_attr_set"
        // int     slk_clear(void);
        let _slk_clear = Platform.getDelegate<> loader libPtr "slk_clear"
        // int     slk_color(short);
        let _slk_color = Platform.getDelegate<> loader libPtr "slk_color"
        // int     slk_init(int);
        let _slk_init = Platform.getDelegate<> loader libPtr "slk_init"
        // char   *slk_label(int);
        let _slk_label = Platform.getDelegate<> loader libPtr "slk_label"
        // int     slk_noutrefresh(void);
        let _slk_noutrefresh = Platform.getDelegate<> loader libPtr "slk_noutrefresh"
        // int     slk_refresh(void);
        let _slk_refresh = Platform.getDelegate<> loader libPtr "slk_refresh"
        // int     slk_restore(void);
        let _slk_restore = Platform.getDelegate<> loader libPtr "slk_restore"
        // int     slk_set(int, const char *, int);
        let _slk_set = Platform.getDelegate<> loader libPtr "slk_set"
        // int     slk_touch(void);
        let _slk_touch = Platform.getDelegate<> loader libPtr "slk_touch"
        // int     standend(void);
        let _standend = Platform.getDelegate<> loader libPtr "standend"
        // int     standout(void);
        let _standout = Platform.getDelegate<> loader libPtr "standout"
        // int     start_color(void);
        let _start_color = Platform.getDelegate<> loader libPtr "start_color"
        // WINDOW *subpad(WINDOW *, int, int, int, int);
        let _subpad = Platform.getDelegate<> loader libPtr "subpad"
        // WINDOW *subwin(WINDOW *, int, int, int, int);
        let _subwin = Platform.getDelegate<> loader libPtr "subwin"
        // int     syncok(WINDOW *, bool);
        let _syncok = Platform.getDelegate<> loader libPtr "syncok"
        // chtype  termattrs(void);
        let _termattrs = Platform.getDelegate<> loader libPtr "termattrs"
        // attr_t  term_attrs(void);
        let _term_attrs = Platform.getDelegate<> loader libPtr "term_attrs"
        // char   *termname(void);
        let _termname = Platform.getDelegate<> loader libPtr "termname"
        // void    timeout(int);
        let _timeout = Platform.getDelegate<> loader libPtr "timeout"
        // int     touchline(WINDOW *, int, int);
        let _touchline = Platform.getDelegate<> loader libPtr "touchline"
        // int     touchwin(WINDOW *);
        let _touchwin = Platform.getDelegate<> loader libPtr "touchwin"
        // int     typeahead(int);
        let _typeahead = Platform.getDelegate<> loader libPtr "typeahead"
        // int     untouchwin(WINDOW *);
        let _untouchwin = Platform.getDelegate<> loader libPtr "untouchwin"
        // void    use_env(bool);
        let _use_env = Platform.getDelegate<cbool_cvoid> loader libPtr "use_env"
        // int     vidattr(chtype);
        let _vidattr = Platform.getDelegate<chtype_cint> loader libPtr "vidattr"
        // int     vid_attr(attr_t, short, void *);
        let _vid_attr = Platform.getDelegate<> loader libPtr "vid_attr"
        // int     vidputs(chtype, int (*)(int));
        let _vidputs = Platform.getDelegate<> loader libPtr "vidputs"
        // int     vid_puts(attr_t, short, void *, int (*)(int));
        let _vid_puts = Platform.getDelegate<> loader libPtr "vid_puts"
        // int     vline(chtype, int);
        let _vline = Platform.getDelegate<> loader libPtr "vline"
        // int     vw_printw(WINDOW *, const char *, va_list);
        let _vw_printw = Platform.getDelegate<> loader libPtr "vw_printw"
        // int     vwprintw(WINDOW *, const char *, va_list);
        let _vwprintw = Platform.getDelegate<> loader libPtr "vwprintw"
        // int     vw_scanw(WINDOW *, const char *, va_list);
        let _vw_scanw = Platform.getDelegate<> loader libPtr "vw_scanw"
        // int     vwscanw(WINDOW *, const char *, va_list);
        let _vwscanw = Platform.getDelegate<> loader libPtr "vwscanw"
        // int     waddchnstr(WINDOW *, const chtype *, int);
        let _waddchnstr = Platform.getDelegate<> loader libPtr "waddchnstr"
        // int     waddchstr(WINDOW *, const chtype *);
        let _waddchstr = Platform.getDelegate<> loader libPtr "waddchstr"
        // int     waddch(WINDOW *, const chtype);
        let _waddch = Platform.getDelegate<> loader libPtr "waddch"
        // int     waddnstr(WINDOW *, const char *, int);
        let _waddnstr = Platform.getDelegate<> loader libPtr "waddnstr"
        // int     waddstr(WINDOW *, const char *);
        let _waddstr = Platform.getDelegate<> loader libPtr "waddstr"
        // int     wattroff(WINDOW *, chtype);
        let _wattroff = Platform.getDelegate<> loader libPtr "wattroff"
        // int     wattron(WINDOW *, chtype);
        let _wattron = Platform.getDelegate<> loader libPtr "wattron"
        // int     wattrset(WINDOW *, chtype);
        let _wattrset = Platform.getDelegate<> loader libPtr "wattrset"
        // int     wattr_get(WINDOW *, attr_t *, short *, void *);
        let _wattr_get = Platform.getDelegate<> loader libPtr "wattr_get"
        // int     wattr_off(WINDOW *, attr_t, void *);
        let _wattr_off = Platform.getDelegate<> loader libPtr "wattr_off"
        // int     wattr_on(WINDOW *, attr_t, void *);
        let _wattr_on = Platform.getDelegate<> loader libPtr "wattr_on"
        // int     wattr_set(WINDOW *, attr_t, short, void *);
        let _wattr_set = Platform.getDelegate<> loader libPtr "wattr_set"
        // void    wbkgdset(WINDOW *, chtype);
        let _wbkgdset = Platform.getDelegate<> loader libPtr "wbkgdset"
        // int     wbkgd(WINDOW *, chtype);
        let _wbkgd = Platform.getDelegate<> loader libPtr "wbkgd"
        // int     wborder(WINDOW *, chtype, chtype, chtype, chtype, chtype, chtype, chtype, chtype);
        let _wborder = Platform.getDelegate<> loader libPtr "wborder"
        // int     wchgat(WINDOW *, int, attr_t, short, const void *);
        let _wchgat = Platform.getDelegate<> loader libPtr "wchgat"
        // int     wclear(WINDOW *);
        let _wclear = Platform.getDelegate<> loader libPtr "wclear"
        // int     wclrtobot(WINDOW *);
        let _wclrtobot = Platform.getDelegate<> loader libPtr "wclrtobot"
        // int     wclrtoeol(WINDOW *);
        let _wclrtoeol = Platform.getDelegate<> loader libPtr "wclrtoeol"
        // int     wcolor_set(WINDOW *, short, void *);
        let _wcolor_set = Platform.getDelegate<> loader libPtr "wcolor_set"
        // void    wcursyncup(WINDOW *);
        let _wcursyncup = Platform.getDelegate<> loader libPtr "wcursyncup"
        // int     wdelch(WINDOW *);
        let _wdelch = Platform.getDelegate<> loader libPtr "wdelch"
        // int     wdeleteln(WINDOW *);
        let _wdeleteln = Platform.getDelegate<> loader libPtr "wdeleteln"
        // int     wechochar(WINDOW *, const chtype);
        let _wechochar = Platform.getDelegate<> loader libPtr "wechochar"
        // int     werase(WINDOW *);
        let _werase = Platform.getDelegate<> loader libPtr "werase"
        // int     wgetch(WINDOW *);
        let _wgetch = Platform.getDelegate<> loader libPtr "wgetch"
        // int     wgetnstr(WINDOW *, char *, int);
        let _wgetnstr = Platform.getDelegate<> loader libPtr "wgetnstr"
        // int     wgetstr(WINDOW *, char *);
        let _wgetstr = Platform.getDelegate<> loader libPtr "wgetstr"
        // int     whline(WINDOW *, chtype, int);
        let _whline = Platform.getDelegate<> loader libPtr "whline"
        // int     winchnstr(WINDOW *, chtype *, int);
        let _winchnstr = Platform.getDelegate<> loader libPtr "winchnstr"
        // int     winchstr(WINDOW *, chtype *);
        let _winchstr = Platform.getDelegate<> loader libPtr "winchstr"
        // chtype  winch(WINDOW *);
        let _winch = Platform.getDelegate<> loader libPtr "winch"
        // int     winnstr(WINDOW *, char *, int);
        let _winnstr = Platform.getDelegate<> loader libPtr "winnstr"
        // int     winsch(WINDOW *, chtype);
        let _winsch = Platform.getDelegate<> loader libPtr "winsch"
        // int     winsdelln(WINDOW *, int);
        let _winsdelln = Platform.getDelegate<> loader libPtr "winsdelln"
        // int     winsertln(WINDOW *);
        let _winsertln = Platform.getDelegate<> loader libPtr "winsertln"
        // int     winsnstr(WINDOW *, const char *, int);
        let _winsnstr = Platform.getDelegate<> loader libPtr "winsnstr"
        // int     winsstr(WINDOW *, const char *);
        let _winsstr = Platform.getDelegate<> loader libPtr "winsstr"
        // int     winstr(WINDOW *, char *);
        let _winstr = Platform.getDelegate<> loader libPtr "winstr"
        // int     wmove(WINDOW *, int, int);
        let _wmove = Platform.getDelegate<> loader libPtr "wmove"
        // int     wnoutrefresh(WINDOW *);
        let _wnoutrefresh = Platform.getDelegate<> loader libPtr "wnoutrefresh"
        // int     wprintw(WINDOW *, const char *, ...);
        let _wprintw = Platform.getDelegate<> loader libPtr "wprintw"
        // int     wredrawln(WINDOW *, int, int);
        let _wredrawln = Platform.getDelegate<> loader libPtr "wredrawln"
        // int     wrefresh(WINDOW *);
        let _wrefresh = Platform.getDelegate<> loader libPtr "wrefresh"
        // int     wscanw(WINDOW *, const char *, ...);
        let _wscanw = Platform.getDelegate<> loader libPtr "wscanw"
        // int     wscrl(WINDOW *, int);
        let _wscrl = Platform.getDelegate<> loader libPtr "wscrl"
        // int     wsetscrreg(WINDOW *, int, int);
        let _wsetscrreg = Platform.getDelegate<> loader libPtr "wsetscrreg"
        // int     wstandend(WINDOW *);
        let _wstandend = Platform.getDelegate<> loader libPtr "wstandend"
        // int     wstandout(WINDOW *);
        let _wstandout = Platform.getDelegate<> loader libPtr "wstandout"
        // void    wsyncdown(WINDOW *);
        let _wsyncdown = Platform.getDelegate<> loader libPtr "wsyncdown"
        // void    wsyncup(WINDOW *);
        let _wsyncup = Platform.getDelegate<> loader libPtr "wsyncup"
        // void    wtimeout(WINDOW *, int);
        let _wtimeout = Platform.getDelegate<> loader libPtr "wtimeout"
        // int     wtouchln(WINDOW *, int, int, int);
        let _wtouchln = Platform.getDelegate<> loader libPtr "wtouchln"
        // int     wvline(WINDOW *, chtype, int);
        let _wvline = Platform.getDelegate<> loader libPtr "wvline"

        // Wrapped delegates

        let initscr () = _initscr.Invoke()
        let wgetch win = _wgetch.Invoke(win)
        let addch ch = _addch.Invoke(ch)
        let napms ms = _napms.Invoke(ms)
        let refresh () = _refresh.Invoke()
        let endwin () = _endwin.Invoke()

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


//    let NCURSES_ATTR_SHIFT = 8
//    let NCURSES_BITS (mask,shift) = mask <<< (shift + NCURSES_ATTR_SHIFT)
//
//    [<AutoOpen>]
//    module Attributes =
//
//        let A_NORMAL =     1u - 1u
//        let A_ATTRIBUTES = NCURSES_BITS(~~~(1u - 1u),0)
//        let A_CHARTEXT =   (NCURSES_BITS(1u,0) - 1u)
//        let A_COLOR =      NCURSES_BITS((1u <<< 8) - 1u,0)
//        let A_STANDOUT =   NCURSES_BITS(1u, 8)
//        let A_UNDERLINE =  NCURSES_BITS(1u, 9)
//        let A_REVERSE =    NCURSES_BITS(1u,10)
//        let A_BLINK =      NCURSES_BITS(1u,11)
//        let A_DIM =        NCURSES_BITS(1u,12)
//        let A_BOLD =       NCURSES_BITS(1u,13)
//        let A_ALTCHARSET = NCURSES_BITS(1u,14)
//        let A_INVIS =      NCURSES_BITS(1u,15)
//        let A_PROTECT =    NCURSES_BITS(1u,16)
//        let A_HORIZONTAL = NCURSES_BITS(1u,17)
//        let A_LEFT =       NCURSES_BITS(1u,18)
//        let A_LOW =        NCURSES_BITS(1u,19)
//        let A_RIGHT =      NCURSES_BITS(1u,20)
//        let A_TOP =        NCURSES_BITS(1u,21)
//        let A_VERTICAL =   NCURSES_BITS(1u,22)
//
//
//    [<AutoOpen>]
//    module Color =
//
//        let COLOR_PAIR n =  NCURSES_BITS(n, 0)
//        let PAIR_NUMBER a = int ((a &&& A_COLOR) >>> NCURSES_ATTR_SHIFT)
//
//        [<Literal>] 
//        let COLOR_BLACK =   0s
//        [<Literal>] 
//        let COLOR_RED =     1s
//        [<Literal>] 
//        let COLOR_GREEN =   2s
//        [<Literal>] 
//        let COLOR_YELLOW =  3s
//        [<Literal>] 
//        let COLOR_BLUE =    4s
//        [<Literal>] 
//        let COLOR_MAGENTA = 5s
//        [<Literal>] 
//        let COLOR_CYAN =    6s
//        [<Literal>] 
//        let COLOR_WHITE =   7s
//
//
//    [<AutoOpen>]
//    module Keys =
//
//        [<Literal>] 
//        let KEY_CODE_YES =  0o400       // A wchar_t contains a key code 
//        [<Literal>] 
//        let KEY_MIN =       0o401       // Minimum curses key 
//        [<Literal>] 
//        let KEY_BREAK =     0o401       // Break key (unreliable) 
//        [<Literal>] 
//        let KEY_SRESET =    0o530       // Soft (partial) reset (unreliable) 
//        [<Literal>] 
//        let KEY_RESET =     0o531       // Reset or hard reset (unreliable) 
//        [<Literal>] 
//        let KEY_DOWN =      0o402       // down-arrow key 
//        [<Literal>] 
//        let KEY_UP =        0o403       // up-arrow key 
//        [<Literal>] 
//        let KEY_LEFT =      0o404       // left-arrow key 
//        [<Literal>] 
//        let KEY_RIGHT =     0o405       // right-arrow key 
//        [<Literal>] 
//        let KEY_HOME =      0o406       // home key 
//        [<Literal>] 
//        let KEY_BACKSPACE = 0o407       // backspace key 
//        [<Literal>] 
//        let KEY_F0 =        0o410       // Function keys.  Space for 64 
//        let KEY_F n =       KEY_F0 + n  // Value of function key n 
//        [<Literal>] 
//        let KEY_DL =        0o510       // delete-line key 
//        [<Literal>] 
//        let KEY_IL =        0o511       // insert-line key 
//        [<Literal>] 
//        let KEY_DC =        0o512       // delete-character key 
//        [<Literal>] 
//        let KEY_IC =        0o513       // insert-character key 
//        [<Literal>] 
//        let KEY_EIC =       0o514       // sent by rmir or smir in insert mode 
//        [<Literal>] 
//        let KEY_CLEAR =     0o515       // clear-screen or erase key 
//        [<Literal>] 
//        let KEY_EOS =       0o516       // clear-to-end-of-screen key 
//        [<Literal>] 
//        let KEY_EOL =       0o517       // clear-to-end-of-line key 
//        [<Literal>] 
//        let KEY_SF =        0o520       // scroll-forward key 
//        [<Literal>] 
//        let KEY_SR =        0o521       // scroll-backward key 
//        [<Literal>] 
//        let KEY_NPAGE =     0o522       // next-page key 
//        [<Literal>] 
//        let KEY_PPAGE =     0o523       // previous-page key 
//        [<Literal>] 
//        let KEY_STAB =      0o524       // set-tab key 
//        [<Literal>] 
//        let KEY_CTAB =      0o525       // clear-tab key 
//        [<Literal>] 
//        let KEY_CATAB =     0o526       // clear-all-tabs key 
//        [<Literal>] 
//        let KEY_ENTER =     0o527       // enter/send key 
//        [<Literal>] 
//        let KEY_PRINT =     0o532       // print key 
//        [<Literal>] 
//        let KEY_LL =        0o533       // lower-left key (home down) 
//        [<Literal>] 
//        let KEY_A1 =        0o534       // upper left of keypad 
//        [<Literal>] 
//        let KEY_A3 =        0o535       // upper right of keypad 
//        [<Literal>] 
//        let KEY_B2 =        0o536       // center of keypad 
//        [<Literal>] 
//        let KEY_C1 =        0o537       // lower left of keypad 
//        [<Literal>] 
//        let KEY_C3 =        0o540       // lower right of keypad 
//        [<Literal>] 
//        let KEY_BTAB =      0o541       // back-tab key 
//        [<Literal>] 
//        let KEY_BEG =       0o542       // begin key 
//        [<Literal>] 
//        let KEY_CANCEL =    0o543       // cancel key 
//        [<Literal>] 
//        let KEY_CLOSE =     0o544       // close key 
//        [<Literal>] 
//        let KEY_COMMAND =   0o545       // command key 
//        [<Literal>] 
//        let KEY_COPY =      0o546       // copy key 
//        [<Literal>] 
//        let KEY_CREATE =    0o547       // create key 
//        [<Literal>] 
//        let KEY_END =       0o550       // end key 
//        [<Literal>] 
//        let KEY_EXIT =      0o551       // exit key 
//        [<Literal>] 
//        let KEY_FIND =      0o552       // find key 
//        [<Literal>] 
//        let KEY_HELP =      0o553       // help key 
//        [<Literal>] 
//        let KEY_MARK =      0o554       // mark key 
//        [<Literal>] 
//        let KEY_MESSAGE =   0o555       // message key 
//        [<Literal>] 
//        let KEY_MOVE =      0o556       // move key 
//        [<Literal>] 
//        let KEY_NEXT =      0o557       // next key 
//        [<Literal>] 
//        let KEY_OPEN =      0o560       // open key 
//        [<Literal>] 
//        let KEY_OPTIONS =   0o561       // options key 
//        [<Literal>] 
//        let KEY_PREVIOUS =  0o562       // previous key 
//        [<Literal>] 
//        let KEY_REDO =      0o563       // redo key 
//        [<Literal>] 
//        let KEY_REFERENCE = 0o564       // reference key 
//        [<Literal>] 
//        let KEY_REFRESH =   0o565       // refresh key 
//        [<Literal>] 
//        let KEY_REPLACE =   0o566       // replace key 
//        [<Literal>] 
//        let KEY_RESTART =   0o567       // restart key 
//        [<Literal>] 
//        let KEY_RESUME =    0o570       // resume key 
//        [<Literal>] 
//        let KEY_SAVE =      0o571       // save key 
//        [<Literal>] 
//        let KEY_SBEG =      0o572       // shifted begin key 
//        [<Literal>] 
//        let KEY_SCANCEL =   0o573       // shifted cancel key 
//        [<Literal>] 
//        let KEY_SCOMMAND =  0o574       // shifted command key 
//        [<Literal>] 
//        let KEY_SCOPY =     0o575       // shifted copy key 
//        [<Literal>] 
//        let KEY_SCREATE =   0o576       // shifted create key 
//        [<Literal>] 
//        let KEY_SDC =       0o577       // shifted delete-character key 
//        [<Literal>] 
//        let KEY_SDL =       0o600       // shifted delete-line key 
//        [<Literal>] 
//        let KEY_SELECT =    0o601       // select key 
//        [<Literal>] 
//        let KEY_SEND =      0o602       // shifted end key 
//        [<Literal>] 
//        let KEY_SEOL =      0o603       // shifted clear-to-end-of-line key 
//        [<Literal>] 
//        let KEY_SEXIT =     0o604       // shifted exit key 
//        [<Literal>] 
//        let KEY_SFIND =     0o605       // shifted find key 
//        [<Literal>] 
//        let KEY_SHELP =     0o606       // shifted help key 
//        [<Literal>] 
//        let KEY_SHOME =     0o607       // shifted home key 
//        [<Literal>] 
//        let KEY_SIC =       0o610       // shifted insert-character key 
//        [<Literal>] 
//        let KEY_SLEFT =     0o611       // shifted left-arrow key 
//        [<Literal>] 
//        let KEY_SMESSAGE =  0o612       // shifted message key 
//        [<Literal>] 
//        let KEY_SMOVE =     0o613       // shifted move key 
//        [<Literal>] 
//        let KEY_SNEXT =     0o614       // shifted next key 
//        [<Literal>] 
//        let KEY_SOPTIONS =  0o615       // shifted options key 
//        [<Literal>] 
//        let KEY_SPREVIOUS = 0o616       // shifted previous key 
//        [<Literal>] 
//        let KEY_SPRINT =    0o617       // shifted print key 
//        [<Literal>] 
//        let KEY_SREDO =     0o620       // shifted redo key 
//        [<Literal>] 
//        let KEY_SREPLACE =  0o621       // shifted replace key 
//        [<Literal>] 
//        let KEY_SRIGHT =    0o622       // shifted right-arrow key 
//        [<Literal>] 
//        let KEY_SRSUME =    0o623       // shifted resume key 
//        [<Literal>] 
//        let KEY_SSAVE =     0o624       // shifted save key 
//        [<Literal>] 
//        let KEY_SSUSPEND =  0o625       // shifted suspend key 
//        [<Literal>] 
//        let KEY_SUNDO =     0o626       // shifted undo key 
//        [<Literal>] 
//        let KEY_SUSPEND =   0o627       // suspend key 
//        [<Literal>] 
//        let KEY_UNDO =      0o630       // undo key 
//        [<Literal>] 
//        let KEY_MOUSE =     0o631       // Mouse event has occurred 
//        [<Literal>] 
//        let KEY_RESIZE =    0o632       // Terminal resize event 
//        [<Literal>] 
//        let KEY_EVENT =     0o633       // We were interrupted by an event 
//        [<Literal>] 
//        let KEY_MAX =       0o777       // Maximum key value is 0633 
//
//    module Imported =
//
//        open System
//
//        // initscr
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern IntPtr initscr();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int endwin();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern Boolean isendwin();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern IntPtr newterm(IntPtr ``type``, IntPtr outfd, IntPtr infd);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern IntPtr set_term(IntPtr ``new``);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern IntPtr delscreen(IntPtr screen);
//
//        // addch
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int addch(int ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int waddch(IntPtr win, int ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvaddch(int y, int x, int ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwaddch(IntPtr win, int y, int x, uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int echochar(uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wechochar(IntPtr win, int ch);
//    
//        // getch
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)>]
//        extern int getch();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)>]
//        extern int wgetch(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)>]
//        extern int mvgetch(int y, int x);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)>]
//        extern int mvwgetch(IntPtr win, int y, int x);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)>]
//        extern int ungetch(int ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int has_key(int ch);
//            
//        // refresh
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int refresh();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wrefresh(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wnoutrefresh(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int doupdate();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int redrawwin(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wredrawln(IntPtr win, int beg_line, int num_lines);
//
//        // addchstr
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int addchstr(uint32[] chstr);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int addchnstr(uint32[] chstr, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int waddchstr(IntPtr win, uint32[] chstr);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int waddchnstr(IntPtr win, uint32[] chstr, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvaddchstr(int y, int x, uint32[] chstr);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvaddchnstr(int y, int x, uint32[] chstr, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwaddchstr(IntPtr win, int y, int x, uint32[] chstr);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwaddchnstr(IntPtr win, int y, int x, uint32[] chstr, int n);
//
//        // addstr
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int addstr(string str);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int addnstr(string str, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int waddstr(IntPtr win, string str);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int waddnstr(IntPtr win, string str, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvaddstr(int y, int x, string str);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvaddnstr(int y, int x, string str, int n);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwaddstr(IntPtr win, int y, int x, string str);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwaddnstr(IntPtr win, int y, int x, string str, int n);
//
//        // def_prog_mode
//
//        type RipOffLineFunInt = delegate of (IntPtr * int) -> int
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int def_prog_mode();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int def_shell_mode();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int reset_prog_mode();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int reset_shell_mode();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int resetty();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int savetty();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void getsyx(int& y, int& x);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void setsyx(int y, int x);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int ripoffline(int line, RipOffLineFunInt init);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int curs_set(int visibility);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int napms(int ms);
//
//        // move
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int move(int y, int x);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wmove(IntPtr win, int y, int x);
//
//        // attroff
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attroff(uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattroff(IntPtr win, uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attron(uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattron(IntPtr win, uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attrset(uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattrset(IntPtr win, uint32 attrs);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int color_set(int16 color_pair_number, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wcolor_set(IntPtr win, int16 color_pair_number, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int standend();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wstandend(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int standout();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wstandout(IntPtr win);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attr_get(uint32& attrs, int16& pair, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattr_get(IntPtr win, uint32& attrs, int16& pair, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attr_off(uint32 attrs, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattr_off(IntPtr win, uint32 attrs, IntPtr   opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attr_on(uint32 attrs, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattr_on(IntPtr win, uint32 attrs, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int attr_set(uint32 attrs, int16 pair, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wattr_set(IntPtr win, uint32 attrs, int16 pair, IntPtr opts);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int chgat(int n, uint32 attr, int16 color, IntPtr opts)
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wchgat(IntPtr win, int n, uint32 attr, int16 color, IntPtr opts)
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvchgat(int y, int x, int n, uint32 attr, int16 color, IntPtr opts)
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int mvwchgat(IntPtr win, int y, int x, int n, uint32 attr, int16 color, IntPtr opts)
//
//        // printw
//        // TODO: handle printw variable arguments
//        // http://stackoverflow.com/questions/26304864/marshaling-variable-arguments-arglist-or-alternative
//
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int printw(string fmt, ...);
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int wprintw(IntPtr win, string fmt, ...);
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int mvprintw(int y, int x, string fmt, ...);
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int mvwprintw(IntPtr win, int y, int x, string fmt, ...);
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int vwprintw(IntPtr win, string fmt, va_list varglist);
//        //[<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        //extern int vw_printw(IntPtr win, string fmt, va_list varglist);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int printw(string fmt, string arg1);
//
//        // keypad
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int cbreak();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int nocbreak();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int echo();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int noecho();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int halfdelay(int tenths);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int intrflush(IntPtr win, bool bf);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int keypad(IntPtr win, bool bf);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int meta(IntPtr win, bool bf);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int nodelay(IntPtr win, bool bf);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int raw();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int noraw();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void noqiflush();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void qiflush();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int notimeout(IntPtr win, bool bf);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void timeout(int delay);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void wtimeout(IntPtr win, int delay);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int typeahead(int fd);
//
//        // start_color
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int start_color();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int init_pair(Int16 pair, Int16 f, Int16 b);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int init_color(Int16 color, Int16 r, Int16 g, Int16 b);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern bool has_colors();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern bool can_change_color();
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int color_content(Int16 color, Int16& r, Int16& g, Int16& b);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int pair_content(Int16 pair, Int16& f, Int16& b);
//
//        // bkgd
//
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void bkgdset(uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern void wbkgdset(IntPtr win, uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int bkgd(uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern int wbkgd(IntPtr win, uint32 ch);
//        [<DllImport("libncurses", CallingConvention = CallingConvention.Cdecl)>]
//        extern uint32 getbkgd(IntPtr win);
//
//
//    let verifyIntPtr fname result =
//        if result = IntPtr.Zero 
//        then Result.error (sprintf "%s returned NULL" fname)
//        else Result.result result
//
//    let verifyInt fname result = 
//        if result = -1
//        then Result.error (sprintf "%s returned ERR" fname)
//        else Result.result result
//
//    let verify fname result = 
//        if result = -1
//        then Result.error (sprintf "%s returned ERR" fname)
//        else Result.result ()
//
//    /// Initializes curses mode for single terminal applications.  
//    /// Returns a pointer to stdscr.
//    let initscr () =
//        Imported.initscr() |> verifyIntPtr "initscr"
//
//    /// An application should call endwin before exiting curses mode.
//    let endwin () =
//        Imported.endwin() |> verifyInt "endwin"
//
//    /// Returns true if endwin has been called without any subsequent 
//    /// calls to wrefresh.
//    let isendwin () =
//        Imported.isendwin()
//
//    /// Initializes curses mode for multiple terminal applications.
//    let newterm ``type`` outfd infd =
//        Imported.newterm(``type``, outfd, infd) |> verifyIntPtr "newterm"
//
//    /// Switch to the screen. Returns the previous terminal.
//    let set_term ``new`` =
//        Imported.set_term(``new``) |> verifyIntPtr "set_term"
//
//    /// Frees storage associated with the screen.
//    let delscreen screen =
//        Imported.delscreen(screen) |> verifyIntPtr "delscreen"
//
//    /// Adds a character at the current window position. 
//    let inline addch ch =
//        Imported.addch(int ch) |> verify "addch"
//    
//    /// Adds a character at the current window position. 
//    let inline waddch win ch =
//        Imported.waddch(win, int ch) |> verify "waddch"
//
//    /// Adds a character at the current window position. 
//    let inline mvaddch win y x ch =
//        Imported.mvaddch(y, x, int ch) |> verify "mvaddch"
//
//    /// Adds a character at the current window position. 
//    let inline mvwaddch win y x ch =
//        Imported.mvwaddch(win, y, x, uint32 ch) |> verify "mvwaddch"
//
//    /// Adds a character at the current window position and refreshes. 
//    let inline echochar ch =
//        Imported.echochar(uint32 ch) |> verify "echochar"
//
//    /// Adds a character at the current window position and refreshes. 
//    let inline wechochar win ch =
//        Imported.wechochar(win, int ch) |> verify "wechochar"
//
//    /// Gets characters from curses terminal keyboard.
//    let getch () =
//        Imported.getch() |> verifyInt "wgetch"
//
//    /// Gets characters from curses terminal keyboard.
//    let wgetch win =
//        Imported.wgetch(win) |> verifyInt "wgetch"
//
//    /// Gets characters from curses terminal keyboard.
//    let mvwgetch win y x =
//        Imported.mvwgetch(win, y, x) |> verifyInt "mvwgetch"
//
//    /// Places a character back onto the input queue.
//    let inline ungetch ch =
//        Imported.ungetch(int ch) |> verifyInt "ungetch"
//
//    /// Returns true or false if the key value is recognized by the current terminal.
//    let inline has_key ch =
//        Imported.has_key(int ch) |> verifyInt "has_key"
//
//    /// Applies updates to the terminal.
//    let refresh () =
//        Imported.refresh() |> verify "wrefresh"
//
//    /// Applies updates to the terminal.
//    let wrefresh win =
//        Imported.wrefresh(win) |> verify "wrefresh"
//
//    /// Applies updates to the terminal.
//    let wnoutrefresh win =
//        Imported.wnoutrefresh(win) |> verify "wnoutrefresh"
//
//    /// Applies updates to the terminal.
//    let doupdate () =
//        Imported.doupdate() |> verify "doupdate"
//
//    /// Redraws the terminal.
//    let redrawwin win =
//        Imported.redrawwin(win) |> verify "redrawwin"
//
//    /// Redraws the terminal.
//    let wredrawln win beg_line num_lines =
//        Imported.wredrawln(win, beg_line, num_lines) |> verify "wredrawln"
//
//    /// Copies a character string to the terminal.
//    let addchstr chstr =
//        Imported.addchstr(chstr) |> verify "addchstr"
//
//    /// Copies a character string to the terminal.
//    let addchnstr chstr n =
//        Imported.addchnstr(chstr, n) |> verify "addchnstr"
//
//    /// Copies a character string to the terminal.
//    let waddchstr win chstr =
//        Imported.waddchstr(win, chstr) |> verify "waddchstr"
//
//    /// Copies a character string to the terminal.
//    let waddchnstr win chstr n =
//        Imported.waddchnstr(win, chstr, n) |> verify "waddchnstr"
//
//    /// Copies a character string to the terminal.
//    let mvaddchstr y x chstr =
//        Imported.mvaddchstr(y, x, chstr) |> verify "mvaddchstr"
//
//    /// Copies a character string to the terminal.
//    let mvaddchnstr y x chstr n =
//        Imported.mvaddchnstr(y, x, chstr, n) |> verify "mvaddchnstr"
//
//    /// Copies a character string to the terminal.
//    let mvwaddchstr win y x chstr =
//        Imported.mvwaddchstr(win, y, x, chstr) |> verify "mvwaddchstr"
//
//    /// Copies a character string to the terminal.
//    let mvwaddchnstr win y x chstr n =
//        Imported.mvwaddchnstr(win, y, x, chstr, n) |> verify "mvwaddchnstr"
//
//    /// Copies a string to the terminal.
//    let addstr str =
//        Imported.addstr(str) |> verify "addstr"
//
//    /// Copies a string to the terminal.
//    let addnstr str n =
//        Imported.addnstr(str,n) |> verify "addnstr"
//
//    /// Copies a string to the terminal.
//    let waddstr win str =
//        Imported.waddstr(win,str) |> verify "waddstr"
//
//    /// Copies a string to the terminal.
//    let waddnstr win str n =
//        Imported.waddnstr(win,str,n) |> verify "waddnstr"
//
//    /// Copies a string to the terminal.
//    let mvaddstr y x str =
//        Imported.mvaddstr(y,x,str) |> verify "mvaddstr"
//
//    /// Copies a string to the terminal.
//    let mvaddnstr y x str n =
//        Imported.mvaddnstr(y,x,str,n) |> verify "mvaddnstr"
//
//    /// Copies a string to the terminal.
//    let mvwaddstr win y x str =
//        Imported.mvwaddstr(win,y,x,str) |> verify "mvwaddstr"
//
//    /// Copies a string to the terminal.
//    let mvwaddnstr win y x str n =
//        Imported.mvwaddnstr(win,y,x,str,n) |> verify "mvwaddnstr"
//
//    /// Save the current terminal modes as the "program".
//    let def_prog_mode () =
//        Imported.def_prog_mode() |> verify "def_prog_mode"
//
//    /// Save the current terminal modes as the "shell".
//    let def_shell_mode () =
//        Imported.def_shell_mode() |> verify "def_shell_mode"
//
//    /// Restore the terminal to "program" state.
//    let reset_prog_mode () =
//        Imported.reset_prog_mode() |> verify "reset_prog_mode"
//
//    /// Restore the terminal to "shell" state
//    let reset_shell_mode () =
//        Imported.reset_shell_mode() |> verify "reset_shell_mode"
//
//    /// Restore the state of the terminal modes from a buffer.
//    let resetty () =
//        Imported.resetty() |> verify "resetty"
//
//    /// Save the state of the terminal modes to a buffer.
//    let savetty () =
//        Imported.savetty() |> verify "savetty"
//
//    /// Get the current coordinates of the virtual screen cursor.
//    let getsyx () =
//        let mutable y,x = 0,0
//        Imported.getsyx(&y, &x)
//        y,x
//
//    /// Set the coordinates of the virtual screen cursor.
//    let setsyx y x =
//        Imported.setsyx(y, x)
//
//    /// Removes a line from the stdscr.
//    let ripoffline line init =
//        Imported.ripoffline(line, init) |> verify "ripoffline"
//
//    /// Sets the cursor state to invisible, normal or very visible.
//    let curs_set visibility =
//        Imported.curs_set(visibility) |> verify "curs_set"
//
//    /// Sleep for ms milliseconds.
//    let napms ms =
//        Imported.napms(ms) |> verify "napms"
//
//    let move y x =
//        Imported.move(y, x) |> verify "move"
//
//    let wmove win y x =
//        Imported.wmove(win, y, x) |> verify "wmove"
//
//    let attroff attrs =
//        Imported.attroff(attrs) |> verify "attroff"
//
//    let wattroff win attrs =
//        Imported.wattroff(win, attrs) |> verify "wattroff"
//
//    let attron attrs =
//        Imported.attron(attrs) |> verify "attron"
//
//    let wattron win attrs =
//        Imported.wattron(win, attrs) |> verify "wattron"
//
//    let attrset attrs =
//        Imported.attrset(attrs) |> verify "attrset"
//
//    let wattrset win attrs =
//        Imported.wattrset(win, attrs) |> verify "wattrset"
//
//    let color_set color_pair_number =
//        Imported.color_set(color_pair_number, IntPtr.Zero) |> verify "color_set"
//
//    let wcolor_set win color_pair_number =
//        Imported.wcolor_set(win, color_pair_number, IntPtr.Zero) |> verify "wcolor_set"
//
//    let standend () =
//        Imported.standend() |> verify "standend"
//
//    let wstandend win =
//        Imported.wstandend(win) |> verify "wstandend"
//
//    let standout () =
//        Imported.standout() |> verify "standout"
//
//    let wstandout win =
//        Imported.wstandout(win) |> verify "wstandout"
//
//    let attr_get () =
//        // TODO: clean up attr_get
//        let mutable attrs,pair = 0u,0s
//        let result = Imported.attr_get(&attrs, &pair, IntPtr.Zero) 
//        match verify "attr_get" result with 
//        | Success _ -> Result.result (attrs,pair)
//        | Failure e -> Failure e
//
//    let wattr_get win =
//        // TODO: clean up wattr_get
//        let mutable attrs,pair = 0u,0s
//        let result = Imported.wattr_get(win, &attrs, &pair, IntPtr.Zero) 
//        match verify "wattr_get" result with 
//        | Success _ -> Result.result (attrs,pair)
//        | Failure e -> Failure e
//
//    let attr_off attrs =
//        Imported.attr_off(attrs, IntPtr.Zero) |> verify "attr_off"
//
//    let wattr_off win attrs opts =
//        Imported.wattr_off(win, attrs, IntPtr.Zero) |> verify "wattr_off"
//
//    let attr_on attrs opts =
//        Imported.attr_on(attrs, IntPtr.Zero) |> verify "attr_on"
//
//    let wattr_on win attrs opts =
//        Imported.wattr_on(win, attrs, IntPtr.Zero) |> verify "wattr_on"
//
//    let attr_set attrs pair opts =
//        Imported.attr_set(attrs, pair, IntPtr.Zero) |> verify "attr_set"
//
//    let wattr_set win attrs pair opts =
//        Imported.wattr_set(win, attrs, pair, IntPtr.Zero) |> verify "wattr_set"
//
//    let chgat n attr color opts =
//        Imported.chgat(n, attr, color, IntPtr.Zero) |> verify "chgat"
//
//    let wchgat win n attr color opts =
//        Imported.wchgat(win, n, attr, color, IntPtr.Zero) |> verify "wchgat"
//
//    let mvchgat y x n attr color opts =
//        Imported.mvchgat(y, x, n, attr, color, IntPtr.Zero) |> verify "mvchgat"
//
//    let mvwchgat win y x n attr color opts =
//        Imported.mvwchgat(win, y, x, n, attr, color, IntPtr.Zero) |> verify "mvwchgat"
//
//    let printw1 fmt arg1 =
//        Imported.printw(fmt, arg1) |> verify "printw1"
//
//    let cbreak () =
//        Imported.cbreak() |> verify "cbreak"
//
//    let nocbreak () =
//        Imported.nocbreak() |> verify "nocbreak"
//
//    let echo () =
//        Imported.echo() |> verify "echo"
//
//    let noecho () =
//        Imported.noecho() |> verify "noecho"
//
//    let halfdelay tenths =
//        Imported.halfdelay(tenths) |> verify "halfdelay"
//
//    let intrflush win bf =
//        Imported.intrflush(win, bf) |> verify "intrflush"
//
//    let keypad win bf =
//        Imported.keypad(win, bf) |> verify "keypad"
//
//    let meta win bf =
//        Imported.meta(win, bf) |> verify "meta"
//
//    let nodelay win bf =
//        Imported.nodelay(win, bf) |> verify "nodelay"
//
//    let raw () =
//        Imported.raw() |> verify "raw"
//
//    let noraw () =
//        Imported.noraw() |> verify "noraw"
//
//    let noqiflush () =
//        Imported.noqiflush()
//
//    let qiflush () =
//        Imported.qiflush()
//
//    let notimeout win bf =
//        Imported.notimeout(win, bf) |> verify "notimeout"
//
//    let timeout delay =
//        Imported.timeout(delay)
//
//    let wtimeout win delay =
//        Imported.wtimeout(win, delay)
//
//    let typeahead fd =
//        Imported.typeahead(fd) |> verify "typeahead"
//
//    let start_color () =
//        Imported.start_color() |> verify "start_color"
//
//    let init_pair pair f b =
//        Imported.init_pair(pair, f, b) |> verify "init_pair"
//
//    let init_color color r g b =
//        Imported.init_color(color, r, g, b) |> verify "init_color"
//
//    let has_colors () =
//        Imported.has_colors()
//
//    let can_change_color () =
//        Imported.can_change_color()
//
//    let color_content color =
//        let mutable r,g,b = 0s,0s,0s
//        let result = Imported.color_content(color, &r, &g, &b)
//        match verify "color_content" result with 
//        | Success _ -> Result.result (r,g,b)
//        | Failure e -> Result.error e
//
//    let pair_content pair =
//        let mutable f,b = 0s,0s 
//        let result = Imported.pair_content(pair, &f, &b)
//        match verify "pair_content" result with 
//        | Success _ -> Result.result (f,b)
//        | Failure e -> Result.error e
//
//    let bkgdset ch =
//        Imported.bkgdset(ch)
//
//    let wbkgdset win ch =
//        Imported.wbkgdset(win, ch)
//
//    let bkgd ch =
//        Imported.bkgd(ch) |> ignore
//
//    let wbkgd win ch =
//        Imported.wbkgd(win, ch) |> ignore
//
//    let getbkgd win =
//        Imported.getbkgd(win)

