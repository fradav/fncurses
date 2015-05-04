namespace Fncurses.Core

[<AutoOpen>]
module Constants =

    open System
        
    /// Boolean false value     
    let [<Literal>] FALSE = 0
  
    /// Boolean true value     
    let [<Literal>] TRUE = 1
  
    /// Zero pointer value
    let NULL = IntPtr.Zero
  
    /// Value returned on error condition
    let [<Literal>] ERR = -1s
  
    /// Value returned on successful completion     
    let [<Literal>] OK = 0s
  
    /// The default size for buffers    
    let [<Literal>] BUFFER_SIZE = 255s

[<AutoOpen>]
module KeyCodes =

    let [<Literal>] KEY_CODE_YES =  0o400s      // A wchar_t contains a key code
    let [<Literal>] KEY_MIN =       0o401s      // Minimum curses key
    let [<Literal>] KEY_BREAK =     0o401s      // Break key (unreliable)
    let [<Literal>] KEY_SRESET =    0o530s      // Soft (partial) reset (unreliable)
    let [<Literal>] KEY_RESET =     0o531s      // Reset or hard reset (unreliable)
    let [<Literal>] KEY_DOWN =      0o402s      // down-arrow key
    let [<Literal>] KEY_UP  =       0o403s      // up-arrow key
    let [<Literal>] KEY_LEFT =      0o404s      // left-arrow key
    let [<Literal>] KEY_RIGHT =     0o405s      // right-arrow key
    let [<Literal>] KEY_HOME =      0o406s      // home key
    let [<Literal>] KEY_BACKSPACE = 0o407s      // backspace key
    let [<Literal>] KEY_F0 =        0o410s      // Function keys.  Space for 64
    //let KEY_F(n)  (KEY_=F0+(n))   // Value of function key n
    let [<Literal>] KEY_DL =        0o510s      // delete-line key
    let [<Literal>] KEY_IL =        0o511s      // insert-line key
    let [<Literal>] KEY_DC =        0o512s      // delete-character key
    let [<Literal>] KEY_IC =        0o513s      // insert-character key
    let [<Literal>] KEY_EIC =       0o514s      // sent by rmir or smir in insert mode
    let [<Literal>] KEY_CLEAR =     0o515s      // clear-screen or erase key
    let [<Literal>] KEY_EOS =       0o516s      // clear-to-end-of-screen key
    let [<Literal>] KEY_EOL =       0o517s      // clear-to-end-of-line key
    let [<Literal>] KEY_SF =        0o520s      // scroll-forward key
    let [<Literal>] KEY_SR =        0o521s      // scroll-backward key
    let [<Literal>] KEY_NPAGE =     0o522s      // next-page key
    let [<Literal>] KEY_PPAGE =     0o523s      // previous-page key
    let [<Literal>] KEY_STAB =      0o524s      // set-tab key
    let [<Literal>] KEY_CTAB =      0o525s      // clear-tab key
    let [<Literal>] KEY_CATAB =     0o526s      // clear-all-tabs key
    let [<Literal>] KEY_ENTER =     0o527s      // enter/send key
    let [<Literal>] KEY_PRINT =     0o532s      // print key
    let [<Literal>] KEY_LL =        0o533s      // lower-left key (home down)
    let [<Literal>] KEY_A1 =        0o534s      // upper left of keypad
    let [<Literal>] KEY_A3 =        0o535s      // upper right of keypad
    let [<Literal>] KEY_B2 =        0o536s      // center of keypad
    let [<Literal>] KEY_C1 =        0o537s      // lower left of keypad
    let [<Literal>] KEY_C3 =        0o540s      // lower right of keypad
    let [<Literal>] KEY_BTAB =      0o541s      // back-tab key
    let [<Literal>] KEY_BEG =       0o542s      // begin key
    let [<Literal>] KEY_CANCEL =    0o543s      // cancel key
    let [<Literal>] KEY_CLOSE =     0o544s      // close key
    let [<Literal>] KEY_COMMAND =   0o545s      // command key
    let [<Literal>] KEY_COPY =      0o546s      // copy key
    let [<Literal>] KEY_CREATE =    0o547s      // create key
    let [<Literal>] KEY_END =       0o550s      // end key
    let [<Literal>] KEY_EXIT =      0o551s      // exit key
    let [<Literal>] KEY_FIND =      0o552s      // find key
    let [<Literal>] KEY_HELP =      0o553s      // help key
    let [<Literal>] KEY_MARK =      0o554s      // mark key
    let [<Literal>] KEY_MESSAGE =   0o555s      // message key
    let [<Literal>] KEY_MOVE =      0o556s      // move key
    let [<Literal>] KEY_NEXT =      0o557s      // next key
    let [<Literal>] KEY_OPEN =      0o560s      // open key
    let [<Literal>] KEY_OPTIONS =   0o561s      // options key
    let [<Literal>] KEY_PREVIOUS =  0o562s      // previous key
    let [<Literal>] KEY_REDO =      0o563s      // redo key
    let [<Literal>] KEY_REFERENCE = 0o564s      // reference key
    let [<Literal>] KEY_REFRESH =   0o565s      // refresh key
    let [<Literal>] KEY_REPLACE =   0o566s      // replace key
    let [<Literal>] KEY_RESTART =   0o567s      // restart key
    let [<Literal>] KEY_RESUME =    0o570s      // resume key
    let [<Literal>] KEY_SAVE =      0o571s      // save key
    let [<Literal>] KEY_SBEG =      0o572s      // shifted begin key
    let [<Literal>] KEY_SCANCEL =   0o573s      // shifted cancel key
    let [<Literal>] KEY_SCOMMAND =  0o574s      // shifted command key
    let [<Literal>] KEY_SCOPY =     0o575s      // shifted copy key
    let [<Literal>] KEY_SCREATE =   0o576s      // shifted create key
    let [<Literal>] KEY_SDC =       0o577s      // shifted delete-character key
    let [<Literal>] KEY_SDL =       0o600s      // shifted delete-line key
    let [<Literal>] KEY_SELECT =    0o601s      // select key
    let [<Literal>] KEY_SEND =      0o602s      // shifted end key
    let [<Literal>] KEY_SEOL =      0o603s      // shifted clear-to-end-of-line key
    let [<Literal>] KEY_SEXIT =     0o604s      // shifted exit key
    let [<Literal>] KEY_SFIND =     0o605s      // shifted find key
    let [<Literal>] KEY_SHELP =     0o606s      // shifted help key
    let [<Literal>] KEY_SHOME =     0o607s      // shifted home key
    let [<Literal>] KEY_SIC =       0o610s      // shifted insert-character key
    let [<Literal>] KEY_SLEFT =     0o611s      // shifted left-arrow key
    let [<Literal>] KEY_SMESSAGE =  0o612s      // shifted message key
    let [<Literal>] KEY_SMOVE =     0o613s      // shifted move key
    let [<Literal>] KEY_SNEXT =     0o614s      // shifted next key
    let [<Literal>] KEY_SOPTIONS =  0o615s      // shifted options key
    let [<Literal>] KEY_SPREVIOUS = 0o616s      // shifted previous key
    let [<Literal>] KEY_SPRINT =    0o617s      // shifted print key
    let [<Literal>] KEY_SREDO =     0o620s      // shifted redo key
    let [<Literal>] KEY_SREPLACE =  0o621s      // shifted replace key
    let [<Literal>] KEY_SRIGHT =    0o622s      // shifted right-arrow key
    let [<Literal>] KEY_SRSUME =    0o623s      // shifted resume key
    let [<Literal>] KEY_SSAVE =     0o624s      // shifted save key
    let [<Literal>] KEY_SSUSPEND =  0o625s      // shifted suspend key
    let [<Literal>] KEY_SUNDO =     0o626s      // shifted undo key
    let [<Literal>] KEY_SUSPEND =   0o627s      // suspend key
    let [<Literal>] KEY_UNDO =      0o630s      // undo key
    let [<Literal>] KEY_MOUSE =     0o631s      // Mouse event has occurred
    let [<Literal>] KEY_RESIZE =    0o632s      // Terminal resize event
    let [<Literal>] KEY_EVENT =     0o633s      // We were interrupted by an event
    let [<Literal>] KEY_MAX =       0o777s      // Maximum key value is 0633
