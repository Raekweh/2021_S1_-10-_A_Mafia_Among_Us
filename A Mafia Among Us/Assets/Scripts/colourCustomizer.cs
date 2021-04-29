using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class colourCustomizer : MonoBehaviour
{

    [SerializeField] Color[] allColours;

    public void setColour(int colourIndex){
        playerMovement.localPlayer.setColour(allColours[colourIndex]);

    }

    // public void nextScene(int sceneIndex){
    //     SceneManagement.LoadScene(sceneIndex);
    // }

}
