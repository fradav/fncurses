namespace Fncurses.Core

[<AutoOpen>]
module Colors =

    open System
        
    type IColors =
        abstract COLOR_BLACK : CInt with get
        abstract COLOR_RED : CInt with get
        abstract COLOR_GREEN : CInt with get
        abstract COLOR_YELLOW : CInt with get
        abstract COLOR_BLUE : CInt with get
        abstract COLOR_MAGENTA : CInt with get
        abstract COLOR_CYAN : CInt with get
        abstract COLOR_WHITE : CInt with get
        abstract A_COLOR : ChType with get
        abstract COLOR_PAIR : CInt -> ChType
        abstract PAIR_NUMBER : ChType -> CInt
        
// TODO mac colors???
//#define NCURSES_ATTR_SHIFT       8
//#define NCURSES_BITS(mask,shift) ((mask) << ((shift) + NCURSES_ATTR_SHIFT))
// NCURSES_CAST type value
//#define A_COLOR		NCURSES_BITS(((@cf_cv_1UL@) << 8) - @cf_cv_1UL@,0)
//#define COLOR_PAIR(n)	NCURSES_BITS(n, 0)
//#define PAIR_NUMBER(a)	(NCURSES_CAST(int,((NCURSES_CAST(unsigned long,a) & A_COLOR) >> NCURSES_ATTR_SHIFT)))
    let macColors () =
        let NCURSES_ATTR_SHIFT = 8
        let NCURSES_BITS mask shift = mask <<< (shift + NCURSES_ATTR_SHIFT)        
        { new IColors with
            member this.COLOR_BLACK   = 0s
            member this.COLOR_RED     = 1s
            member this.COLOR_GREEN   = 2s
            member this.COLOR_YELLOW  = 3s
            member this.COLOR_BLUE    = 4s
            member this.COLOR_MAGENTA = 5s
            member this.COLOR_CYAN    = 6s
            member this.COLOR_WHITE   = 7s
            member this.A_COLOR       = NCURSES_BITS ((ChType.one <<< 8) - ChType.one) 0        
            member this.COLOR_PAIR n  = NCURSES_BITS (ChType.ofCInt n) 0
            member this.PAIR_NUMBER a = CInt.ofChType ((a &&& this.A_COLOR) >>> NCURSES_ATTR_SHIFT) }

    let nixColors = macColors

//#define PDC_COLOR_SHIFT 24
//#define A_COLOR      (chtype)0xff000000
//#define COLOR_PAIR(n)      (((chtype)(n) << PDC_COLOR_SHIFT) & A_COLOR)
//#define PAIR_NUMBER(n)     (((n) & A_COLOR) >> PDC_COLOR_SHIFT)
    let winColors () =
        let PDC_COLOR_SHIFT = 24
        { new IColors with
            member this.COLOR_BLACK   = 0s
            member this.COLOR_RED     = 1s
            member this.COLOR_GREEN   = 2s
            member this.COLOR_YELLOW  = 3s
            member this.COLOR_BLUE    = 4s
            member this.COLOR_MAGENTA = 5s
            member this.COLOR_CYAN    = 6s
            member this.COLOR_WHITE   = 7s
            member this.A_COLOR       = ChType.ofInt 0xff000000
            member this.COLOR_PAIR n  = ((ChType.ofCInt n) <<< PDC_COLOR_SHIFT) &&& this.A_COLOR
            member this.PAIR_NUMBER a = CInt.ofChType ((a &&& this.A_COLOR) >>> PDC_COLOR_SHIFT) }

    let Color = Platform.dispatch macColors nixColors winColors

// TODO windows colors RGB or BGR???

//#define COLOR_BLACK   0
//
//#ifdef PDC_RGB        /* RGB */
//# define COLOR_RED    1
//# define COLOR_GREEN  2
//# define COLOR_BLUE   4
//#else                 /* BGR */
//# define COLOR_BLUE   1
//# define COLOR_GREEN  2
//# define COLOR_RED    4
//#endif
//
//#define COLOR_CYAN    (COLOR_BLUE | COLOR_GREEN)
//#define COLOR_MAGENTA (COLOR_RED | COLOR_BLUE)
//#define COLOR_YELLOW  (COLOR_RED | COLOR_GREEN)
//
//#define COLOR_WHITE   7

