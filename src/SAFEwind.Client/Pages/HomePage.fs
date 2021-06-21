module SAFEwind.Client.Pages.Index

open Feliz
open Feliz.UseDeferred
open SAFEwind.Client

[<ReactComponent>]
let HomePage () =
    let callReq,setCallReq = React.useState(Deferred.HasNotStartedYet)
    let call = React.useDeferredCallback((fun _ -> Server.service.GetMessage()), setCallReq)
    let title =
        match callReq with
        | Deferred.HasNotStartedYet -> "Click me!"
        | Deferred.InProgress -> "...loading"
        | Deferred.Resolved m -> m
        | Deferred.Failed err -> err.Message

    Html.button [
        prop.className ["mt-5 ml-5 text-red-800 text-2xl"]
        prop.text title
        prop.onClick call
    ]
