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

    static Color myColour;
    SpriteRenderer myAvatarSprite;

    [SerializeField] bool hasControl;
    public static PlayerController localPlayer;

    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;

    List<PlayerController> targets;
    [SerializeField] Collider myCollider;

    bool isDead;

    [SerializeField] GameObject bodyPrefab;



    private void Awake()
    {
        KILL.performed += KILLTarget;
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

        targets = new List<PlayerController>();

        myRb = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);

        myAnimator = GetComponent<Animator>();

        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
        if (myColour == Color.clear)
            myColour = Color.white;
        if (hasControl)
        {
            myAvatarSprite.color = myColour;
        }
        else
            return;

        
    }


    void Update()
    {
        if (!hasControl)
        {
            return;
        }
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

    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController tempTarget = other.GetComponent<PlayerController>();
            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                {
                    targets.Add(tempTarget);
                    //Debug.Log(target.name);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController tempTarget = other.GetComponent<PlayerController>();
            if (targets.Contains(tempTarget))
            {
                targets.Remove(tempTarget);
            }
        }
    }

    void KILLTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (targets.Count == 0)
            {
                return;
            }
            else
            {
                if (targets[targets.Count - 1].isDead)
                    return;

                transform.position = targets[targets.Count - 1].transform.position;
                targets[targets.Count - 1].Die();
                targets.RemoveAt(targets.Count - 1);

            }
        }
    }

    public void Die()
    {

        isDead = true;
        myAnimator.SetBool("IsDead", isDead);
        myCollider.enabled = false;

        DeadBody tempBody = Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<DeadBody>();
        tempBody.SetColor(myAvatarSprite.color);
    }

}
