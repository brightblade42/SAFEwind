module SAFEwind.Client.View

open Feliz
open Elmish
open Feliz.UseElmish
open Router
open SharedView


type Model = {
    Count: int
}

type Msg = | GetCount
let init () = { Count = 0 }, Cmd.none
let update (msg:Msg) (model:Model) : Model * Cmd<Msg> =
    match msg with
    | GetCount -> { model with Count = 1; }, Cmd.none

[<ReactComponent>]
let AppView () =
    let page,setPage = React.useState(Router.currentPath() |> Page.parseFromUrlSegments)
    let model,disp = React.useElmish(init, update, [|  |])
    // routing for full refreshed page (to fix wrong urls)
    React.useEffectOnce (fun _ -> Router.navigatePage page)

    let navigation =
        Html.div [
            prop.className [ "bg-bgray-500"]
            prop.children [
                Html.a("Home", Page.Index)
                Html.span " | "
                Html.a("About", Page.About)
            ]
        ]
    let render =
        match page with
        | Page.Index -> Pages.Index.IndexView ()
        | Page.About -> Html.text "SAFEr Template"
    React.router [
        router.pathMode
        router.onUrlChanged (Page.parseFromUrlSegments >> setPage)
        router.children [ navigation; render ]
    ]
