open ExtCore
open ExtCore.Control.Collections
open ExtCore.Control.WorkflowBuilders
open Fncurses.Core

type Environment = 
    { Random: System.Random }

let color_table =
    [| Color.COLOR_RED; Color.COLOR_BLUE; Color.COLOR_GREEN; Color.COLOR_CYAN;
       Color.COLOR_RED; Color.COLOR_MAGENTA; Color.COLOR_YELLOW; Color.COLOR_WHITE |]
    
let environment argv =
     { Random = System.Random() }

let userQuit ()  =
    ncurses {
        match getch () with
        | Success _ -> return false
        | Error _ -> return true
    }

let rec loop () =
    ncurses {
        let! quit = userQuit ()

        if quit then
            return ()
        else
            return! loop ()
    }

let run env =
    ncurses {
        let! win = initscr ()
        do! nodelay win true
        do! noecho ()
        do! nonl ()
        do! refresh ()

        if has_colors () then
            do! start_color ()

        do! color_table
            |> Choice.Array.iteri (fun i color ->
                   init_pair (int16 i) color Color.COLOR_BLACK)

        return! loop ()        
    }
    
[<EntryPoint>]
let main argv =
    let result =
      ncurses {
          let env = environment argv
          return! run env
      }
  
    match result with
    | Success _ -> 0
    | Error reason -> printfn "%s" reason; -1
