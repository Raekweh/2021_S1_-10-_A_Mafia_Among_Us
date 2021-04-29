using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LocalLobby()
    {
        SceneManager.LoadScene("startLoby");
    }

    // public void MultiplayerLobby()
    // {

    // }

    
    // public void HowToPlay()
    // {

    // }

    //Quits the game
    public void Quit()
    {
        Application.Quit();
    }
}