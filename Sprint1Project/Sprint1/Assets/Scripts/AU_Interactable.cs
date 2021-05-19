using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;

    private void OnEnable()
    {
        //Initialize our highlight variable
        highlight = transform.GetChild(0).gameObject;
    }

    //If the player collides with another object
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            highlight.SetActive(true);
        }
    }

    //If the other object is leaving the player object
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(false);
        }
    }

    public void PlayMiniGame()
    {
        miniGame.SetActive(true);
    }
}