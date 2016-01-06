namespace Core

open UnityEngine

type CameraController () =
    inherit MonoBehaviour ()


    [<SerializeField>]
    let mutable player: GameObject = null


    let mutable offset = Vector3.one


    member this.Start () = 
        offset <- this.transform.position - player.transform.position


    member this.LateUpdate () =
        this.transform.position <- player.transform.position + offset