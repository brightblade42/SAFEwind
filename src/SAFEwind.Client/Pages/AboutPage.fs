module SAFEwind.Client.Pages.About

open Feliz

[<ReactComponent>]
let AboutPage () =
    Html.div [
        prop.text "This is the about page. Pretty sweet"
    ]