using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VotingTimer : MonoBehaviour
{
    [SerializeField] float TimeLimit;

    //The time limit
    private float countDown;

    //Displaying the count down for voting
    [SerializeField]Text countdownDisplay;

    [SerializeField]GameObject VotingCanvas;

    void Awake()
    {
        TimeLimit = 10;
        this.countDown = TimeLimit;
    }

    void Update()
    {
        //Increasing the time counter
        countDown -= Time.deltaTime;

        //Displaying the countdown timer on the GUI
        countdownDisplay.text = ((int)countDown).ToString();

        //If the time counter reaches the time limit then the scene changes
        if(countDown <= 0)
        {
            VotingCanvas.SetActive(false);
            countDown = TimeLimit;
        }
    }
}