using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorTaskGame : MonoBehaviour
{
    [SerializeField] int nextButton;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject[] myObjects;


    void Start()
    {
        nextButton = 0;
    }

    private void OnEnable()
    {
        nextButton = 0;
        for(int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 9));
        }
    }

    public void ButtonOrder(int button)
    {
        Debug.Log("Pressed");
        if (button == nextButton)
        {
            nextButton++;
            Debug.Log("Next Button" + nextButton);
        }
        else
        {
            Debug.Log("Failed");
            Debug.Log("Next Button" + nextButton);
            nextButton = 0;
            OnEnable();
        }
        if (button == 9 && button == nextButton)
        {
            Debug.Log("Pass");
            nextButton = 0;
            ButtonOrderPanelClose();
        }
    }

    public void ButtonOrderPanelClose()
    {
        GamePanel.SetActive(false);
    }
    public void ButtonOrderPanelOpen()
    {
        GamePanel.SetActive(true);
    }
}
