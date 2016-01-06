namespace Core

open UnityEngine
open UnityEngine.UI

type PlayerController() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable totalPickUps: int = 0

    [<SerializeField>]
    let mutable speed: float32 = 10.0f

    [<SerializeField>]
    let mutable scoreText: Text = null

    [<SerializeField>]
    let mutable winText: Text = null

    member val rigidBody = null with get, set
    member val score = -1 with get, set

    member this.Start() =
        this.rigidBody <- this.GetComponent<Rigidbody>()
        this.score <- 0
        scoreText.text <- "Score: " + this.score.ToString ()
        winText.text <- ""
    
    member this.FixedUpdate() = 
        let moveHorizontal = Input.GetAxis "Horizontal"
        let moveVertical = Input.GetAxis "Vertical"
        let movement = Vector3(moveHorizontal, 0.0f, moveVertical)
        
        movement * speed |> this.rigidBody.AddForce 

    member this.OnTriggerEnter(other: Collider) =
        if other.gameObject.CompareTag "Pick Up"  then
            other.gameObject.SetActive false
            this.score <- this.score + 1
            this.updateScore 

    member private this.updateScore =
        scoreText.text <- "Score: " + this.score.ToString ()
        if this.score >= totalPickUps then
            winText.text <- "YOU WIN!"
            scoreText.text <- ""