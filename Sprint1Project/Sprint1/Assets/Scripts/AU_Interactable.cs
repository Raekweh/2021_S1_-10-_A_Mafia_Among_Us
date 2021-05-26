using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;

    VotingTimer time;

    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(false);
        }
    }
    
    //THis mini game is testing out the timer
    public void PlayMiniGame()
    {
        // time = GetComponent<VotingTimer>();
        // if(time.timer() == 0)
        // {
        //     miniGame.SetActive(false);
        // }
        miniGame.SetActive(true);
    }
}