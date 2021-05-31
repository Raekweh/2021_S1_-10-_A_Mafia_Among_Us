using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd; 
    Vector3 startPoint;

    void Start()
    {
        startPoint = transform.parent.position; 
    }


    private void OnMouseDrag()
    {
        // Debug.Log("Dragging");
        //Mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //update wire
         transform.position = newPosition;

        // // //update direction
        
        // // original Vector3 direction = newPosition - startPoint; FIX THIS ! ! ! ! ! 
        //  Vector3 direction = newPosition - startPoint ;
        //  transform.right = direction * transform.lossyScale.x; // ??????????

        // // //update scale
        // float dist = Vector2.Distance(startPoint, newPosition);
        // wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
} 