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
        
    let A_NORMAL = 0u
    let PDC_CHARTEXT_BITS = 21
    let A_CHARTEXT   = (0x1u <<< PDC_CHARTEXT_BITS) - 1u
    let A_ALTCHARSET = 0x001u <<< PDC_CHARTEXT_BITS
    let A_RIGHTLINE  = 0x002u <<< PDC_CHARTEXT_BITS
    let A_LEFTLINE   = 0x004u <<< PDC_CHARTEXT_BITS
    let A_INVIS      = 0x008u <<< PDC_CHARTEXT_BITS
    let A_UNDERLINE  = 0x010u <<< PDC_CHARTEXT_BITS
    let A_REVERSE    = 0x020u <<< PDC_CHARTEXT_BITS
    let A_BLINK      = 0x040u <<< PDC_CHARTEXT_BITS
    let A_BOLD       = 0x080u <<< PDC_CHARTEXT_BITS
    let A_OVERLINE   = 0x100u <<< PDC_CHARTEXT_BITS
    let A_STRIKEOUT  = 0x200u <<< PDC_CHARTEXT_BITS
    let A_DIM        = 0x400u <<< PDC_CHARTEXT_BITS

