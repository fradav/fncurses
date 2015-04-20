namespace Fncurses.Core

[<AutoOpen>]
module Constants =

    open System
        
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

    // TODO: 32 bit constants?
    // TODO: mac / nix constants?
    // https://github.com/D-Programming-Deimos/ncurses/blob/master/deimos/ncurses/curses.d
        
    let A_NORMAL     = 1u - 1u
    let A_STANDOUT   = 1u <<< (8 + 8)
    let A_UNDERLINE  = 1u <<< (9 + 8)
    let A_REVERSE    = 1u <<< (10 + 8)
    let A_BLINK      = 1u <<< (11 + 8)
    let A_DIM        = 1u <<< (12 + 8)
    let A_BOLD       = 1u <<< (13 + 8)
    let A_ALTCHARSET = 1u <<< (14 + 8)
    let A_INVIS      = 1u <<< (15 + 8)
    let A_PROTECT    = 1u <<< (16 + 8)
    let A_HORIZONTAL = 1u <<< (17 + 8)
    let A_LEFT       = 1u <<< (18 + 8)
    let A_LOW        = 1u <<< (19 + 8)
    let A_RIGHT      = 1u <<< (20 + 8)
    let A_TOP        = 1u <<< (21 + 8)
    let A_VERTICAL   = 1u <<< (22 + 8)
