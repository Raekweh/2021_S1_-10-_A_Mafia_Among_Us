using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRb;
    Transform myAvatar;
    Animator myAnimator;

    [SerializeField] InputAction WASD;
    [SerializeField] float movementSpeed;

    Vector2 movementInput;

    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;

    static Color myColour;
    SpriteRenderer myAvatarSprite;

    [SerializeField] bool hasControl;
    public static PlayerController localPlayer;


    private void OnEnable()
    {
        WASD.Enable();
        KILL.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
        KILL.Disable();
    }

    void Start()
    {
        if (hasControl)
        {
            localPlayer = this;
        }

        myRb = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);

        myAnimator = GetComponent<Animator>();

        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
        if (myColour == Color.clear)
            myColour = Color.white;
        myAvatarSprite.color = myColour;
    }


    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();

        if(movementInput.x != 0)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        myAnimator.SetFloat("Speed", movementInput.magnitude);
    }

    private void FixedUpdate()
    {
        myRb.velocity = movementInput * movementSpeed;
    }

    public void SetColor(Color newColour)
    {
        myColour = newColour;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColour;
        }
    }

}
