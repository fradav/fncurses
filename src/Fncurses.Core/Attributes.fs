namespace Fncurses.Core

[<AutoOpen>]
module Attributes =

    type IAttributes =
        abstract A_NORMAL : ChType with get
        abstract A_STANDOUT : ChType with get
        abstract A_UNDERLINE : ChType with get
        abstract A_REVERSE : ChType with get
        abstract A_BLINK : ChType with get
        abstract A_DIM : ChType with get
        abstract A_BOLD : ChType with get
        abstract A_ALTCHARSET : ChType with get
        abstract A_INVIS : ChType with get
        abstract A_PROTECT : ChType with get
        abstract A_HORIZONTAL : ChType with get
        abstract A_LEFT : ChType with get
        abstract A_LOW : ChType with get
        abstract A_RIGHT : ChType with get
        abstract A_TOP : ChType with get
        abstract A_VERTICAL : ChType with get

    let macAttributes () =
        let NCURSES_ATTR_SHIFT = 8
        let NCURSES_BITS mask shift = mask <<< (shift + NCURSES_ATTR_SHIFT)
        { new IAttributes with
            member this.A_NORMAL     = ChType.zero
            member this.A_STANDOUT   = NCURSES_BITS ChType.one  8 // bit 16
            member this.A_UNDERLINE  = NCURSES_BITS ChType.one  9 // bit 17
            member this.A_REVERSE    = NCURSES_BITS ChType.one 10 // bit 18
            member this.A_BLINK      = NCURSES_BITS ChType.one 11 // bit 19
            member this.A_DIM        = NCURSES_BITS ChType.one 12 // bit 20
            member this.A_BOLD       = NCURSES_BITS ChType.one 13 // bit 21
            member this.A_ALTCHARSET = NCURSES_BITS ChType.one 14 // bit 22
            member this.A_INVIS      = NCURSES_BITS ChType.one 15 // bit 23
            member this.A_PROTECT    = NCURSES_BITS ChType.one 16 // bit 24 
            member this.A_HORIZONTAL = NCURSES_BITS ChType.one 17 // bit 25
            member this.A_LEFT       = NCURSES_BITS ChType.one 18 // bit 26
            member this.A_LOW        = NCURSES_BITS ChType.one 19 // bit 27
            member this.A_RIGHT      = NCURSES_BITS ChType.one 20 // bit 28
            member this.A_TOP        = NCURSES_BITS ChType.one 21 // bit 29
            member this.A_VERTICAL   = NCURSES_BITS ChType.one 22 // bit 30
        }

    let nixAttributes = macAttributes

    // pdcurses attributes: long (32 bits)
    //    long form:
    //
    //    ----------------------------------------------------------------------------
    //    |31|30|29|28|27|26|25|24|23|22|21|20|19|18|17|16|15|14|13|12|..| 3| 2| 1| 0|
    //    ----------------------------------------------------------------------------
    //          color number      |     modifiers         |      character eg 'a'
    //
    //    The available non-color attributes are bold, underline, invisible,
    //    right-line, left-line, protect, reverse and blink. 256 color pairs (8
    //    bits), 8 bits for other attributes, and 16 bits for character data.        
    let winAttributes () =
        { new IAttributes with
            member this.A_NORMAL = 0u
            member this.A_STANDOUT   = this.A_REVERSE ||| this.A_BOLD
            member this.A_UNDERLINE  = ChType.ofInt 0x00100000   // bit 20
            member this.A_REVERSE    = ChType.ofInt 0x00200000   // bit 21
            member this.A_BLINK      = ChType.ofInt 0x00400000   // bit 22
            member this.A_DIM        = this.A_NORMAL             // not supported
            member this.A_BOLD       = ChType.ofInt 0x00800000   // bit 23
            member this.A_ALTCHARSET = ChType.ofInt 0x00010000   // bit 16
                                                                 // bit 17 A_RIGHTLINE
                                                                 // bit 18 A_LEFTLINE
            member this.A_INVIS      = ChType.ofInt 0x00080000   // bit 19
            member this.A_PROTECT    = this.A_UNDERLINE ||| ChType.ofInt 0x00040000 ||| ChType.ofInt 0x00020000 
            member this.A_HORIZONTAL = this.A_NORMAL             // not supported
            member this.A_LEFT       = this.A_NORMAL             // not supported
            member this.A_LOW        = this.A_NORMAL             // not supported
            member this.A_RIGHT      = this.A_NORMAL             // not supported
            member this.A_TOP        = this.A_NORMAL             // not supported
            member this.A_VERTICAL   = this.A_NORMAL             // not supported
        }

    let Attribute = Platform.dispatch macAttributes nixAttributes winAttributes
