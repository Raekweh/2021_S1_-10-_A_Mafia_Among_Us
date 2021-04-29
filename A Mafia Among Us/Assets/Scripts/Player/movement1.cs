using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement1 : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static movement1 localPlayer;

    Rigidbody rigidbod;
    Animator myAnim;
    Transform myCharacter;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    private bool facingRight;

    //Player Color
    static Color myColor;
    SpriteRenderer myAvatarSprite;

    //Player Role
    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;
   // float killInput;

    movement1 target;
    [SerializeField] Collider myCollider;

    bool isDead;

    private void Awake()
    {
        KILL.performed += KillTarget;
    }




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

        rigidbod = GetComponent<Rigidbody>();
        myCharacter = transform.GetChild(0);

        //Setting facing right to true
        facingRight = true;

        myAvatarSprite = myAvatarSprite.GetComponent<SpriteRenderer>();
        if (myColor == Color.clear)
        {
            myColor = Color.white;
        }
        if (!hasControl)
            return;
        myAvatarSprite.color = myColor;

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!hasControl)
            return;

        movementInput = WASD.ReadValue<Vector2>();

        if(movementInput.x != 0)
        {
            myCharacter.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        myAnim.SetFloat("zSpeed", movementInput.magnitude);
    }

    void FixedUpdate()
    {
        rigidbod.velocity = movementInput * movementSpeed;

        //Putting both vector x and y into the Flip
        Flip(movementInput);
    }

    //Changing the color
    public void SetColor(Color newColor)
    {
        myColor = myColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }

    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            movement1 tempTarget = other.GetComponent<movement1>();
            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                {
                    target = tempTarget;
                    Debug.Log(target.name);
                }
            }
        }

    }

    void KillTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (target == null)
                return;
            else
            {
                if (target.isDead)
                    return;
                transform.position = target.transform.position;
                target.Die();
                target = null;
            }
        }
    }

    public void Die()
    {
        isDead = true;
        myAnim.SetBool("isDead", isDead);
        myCollider.enabled = false;
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