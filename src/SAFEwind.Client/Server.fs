﻿module SAFEwind.Client.Server

open Fable.Remoting.Client
open SAFEwind.Shared.API

let service =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Service.RouteBuilder
    |> Remoting.buildProxy<Service>