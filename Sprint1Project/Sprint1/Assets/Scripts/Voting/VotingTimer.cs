using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VotingTimer : MonoBehaviour
{
    //The time limit
    [SerializeField] private float timeLimit;

    //Displaying the count down for voting
    [SerializeField]Text countdownDisplay;

    [SerializeField]GameObject VotingCanvas;

    void Update()
    {
        //Increasing the time counter
        this.timeLimit -= Time.deltaTime;

        //Displaying the countdown timer on the GUI
        countdownDisplay.text = ((int)timeLimit).ToString();

        //If the time counter reaches the time limit then the scene changes
        if(timeLimit <= 0)
        {
            VotingCanvas.SetActive(false);
            timeLimit = 0;
        }
    }
}