using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeadBody : MonoBehaviour
{
    [SerializeField] SpriteRenderer bodySprite;

    public void SetColor(Color newColour)
    {
        bodySprite.color = newColour;
    }
}
