using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KepadTask : MonoBehaviour
{
    [SerializeField] private Text cardCode;
    [SerializeField] Text inputCode; 
    [SerializeField] int codeLength =5;
    [SerializeField] float codeResetTimeInSeconds = 0.5f;
    private bool isResetting = false;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject TaskSprite;
    private void OnEnable()
    {
        string code = string.Empty;

        //Will generate a random set of numbers which will be saved to a string
        for(int i = 0; i < codeLength; i++)
        {
            code += Random.Range(1, 10);
        }
        
        //T
        cardCode.text = code;
        inputCode.text = string.Empty;
    }

    //When the button is clicked the number will be added to the input code
    public void ButtonClick(int number)
    {
        //When the user fails and will have to reset the input.
        if (isResetting)
        {
            return;
        }
        
        //This will add the number the user's input into the UI text on unity
        inputCode.text += number;

        //The input code text matches the card code text
        if (inputCode.text == cardCode.text)
        {
            //The input code will tell the user they suceeded
            inputCode.text = "Correct";
            StartCoroutine(ResetCode());

            //Stops the user from interacting with the object again
            Destroy(GamePanel);
            Destroy(TaskSprite);
        }
        //The input code is not the same as code
        else if(inputCode.text.Length >= codeLength)
        {
            //This will indicate the user they failed
            inputCode.text = "Failed";
            StartCoroutine(ResetCode());
        }
    }

    //Resets the code
    private IEnumerator ResetCode()
    {
        isResetting = true;
        yield return new WaitForSeconds(codeResetTimeInSeconds);
        inputCode.text = string.Empty;
        isResetting = false;
    }
}