module SAFEwind.Client.App

open Feliz
open Elmish
open Feliz.UseElmish
open Router
open AppState

[<ReactComponent>]
let AppView (props: {| model: Model; dispatch:Dispatch<Msg>; |}) =

    let navigation =
         Components.AppBar {| model=props.model; dispatch=props.dispatch |}

    let render =
        match props.model.CurrentPage with
        | Page.Index -> Pages.Index.HomePage ()
        | Page.About -> Pages.About.AboutPage ()

    React.router [
        router.pathMode
        router.onUrlChanged (Page.parseFromUrlSegments >> UrlChanged >> props.dispatch)
        router.children [ navigation; render ]
    ]


[<ReactComponent>]
let App () =

    let model,dispatch = React.useElmish(init, update, [|  |])
    AppView {| model=model; dispatch=dispatch |}
