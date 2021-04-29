using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    [SerializeField]
    Button killButton;

    [SerializeField]
    float cooldownDuration = 60.0f;

    
    void Awake()
    {
        //Get the reference of the kill button
        killButton = GetComponent<Button>();

    //Check if the button exist or not 
        if(killButton != null)
        {
            //Listen to its onClick Event
            killButton.onClick.AddListener(onButtonClick);
        }
    }

    //This method is called whenever the kill button is pressed
    void onButtonClick()
    {
        //This will deactivate the button
        StartCoroutine(CoolDown());
    }

    //
    IEnumerator CoolDown()
    {
        //Deactivate the button
        killButton.interactable = false;

        //Wait for the cooldown duration
        yield return new WaitForSeconds(cooldownDuration);

        //Reactivate the button
        killButton.interactable = true;
    }
}
