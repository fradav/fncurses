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
