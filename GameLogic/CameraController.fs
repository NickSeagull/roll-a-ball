namespace Core

open UnityEngine

type CameraController () =
    inherit MonoBehaviour ()


    [<SerializeField>]
    let mutable player: GameObject = null


    member val offset = Vector3.one with get, set


    member this.Start () = 
        this.offset <- this.transform.position - player.transform.position


    member this.LateUpdate () =
        this.transform.position <- player.transform.position + this.offset