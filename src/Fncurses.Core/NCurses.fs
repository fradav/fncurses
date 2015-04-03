namespace Fncurses.Core

[<AutoOpen>]
module NCurses = 

    open System
    open System.Reflection
    open System.Runtime.InteropServices    

    module Imported =
        
        // C Types

        type Cint = int32  
        type Cptr = nativeint

        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ncurses_unit_cptr = delegate of unit -> Cptr
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ncurses_unit_cint = delegate of unit -> Cint      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ncurses_cint_cint = delegate of Cint -> Cint      
        [<UnmanagedFunctionPointer(CallingConvention.Cdecl)>]
        type ncurses_cptr_cint = delegate of Cptr -> Cint      

        // Dynamic library loading

        let loader = Platform.dispatch Platform.macLoader Platform.nixLoader Platform.winLoader        
        let dllPath = 
            Platform.dispatch 
                (fun () -> Platform.macLibraryPath "libncurses.dylib") 
                (fun () -> Platform.nixLibraryPath "libncurses.dylib") 
                (fun () -> Platform.winLibraryPath "pdcurses.dll")
        let libPtr = loader.LoadLibrary(dllPath)

        // Imported delegates

        let _initscr = Platform.getDelegate<ncurses_unit_cptr> loader libPtr "initscr"
        let _addch = Platform.getDelegate<ncurses_cint_cint> loader libPtr "addch"
        let _napms = Platform.getDelegate<ncurses_cint_cint> loader libPtr "napms"
        let _refresh = Platform.getDelegate<ncurses_unit_cint> loader libPtr "refresh"
        let _endwin = Platform.getDelegate<ncurses_unit_cint> loader libPtr "endwin"
        let _wgetch = Platform.getDelegate<ncurses_cptr_cint> loader libPtr "wgetch"

        // Wrapped delegates

        let initscr () = _initscr.Invoke()
        let wgetch win = _wgetch.Invoke(win)
        let addch ch = _addch.Invoke(ch)
        let napms ms = _napms.Invoke(ms)
        let refresh () = _refresh.Invoke()
        let endwin () = _endwin.Invoke()

    module Check =

        let cptrResult fname result =
            if result = IntPtr.Zero 
            then Result.error (sprintf "%s returned NULL" fname)
            else Result.result result

        let cintResult fname result = 
            if result = -1
            then Result.error (sprintf "%s returned ERR" fname)
            else Result.result result

        let unitResult fname result = 
            if result = -1
            then Result.error (sprintf "%s returned ERR" fname)
            else Result.result ()

    let initscr () = Imported.initscr() |> Check.cptrResult "initscr"
    // TODO: getch incompatible with windows? use wgetch instead
    let getch () = raise <| NotImplementedException()
    let wgetch win = Imported.wgetch(win) |> Check.cintResult "wgetch"
    let inline addch ch = Imported.addch(int ch) |> Check.unitResult "addch"
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

