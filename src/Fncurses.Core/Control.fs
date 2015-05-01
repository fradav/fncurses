namespace Fncurses.Core

module Check =

    open ExtCore.Control

    let cptrResult fname result =
        if result = NULL 
        then Choice.failwithf "%s returned NULL" fname
        else Choice.result result
    let cintResult fname result = 
        if result = ERR
        then Choice.failwithf "%s returned ERR" fname
        else Choice.result result
    let unitResult fname result = 
        if result = ERR
        then Choice.failwithf "%s returned ERR" fname
        else Choice.result ()
    let optionResult fname result =
        match result with
        | Some x -> Choice.result x
        | _ -> Choice.failwithf "%s returned none" fname
