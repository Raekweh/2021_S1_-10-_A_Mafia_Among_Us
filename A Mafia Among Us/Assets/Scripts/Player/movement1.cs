using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement1 : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static movement1 localPlayer;

    Rigidbody rigidbod;
    Transform myCharacter;
    Animator myAnim;
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
    float killInput;

    List<movement1> targets;

    //movement1 target;
    [SerializeField] Collider myCollider;

    bool isDead;

    [SerializeField] GameObject bodyPrefab;

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

        targets = new List<movement1>();

        rigidbod = GetComponent<Rigidbody>();
        myCharacter = transform.GetChild(0);
        myAnim = GetComponent<Animator>();

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

        /*
         if(movementInput.x !=0 || movementInput.y != 0)
         {
             myAnim.SetBool("isMoving", true); 

         }
        */

        myAnim.SetFloat("speed", movementInput.magnitude);
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
        //myColor = myColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }

    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }

    private void OnTriggerEnter(Collider other)
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
                    targets.Add(tempTarget);
                   
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            movement1 tempTarget = other.GetComponent<movement1>();
            if (targets.Contains(tempTarget))
            {
                targets.Remove(tempTarget);
            }
        }
    }


        void KillTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (targets.Count==0)
                return;
            else
            {
                if (targets[targets.Count-1].isDead)
                    return;
                transform.position = targets[targets.Count-1].transform.position;
                targets[targets.Count-1].Die();
                targets.RemoveAt(targets.Count - 1);
            }
        }
    }

    public void Die()
    {
        isDead = true;
        myAnim.SetBool("isDead", isDead);
        myCollider.enabled = false;

        playerBody tempBody =Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<playerBody>();
        tempBody.SetColor(myAvatarSprite.color);
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