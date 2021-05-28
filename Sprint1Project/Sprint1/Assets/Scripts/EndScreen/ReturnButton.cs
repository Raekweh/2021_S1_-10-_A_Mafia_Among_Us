using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    //After pressing the return button then it will return the player to the main menu
    public void MenuScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}