using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement1 : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static movement1 localPlayer;

<<<<<<< HEAD:A Mafia Among Us/Assets/Scripts/PlayerMovement/movement1.cs
    Rigidbody rigidbod;
    Animator myAim;
=======
    Rigidbody2D rigidbod;
>>>>>>> Developement:A Mafia Among Us/Assets/Scripts/Player/movement1.cs
    Transform myCharacter;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    private bool facingRight;

<<<<<<< HEAD:A Mafia Among Us/Assets/Scripts/PlayerMovement/movement1.cs
    //Player Color
    static Color myColor;
    SpriteRenderer myAvatarSprite;
=======
>>>>>>> Developement:A Mafia Among Us/Assets/Scripts/Player/movement1.cs

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
<<<<<<< HEAD:A Mafia Among Us/Assets/Scripts/PlayerMovement/movement1.cs
        if(hasControl)
        {
            localPlayer = this;
        }

        rigidbod = GetComponent<Rigidbody>();
=======
        rigidbod = GetComponent<Rigidbody2D>();
>>>>>>> Developement:A Mafia Among Us/Assets/Scripts/Player/movement1.cs
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