using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_Vents : MonoBehaviour
{
    [SerializeField] GameObject currentVent;
    [SerializeField] GameObject nextVent;

    [SerializeField] Transform newPosition;

    public void ChangeVent()
    {
        currentVent.SetActive(false);
        nextVent.SetActive(true);
        AU_PlayerController.localPlayer.transform.position = newPosition.position;
    }

    public void ExitVent()
    {
        currentVent.SetActive(false);
        AU_PlayerController.localPlayer.ExitVent();
    }
}
