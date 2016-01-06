namespace Core

open UnityEngine

type HelloWorldComponent() = 
    inherit MonoBehaviour()
    
    member this.Start() = Debug.Log("Hello from F#")