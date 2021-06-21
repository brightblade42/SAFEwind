module SAFEwind.Client.AppState
open Router
open Feliz.Router
open Elmish

type Model = {
    CurrentPage: Page
}

type Msg =
    | UrlChanged of currentPage:Page

let init () =
    let nextPage = (Router.currentPath() |> Page.parseFromUrlSegments)
    {
         CurrentPage = nextPage
    }, Cmd.none

let update (msg:Msg) (model:Model) : Model * Cmd<Msg> =
    match msg with
    | UrlChanged page  -> { model with CurrentPage = page }, Cmd.none
