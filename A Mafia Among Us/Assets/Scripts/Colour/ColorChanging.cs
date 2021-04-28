using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanging : MonoBehaviour
{
    [SerializeField] Color[] allColors;
    public void SetColor(int colorIndex)
    {
        movement1.localPlayer.SetColor(allColors[colorIndex]);
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
