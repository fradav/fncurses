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
