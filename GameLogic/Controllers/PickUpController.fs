namespace Core

open UnityEngine

type PickUpController () =
    inherit MonoBehaviour ()

    member this.Update () =
        this.transform.Rotate(Vector3(15.0f, 30.0f, 45.0f) * Time.deltaTime)
