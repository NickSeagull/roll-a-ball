namespace Core

open UnityEngine

type PlayerController() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable speed: float32 = 10.0f

    member val rigidBody = null with get, set

    member this.Start() =
        this.rigidBody <- this.GetComponent<Rigidbody>()
    
    member this.FixedUpdate() = 
        let moveHorizontal = Input.GetAxis "Horizontal"
        let moveVertical = Input.GetAxis "Vertical"
        let movement = Vector3(moveHorizontal, 0.0f, moveVertical)
        
        movement * speed |> this.rigidBody.AddForce 