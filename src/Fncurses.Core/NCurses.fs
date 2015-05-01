namespace Fncurses.Core

[<AutoOpen>]
module NCurses = 

    open ExtCore.Control
    open System

    let ncurses = ChoiceBuilder()
        
    // ----------------------------------------------------------------------
    // Helpers

    let toChType (ch:char) = Convert.ToUInt32 ch
    let toCChar_t (ch:char) = Convert.ToUInt32 ch

    // ----------------------------------------------------------------------
    // Variable getters

    let LINES () = Platform.getCInt Imported.loader Imported.libPtr "LINES"
    let COLS () = Platform.getCInt Imported.loader Imported.libPtr "COLS"
    let stdscr () = Platform.getWinPtr Imported.loader Imported.libPtr "stdscr"
    let curscr () = Platform.getWinPtr Imported.loader Imported.libPtr "curscr"
    let SP () = Platform.getScrPtr Imported.loader Imported.libPtr "SP"
    //let Mouse_status = Platform.getMOUSE_STATUS loader libPtr "MOUSE_STATUS"
    let COLORS () = Platform.getCInt Imported.loader Imported.libPtr "COLORS"
    let COLOR_PAIRS () = Platform.getCInt Imported.loader Imported.libPtr "COLOR_PAIRS"
    let TABSIZE () = Platform.getCInt Imported.loader Imported.libPtr "TABSIZE"
    //let acs_map = Platform.getChTypeArray loader libPtr "acs_map"
    //let ttytype = Platform.getCCharArray loader libPtr "ttytype"
           
    // ----------------------------------------------------------------------
    // Functions

    // addch
        
    let addch ch = Imported.addch (toChType ch) |> Check.unitResult "addch"
    let waddch win ch = Imported.waddch win (toChType ch) |> Check.unitResult "waddch"
    let mvaddch y x ch = Imported.mvaddch y x (toChType ch) |> Check.unitResult "mvaddch"
    let mvwaddch win y x ch = Imported.mvwaddch win y x (toChType ch) |> Check.unitResult "mvwaddch"
    let echochar ch = Imported.echochar (toChType ch) |> Check.unitResult "echochar"
    let wechochar win ch = Imported.wechochar win (toChType ch) |> Check.unitResult "wechochar"

    // addchstr

    let addchstr str = Imported.addchstr str |> Check.unitResult "addchstr"
    let addchnstr str n = Imported.addchnstr str n |> Check.unitResult "addchnstr"
    let waddchstr win str = Imported.waddchstr win str |> Check.unitResult "waddchstr"
    let waddchnstr win str n = Imported.waddchnstr win str n |> Check.unitResult "waddchnstr"
    let mvaddchstr y x str = Imported.mvaddchstr y x str |> Check.unitResult "mvaddchstr"
    let mvaddchnstr y x str n = Imported.mvaddchnstr y x str n |> Check.unitResult "mvaddchnstr"
    let mvwaddchstr win y x str = Imported.mvwaddchstr win y x str |> Check.unitResult "mvwaddchstr"
    let mvwaddchnstr win y x str n = Imported.mvwaddchnstr win y x str n |> Check.unitResult "mvwaddchnstr"
                           
    // addstr

    let addstr str = Imported.addstr str |> Check.unitResult "addstr"
    let addnstr str n = Imported.addnstr str n |> Check.unitResult "addnstr"
    let waddstr win str = Imported.waddstr win str |> Check.unitResult "waddstr"
    let waddnstr win str n = Imported.waddnstr win str n |> Check.unitResult "waddnstr"
    let mvaddstr y x str = Imported.mvaddstr y x str |> Check.unitResult "mvaddstr"
    let mvaddnstr y x str n = Imported.mvaddnstr y x str n |> Check.unitResult "mvaddnstr"
    let mvwaddstr win y x str = Imported.mvwaddstr win y x str |> Check.unitResult "mvwaddstr"
    let mvwaddnstr win y x str n = Imported.mvwaddnstr win y x str n |> Check.unitResult "mvwaddnstr"

    // attr

    let attroff attrs = Imported.attroff attrs |> Check.unitResult "attroff"
    let wattroff win attrs = Imported.wattroff win attrs |> Check.unitResult "wattroff"
    let attron attrs = Imported.attron attrs |> Check.unitResult "attron"
    let wattron win attrs = Imported.wattron win attrs |> Check.unitResult "wattron"
    let attrset attrs = Imported.attrset attrs |> Check.unitResult "attrset"
    let wattrset win attrs = Imported.wattrset win attrs |> Check.unitResult "wattrset"
    let standend () = Imported.standend () |> Check.unitResult "standend"
    let wstandend win = Imported.wstandend win |> Check.unitResult "wstandend"
    let standout () = Imported.standout () |> Check.unitResult "standout"
    let wstandout win = Imported.wstandout win |> Check.unitResult "wstandout"

    // beep

    let beep () = Imported.beep () |> Check.unitResult "beep"
    let flash () = Imported.flash () |> Check.unitResult "flash"

    // bkgd

    let bkgd ch = Imported.bkgd (toChType ch) |> Check.unitResult "bkgd"
    let bkgdset ch = Imported.bkgdset (toChType ch) |> Choice.result
    let getbkgd win = Imported.getbkgd win |> Choice.result
    let wbkgd win ch = Imported.wbkgd win (toChType ch) |> Check.unitResult "wbkgd"
    let wbkgdset win ch = Imported.wbkgdset win (toChType ch) |> Choice.result

    // border

    let border ls rs ts bs tl tr bl br = Imported.border (toChType ls) (toChType rs) (toChType ts) (toChType bs) (toChType tl) (toChType tr) (toChType bl) (toChType br) |> Check.unitResult "border"
    let wborder win ls rs ts bs tl tr bl br = Imported.wborder win (toChType ls) (toChType rs) (toChType ts) (toChType bs) (toChType tl) (toChType tr) (toChType bl) (toChType br) |> Check.unitResult "wborder"
    let box win verch horch = Imported.box win (toChType verch) (toChType horch) |> Check.unitResult "box"
    let hline ch n = Imported.hline (toChType ch) n |> Check.unitResult "hline"
    let vline ch n = Imported.vline (toChType ch) n |> Check.unitResult "vline"
    let whline win ch n = Imported.whline win (toChType ch) n |> Check.unitResult "whline"
    let wvline win ch n = Imported.wvline win (toChType ch) n |> Check.unitResult "wvline"
    let mvhline y x ch n = Imported.mvhline y x (toChType ch) n |> Check.unitResult "mvhline"
    let mvvline y x ch n = Imported.mvvline y x (toChType ch) n |> Check.unitResult "mvvline"
    let mvwhline win y x ch n = Imported.mvwhline win y x (toChType ch) n |> Check.unitResult "mvwhline"
    let mvwvline win y x ch n = Imported.mvwvline win y x (toChType ch) n |> Check.unitResult "mvwvline"

    // clear

    let clear () = Imported.clear () |> Check.unitResult "clear"
    let wclear win = Imported.wclear win |> Check.unitResult "wclear"
    let erase () = Imported.erase () |> Check.unitResult "erase"
    let werase win = Imported.werase win |> Check.unitResult "werase"
    let clrtobot () = Imported.clrtobot () |> Check.unitResult "clrtobot"
    let wclrtobot win = Imported.wclrtobot win |> Check.unitResult "wclrtobot"
    let clrtoeol () = Imported.clrtoeol () |> Check.unitResult "clrtoeol"
    let wclrtoeol win = Imported.wclrtoeol win |> Check.unitResult "wclrtoeol"

    // color

    let start_color () = Imported.start_color () |> Check.unitResult "start_color"
    let init_pair pair fg bg = Imported.init_pair pair fg bg |> Check.unitResult "init_pair"
    let init_color color red green blue = Imported.init_color color red green blue |> Check.unitResult "init_color"
    let has_colors () = Imported.has_colors ()
    let can_change_color () = Imported.can_change_color () |> Choice.result
    let color_content color = Imported.color_content color |> Check.optionResult "color_content"
    let pair_content pair = Imported.pair_content pair |> Check.optionResult "pair_content"

    let assume_default_colors fg bg = Imported.assume_default_colors fg bg |> Check.unitResult "assume_default_colors"
    let use_default_colors () = Imported.use_default_colors () |> Check.unitResult "use_default_colors"

    // delch

    let delch () = Imported.delch () |> Check.unitResult "delch"
    let wdelch win = Imported.wdelch win |> Check.unitResult "wdelch"
    let mvdelch y x = Imported.mvdelch y x |> Check.unitResult "mvdelch"
    let mvwdelch win y x = Imported.mvwdelch win y x |> Check.unitResult "mvwdelch"

    // deleteln

    let deleteln () = Imported.deleteln () |> Check.unitResult "deleteln"
    let wdeleteln win = Imported.wdeleteln win |> Check.unitResult "wdeleteln"
    let insdelln n = Imported.insdelln n |> Check.unitResult "insdelln"
    let winsdelln win n = Imported.winsdelln win n |> Check.unitResult "winsdelln"
    let insertln () = Imported.insertln () |> Check.unitResult "insertln"
    let winsertln win = Imported.winsertln win |> Check.unitResult "winsertln"

    // getch

    let wgetch win = Imported.wgetch win |> Check.cintResult "wgetch"
    let getch () = Imported.wgetch (stdscr ()) |> Check.cintResult "getch"
    let mvgetch y x = Imported.mvgetch y x |> Check.cintResult "mvgetch"
    let mvwgetch win y x = Imported.mvwgetch win y x |> Check.cintResult "mvwgetch"
    // TODO: demacro let ungetch ch = Imported.ungetch ch |> Check.unitResult "ungetch"
    let flushinp () = Imported.flushinp () |> Check.unitResult "flushinp"
    
    // getstr

    let getstr () = Imported.getstr () |> Check.optionResult "getstr"
    let wgetstr win = Imported.wgetstr win |> Check.optionResult "wgetstr"
    let mvgetstr y x = Imported.mvgetstr y x |> Check.optionResult "mvgetstr"
    let mvwgetstr win y x = Imported.mvwgetstr win y x |> Check.optionResult "mvwgetstr"
    let getnstr n = Imported.getnstr n |> Check.optionResult "getnstr"
    let wgetnstr win n = Imported.wgetnstr win n |> Check.optionResult "wgetnstr"
    let mvgetnstr y x n = Imported.mvgetnstr y x n |> Check.optionResult "mvgetnstr"
    let mvwgetnstr win y x n = Imported.mvwgetnstr win y x n |> Check.optionResult "mvwgetnstr"

    // getyx
        
    let getyx win = Imported.getyx win |> Choice.result
    let getparyx win = Imported.getparyx win |> Choice.result
    let getbegyx win = Imported.getbegyx win |> Choice.result
    let getmaxyx win = Imported.getmaxyx win |> Choice.result

    // inch

    let inch () = Imported.inch () |> Choice.result
    let winch win = Imported.winch win |> Choice.result
    let mvinch y x = Imported.mvinch y x |> Choice.result
    let mvwinch win y x = Imported.mvwinch win y x |> Choice.result

    // inchstr

    // let inchstr ch = Imported.inchstr ch |> Check.unitResult "inchstr"
    // let inchnstr ch n = Imported.inchnstr |> Check.unitResult "inchnstr"
    // let winchstr win ch = Imported.winchstr |> Check.unitResult "winchstr"
    // let winchnstr win ch n = Imported.winchnstr |> Check.unitResult "winchnstr"
    // let mvinchstr y x ch = Imported.mvinchstr |> Check.unitResult "mvinchstr"
    // let mvinchnstr y x ch n = Imported.mvinchnstr |> Check.unitResult "mvinchnstr"
    // let mvwinchstr win y x ch = Imported.mvwinchstr |> Check.unitResult "mvwinchstr"
    // let mvwinchnstr win y x ch n = Imported.mvwinchnstr |> Check.unitResult "mvwinchstr"

    // initscr
        
    let initscr () = Imported.initscr () |> Check.cptrResult "initscr"
    let endwin () = Imported.endwin () |> Check.cintResult "endwin"
    let isendwin () = Imported.isendwin ()
    let newterm ``type`` outfd infd = Imported.newterm ``type`` outfd infd |> Check.cptrResult "set_term"
    let set_term ``new`` = Imported.set_term ``new`` |> Check.cptrResult "set_term"
    let delscreen sp = Imported.delscreen sp |> Choice.result

    // inopts

    let cbreak () = Imported.cbreak () |> Check.unitResult "cbreak"
    let nocbreak () = Imported.nocbreak () |> Check.unitResult "nocbreak"
    let echo () = Imported.echo () |> Check.unitResult "echo"
    let noecho () = Imported.noecho () |> Check.unitResult "noecho"
    let halfdelay tenths = Imported.halfdelay tenths |> Check.unitResult "halfdelay"
    let intrflush win bf = Imported.intrflush win bf |> Check.unitResult "intrflush"
    let keypad win bf = Imported.keypad win bf |> Check.unitResult "keypad"
    let meta win bf = Imported.meta win bf |> Check.unitResult "meta"
    let nl () = Imported.nl () |> Check.unitResult "nl"
    let nonl () = Imported.nonl () |> Check.unitResult "nonl"
    let nodelay win bf = Imported.nodelay win bf |> Check.unitResult "nodelay"
    let notimeout win bf = Imported.notimeout win bf |> Check.unitResult "notimeout"
    let raw () = Imported.raw () |> Check.unitResult "raw"
    let noraw () = Imported.noraw () |> Check.unitResult "noraw"
    let noqiflush () = Imported.noqiflush () |> Choice.result
    let qiflush () = Imported.qiflush () |> Choice.result
    let timeout delay = Imported.timeout delay |> Choice.result
    let wtimeout win delay = Imported.wtimeout win delay |> Choice.result
    let typeahead fildes = Imported.typeahead fildes |> Check.unitResult "typeahead"
     
    // kernel
                    
    let def_prog_mode () = Imported.def_prog_mode () |> Check.unitResult "def_prog_mode"
    let def_shell_mode () = Imported.def_shell_mode () |> Check.unitResult "def_shell_mode"
    let reset_prog_mode () = Imported.reset_prog_mode () |> Check.unitResult "reset_prog_mode"
    let reset_shell_mode () = Imported.reset_shell_mode () |> Check.unitResult "reset_shell_mode"
    let resetty () = Imported.resetty () |> Check.unitResult "resetty"
    let savetty () = Imported.savetty () |> Check.unitResult "savetty"
    // TODO: void getsyx(int y, int x);
    // TODO: void setsyx(int y, int x);
    // TODO: int ripoffline(int line, int (*init)(WINDOW *, int));
    let curs_set visibility = Imported.curs_set visibility |> Check.unitResult "curs_set"
    let napms ms = Imported.napms ms |> Check.unitResult "napms"

    let refresh () = Imported.refresh() |> Check.unitResult "refresh"
    //let getmaxyx win = Imported.getmaxyx win |> Choice.result
    //let getstr () = Imported.getstr() |> Check.optionResult "getstr"
    //let wgetnstr win n = Imported.wgetnstr win n |> Check.optionResult "wgetnstr"
    //let wgetstr win = Imported.wgetstr win |> Check.optionResult "wgetstr"
    let move y x = Imported.move y x |> Check.unitResult "move"
    let wmove win y x = Imported.wmove win y x |> Check.unitResult "move"      
    //let waddstr win str = Imported.waddstr win str |> Check.unitResult "waddstr"

    let vwprintw win fmt = Printf.kprintf id fmt >> waddstr win
    let printw fmt = vwprintw (stdscr ()) fmt
    let wprintw win fmt = vwprintw win fmt
    let mvprintw y x fmt =
        fun args ->
            ncurses {
                do! move y x
                return! vwprintw (stdscr ()) fmt args
            }
    let mvwprintw win y x fmt =
        fun args ->
            ncurses {
                do! wmove win y x
                return! vwprintw win fmt args
            }
    let vw_printw win fmt = vwprintw win fmt

    let vwscanw win fmt = 
        fun args ->
            ncurses {
                let! str = wgetnstr win BUFFER_SIZE
                return Text.sscanf fmt str
            }
    let scanw fmt = vwscanw (stdscr ()) fmt
    let wscanw win fmt = vwscanw win fmt
    let mvscanw y x fmt =
        fun args ->
            ncurses {
                do! move y x
                return! vwscanw (stdscr ()) fmt args
            }
    let mvwscanw win y x fmt =
        fun args ->
            ncurses {
                do! wmove win y x
                return! vwscanw win fmt args
            }
    let vw_scanw win fmt = vwscanw win fmt
