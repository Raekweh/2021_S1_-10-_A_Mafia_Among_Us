using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_Vents : MonoBehaviour
{
    [SerializeField] GameObject currentPanel;
    [SerializeField] GameObject nextPanel;
    [SerializeField] Transform NewPosition;
    public void ChangeVent()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        AU_PlayerController.localPlayer.transform.position = NewPosition.position;
    }
    public void ExitVent()
    {
        currentPanel.SetActive(false);
        AU_PlayerController.localPlayer.ExitVent();
    }
}