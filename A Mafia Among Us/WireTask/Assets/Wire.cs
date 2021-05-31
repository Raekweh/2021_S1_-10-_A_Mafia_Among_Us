using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd; 
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition; 

    void Start()
    {
        startPoint = transform.parent.position; 
        startPosition = transform.position;
    }


    private void OnMouseDrag()
    {
        //Mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;


        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        { 
            if (collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }

        }
        UpdateWire(newPosition);
    }

    void Done()
    {
        lightOn.SetActive(true);
        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
          //update wire
         transform.position = newPosition;

        // // //update direction
        
        // original Vector3 direction = newPosition - startPoint; FIX THIS ! ! ! ! ! 
         Vector3 direction = (newPosition -  startPoint);
         transform.right = (direction * transform.lossyScale.x); 

        // //update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
} 