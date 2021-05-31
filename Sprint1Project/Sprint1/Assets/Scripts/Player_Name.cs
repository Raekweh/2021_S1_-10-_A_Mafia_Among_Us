using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player_Name : MonoBehaviour
{
    public InputField nameField;
    public Button setName;
    
    public void onNFChange()
    {
        if(nameField.text.Length > 1)
        {
            setName.interactable = true;
        }
        else
        {
            setName.interactable = false;
        }
    }

    public void onClickSetName()
    {
        PhotonNetwork.NickName = nameField.text;
    }
}
