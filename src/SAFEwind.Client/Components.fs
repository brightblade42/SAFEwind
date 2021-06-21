module SAFEwind.Client.Components

open Feliz
open Elmish
open AppState
open Router

type JSX =

    [<ReactComponent(import="AppBar", from="./src/appbar.tsx")>]
    static member AppBar (props: {| model: Model; onNav: string->unit |}) = React.imported()


let AppBar (props: {| model:Model; dispatch: Dispatch<Msg> |}) =

    let on_nav (goto:string) =
        match goto with
        | "home"    -> Router.navigatePage  Index
        | "about"   ->  Router.navigatePage About //make About
        | _          -> Router.navigatePage Index
    ()

    JSX.AppBar {| model= props.model; onNav=on_nav |}