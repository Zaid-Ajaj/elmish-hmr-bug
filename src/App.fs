module App

open Fable.React 
open Fable.Core.JsInterop
open Fable.React.Props

type State = { Count : int }

type Msg = 
    | Increment
    | Decrement 

let init() = { Count = 5 } 

let update msg state = 
    match msg with 
    | Increment -> { state with Count = state.Count + 1 }
    | Decrement -> { state with Count = state.Count - 1 }

let view state dispatch = 
    div [ Class "full-width" ] [ 
        div [ Class "center" ] [
            h1 [ Class "center" ] [ str "Hello Fable!!!" ]
            div [ Class "divider" ] [ ]
            img [ Src (importDefault "./assets/logo.png"); Style [ Height 200 ]]
            h2 [ Class "center" ] [ str (sprintf "%d" state.Count) ] 
            div [ Class "grid" ] [ 
                button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
                button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ] 
            ]
        ]
    ]
  
open Elmish 
open Elmish.React
open Elmish.HMR 

Program.mkSimple init update view 
|> Program.withReactSynchronous "elmish-app"
|> Program.run