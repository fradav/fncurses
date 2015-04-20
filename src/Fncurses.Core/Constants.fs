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
    // TODO: these result in garbage on Windows???
    let NCURSES_ATTR_SHIFT = 8
    let NCURSES_BITS mask shift = mask <<< (shift + NCURSES_ATTR_SHIFT)
        
    let A_NORMAL     = 1u - 1u
    let A_STANDOUT   = NCURSES_BITS 1u  8
    let A_UNDERLINE  = NCURSES_BITS 1u  9
    let A_REVERSE    = NCURSES_BITS 1u 10
    let A_BLINK      = NCURSES_BITS 1u 11
    let A_DIM        = NCURSES_BITS 1u 12
    let A_BOLD       = NCURSES_BITS 1u 13
    let A_ALTCHARSET = NCURSES_BITS 1u 14
    let A_INVIS      = NCURSES_BITS 1u 15
    let A_PROTECT    = NCURSES_BITS 1u 16

// chtype: encodes a character, attributes and color-pair
//
//The following symbolic constants are used to manipulate attribute bits in objects of type chtype:
//
//A_ALTCHARSET   Alternate character set
//A_BLINK        Blinking
//A_BOLD         Extra bright or bold
//A_DIM          Half bright
//A_INVIS        Invisible
//A_PROTECT      Protected
//A_REVERSE      Reverse video
//A_STANDOUT     Best highlighting mode of the terminal
//A_UNDERLINE    Underlining
//
//These attribute flags need not be distinct  except when _XOPEN_CURSES is defined and the application sets _XOPEN_SOURCE_EXTENDED to 1.
//The following symbolic constants can be used as bit-masks to extract the components of a chtype:
//
//A_ATTRIBUTES   Bit-mask to extract attributes
//A_CHARTEXT     Bit-mask to extract a character
//A_COLOR        Bit-mask to extract colour-pair information
//
// short (16 bits)
// pdcurses: long (32 bits)
//    short form:
//
//    -------------------------------------------------
//    |15|14|13|12|11|10| 9| 8| 7| 6| 5| 4| 3| 2| 1| 0|
//    -------------------------------------------------
//      color number |  attrs |   character eg 'a'
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
//
//       Note that there is now a "super-long" 64-bit form,  available by
//    defining CHTYPE_LONG to be 2:
//
//    -------------------------------------------------------------------------------
//    |63|62|61|60|59|..|34|33|32|31|30|29|28|..|22|21|20|19|18|17|16|..| 3| 2| 1| 0|
//    -------------------------------------------------------------------------------
//             color number   |        modifiers      |         character eg 'a'
//
//
//       We take five more bits for the character (thus allowing Unicode values
//    past 64K;  UTF-16 can go up to 0x10ffff,  requiring 21 bits total),  and
//    four more bits for attributes.  Two are currently used as A_OVERLINE and
//    A_STRIKEOUT;  two more are reserved for future use.  31 bits are then used
//    for color.  These are usually just treated as the usual palette
//    indices,  and range from 0 to 255.   However,  if bit 63 is
//    set,  the remaining 30 bits are interpreted as foreground RGB (first
//    fifteen bits,  five bits for each of the three channels) and background RGB
//    (same scheme using the remaining 15 bits.)
