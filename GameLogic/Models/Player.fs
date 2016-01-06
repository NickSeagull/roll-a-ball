namespace Core.Models

type Player (position: int, speed: float32) =

    member this.position
        with public get () = position

    member this.speed
        with public get () = speed
