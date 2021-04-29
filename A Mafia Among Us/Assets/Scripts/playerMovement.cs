using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    [SerializeField] bool hasControl;
    public static playerMovement localPlayer;

    static Color myColour;
    SpriteRenderer myAvatarSprite;

    Rigidbody2D rigidbod;
    Transform myCharacter;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    private bool facingRight;


    private void OnEnable()
    {
        WASD.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
    }

    void Start()
    {
        if(hasControl){
            localPlayer = this;
        }

        rigidbod = GetComponent<Rigidbody2D>();
        myCharacter = transform.GetChild(0);
        myAvatarSprite = myCharacter.GetComponent<SpriteRenderer>();

        if(myColour == Color.clear)
        {
            myColour = Color.white;
        }
        myAvatarSprite.color = myColour;

        //Setting facing right to true
        facingRight = true;
    }

    // Update is called once per frame
    public void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();

        if(movementInput.x != 0)
        {
            myCharacter.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }
    }

    void FixedUpdate()
    {
        rigidbod.velocity = movementInput * movementSpeed;

        //Putting both vector x and y into the Flip
        Flip(movementInput);
    }

    //Flipping the character model
    private void Flip(Vector2 movementInput)
    {
        if(movementInput.x > 0 && !facingRight || movementInput.x < 0 && facingRight)
        {
            //Setting the facing right to false since the model will be facing the left side
            facingRight = !facingRight;

            Vector2 theScale = transform.localScale;

            //Setting the scale to the opposite side
            theScale.x *= -1;

            //Update the local scale
            transform.localScale = theScale;
        }
    }

    public void setColour(Color newColour){
        myColour = newColour;
        if(myAvatarSprite != null){
            myAvatarSprite.color = myColour;
        }
    }
}