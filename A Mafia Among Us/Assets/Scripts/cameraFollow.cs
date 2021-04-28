using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    
    public Transform playerCharacter;
    public float cameraDistance = 30.0f;

    void awake(){
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height /2) / cameraDistance);
    }
    void FixedUpdate(){

        transform.position = new Vector3(playerCharacter.position.x, playerCharacter.position.y, -10);
    }
}
