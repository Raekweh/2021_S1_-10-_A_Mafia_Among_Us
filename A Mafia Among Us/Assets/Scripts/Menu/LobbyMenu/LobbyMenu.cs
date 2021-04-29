using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMenu : MonoBehaviour
{
    //Method to change scenes to back to Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GamePlay()
    {
        SceneManager.LoadScene("Map");
    }
}