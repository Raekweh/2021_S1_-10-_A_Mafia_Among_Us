using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    
    public Transform playerCharacter;
    
    void FixedUpdate(){

        transform.position = new Vector3(playerCharacter.position.x, playerCharacter.position.y, -10);
    }
}
