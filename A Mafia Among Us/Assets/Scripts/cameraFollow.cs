/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    
    public Transform playerCharacter;
    public float cameraDistance = 30.0f;
    public float playerx;
    public float playery;

    void awake(){
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height /2) / cameraDistance);
    }
    void FixedUpdate(){

        if(playerCharacter.position.y>23){
            playery = 23;
        }
        else if(playerCharacter.position.y<-139){
            playery = -139;
        }
        else
        {
            playery = playerCharacter.position.y;
            
        }

        if(playerCharacter.position.x<-190){
            playerx = -190;
        }
        else if(playerCharacter.position.x>107){
            playerx = 107;
        }
        else
        {
            playerx = playerCharacter.position.x;
            
        }

        transform.position = new Vector3(playerx, playery , -5);
    }
}
*/