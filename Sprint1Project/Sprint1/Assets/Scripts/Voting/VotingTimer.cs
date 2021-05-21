using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VotingTimer : MonoBehaviour
{
    //The time limit
    [SerializeField] private float timeLimit;

    //Timer being counted up to the time limit

    [SerializeField]Text countdownDisplay;

    void start()
    {
        timeLimit = 10F;
    }

    void Update()
    {
        //Increasing the time counter
        this.timeLimit -= Time.deltaTime;

        //Displaying the countdown timer on the GUI
        countdownDisplay.text = ((int)timeLimit).ToString();

        //If the time counter reaches the time limit then the scene changes
        if(timeLimit <= 0)
        {
             SceneManager.LoadScene("Game");
        }
    }
}
