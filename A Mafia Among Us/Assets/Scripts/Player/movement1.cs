using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement1 : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static movement1 localPlayer;

    Rigidbody rigidbod;
    Animator myAim;
    Transform myCharacter;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    private bool facingRight;

    //Player Color
    static Color myColor;
    SpriteRenderer myAvatarSprite;

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
        if(hasControl)
        {
            localPlayer = this;
        }

        rigidbod = GetComponent<Rigidbody>();
        myCharacter = transform.GetChild(0);

        //Setting facing right to true
        facingRight = true;

        myAvatarSprite = myAvatarSprite.GetComponent<SpriteRenderer>();
        if(myColor == Color.clear)
        {
            myColor = Color.white;
        }
        myAvatarSprite.color = myColor;
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

    private void FixedUpdate()
    {
        rigidbod.velocity = movementInput * movementSpeed;

        //Putting both vector x and y into the Flip
        Flip(movementInput);
    }

    //Changing the color
    public void SetColor(Color newColor)
    {
        myColor = myColor;
        if(myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
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
}