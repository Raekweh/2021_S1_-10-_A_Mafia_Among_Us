using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AU_PlayerController : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static AU_PlayerController localPlayer;

    //key used to inspect player
    bool isInspectAni;

    //Components
    Rigidbody myRB;
    Animator myAnim;
    Transform myAvatar;
    //Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    //Player Color
    [SerializeField] Color myColor;
    SpriteRenderer myAvatarSprite;
    //Role

    [SerializeField] bool isAngel;
    [SerializeField] InputAction REVIVE;
    float reviveInput;

    [SerializeField] bool isInspector;
    [SerializeField] InputAction INSPECTT;
    float inspecttInput;



    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;
    float killInput;
    List<AU_PlayerController> targets;
    [SerializeField] Collider myCollider;
    bool isDead;
    
    [SerializeField] GameObject bodyPrefab;
    public static List<Transform> allBodies;
    List<Transform> bodiesFound;
    [SerializeField] InputAction REPORT;
    [SerializeField] LayerMask ignoreForBody;

    private void Awake()
    {
        KILL.performed += KillTarget;
        REPORT.performed += ReportBody;
        REVIVE.performed += ReviveTarget;
        INSPECTT.performed += InspecttTarget;
    }

    //This method enables the movement input, killing and reporting functionality
    private void OnEnable()
    {
        WASD.Enable();
        KILL.Enable();
        REPORT.Enable();
        REVIVE.Enable();
        INSPECTT.Enable();
    }

    //This method disables the movement input, killing and reporting functionality
    private void OnDisable()
    {
        WASD.Disable();
        KILL.Disable();
        REPORT.Disable();
        REVIVE.Disable();
        INSPECTT.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (hasControl)
        {
            localPlayer = this;
        }

        targets = new List<AU_PlayerController>();
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        myAvatar = transform.GetChild(0);
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
        if (!hasControl)
            return;
        if (myColor == Color.clear)
            myColor = Color.white;
        myAvatarSprite.color = myColor;

        allBodies = new List<Transform>();
        bodiesFound = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasControl)
            return;
        movementInput = WASD.ReadValue<Vector2>();
        myAnim.SetFloat("Speed", movementInput.magnitude);
        if (movementInput.x != 0)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
            isInspectAni = false;
            myAnim.SetBool("isInspectAni", isInspectAni);
        }
        if (movementInput.y != 0)
        {
            isInspectAni = false;
            myAnim.SetBool("isInspectAni", isInspectAni);
        }
        if (allBodies.Count > 0)
        {
            BodySearch();
        }
    }

    //updates the velocity of the rigidbody aka character
    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }

    //sets the colour of the avatar sprite to newColor
    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }

    //sets the players role to imposter or not imposter
    public void SetRole(bool newRole)
    {
        isImposter = newRole;
        isAngel = newRole;
        isInspector = newRole;
    }

    //this method adds potential murder targers to a target array when they enter the range
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AU_PlayerController tempTarget = other.GetComponent<AU_PlayerController>();
            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                {
                    targets.Add(tempTarget);

                }
            }
            if (isAngel)
            {
                if (tempTarget.isDead != false)
                    return;
                else
                {
                    targets.Add(tempTarget);

                }
            }
            if (isInspector)
            {
                if (tempTarget.isImposter)
                    targets.Add(tempTarget);
                else
                {
                    return;

                }
            }
        }
    }

    //this method rtemoves the potential murder targers from the target array when they leave the range
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AU_PlayerController tempTarget = other.GetComponent<AU_PlayerController>();
            if (targets.Contains(tempTarget))
            {
                targets.Remove(tempTarget);
            }
        }
    }

    //This method will kill the last player to enter the imposters kill radius
    private void KillTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            
            //Debug.Log(targets.Count);
            if (targets.Count == 0)
                return;
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

    //This method will Revive the last player to enter the Angels kill radius
    private void ReviveTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Debug.Log(targets.Count);
            if (targets.Count == 0)
                return;
            else
            {
                if (targets[targets.Count - 1].isDead == false)
                    return;
                transform.position = targets[targets.Count - 1].transform.position;
                targets[targets.Count - 1].Backy();
                // targets.RemoveAt(targets.Count - 1);
            }
        }
    }

    //This method will Revive the last player to enter the Angels kill radius
    private void InspecttTarget(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Debug.Log(targets.Count);
            if (targets.Count == 0)
                return;
            else
            {

                if (targets[targets.Count - 1].isImposter)
                {
                    return;
                }
                transform.position = targets[targets.Count - 1].transform.position;

                 targets[targets.Count - 1].Inspectyy();
               
            }
        }
    }

    //this method will inspect the player to see if they are the mafia
    public void Inspectyy()
    {
        isInspectAni = true;
        myAnim.SetBool("isInspectAni", isInspectAni);
        gameObject.layer = 9;
       // myCollider.enabled = true;
    }

    //this method will cause the player to revive
    public void Backy()
    {
        //AU_Body tempBody = Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<AU_Body>();
        //watempBody.SetColor(myAvatarSprite.color);
        isDead = false;
        myAnim.SetBool("IsDead", isDead);
        gameObject.layer = 9;
        myCollider.enabled = true;
    }


    //this method will cause the plauyer to die leaving a dead sprite at the location of death
    public void Die()
    {
        AU_Body tempBody = Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<AU_Body>();
        tempBody.SetColor(myAvatarSprite.color);
        isDead = true;
        myAnim.SetBool("IsDead", isDead);
        gameObject.layer = 9;
        myCollider.enabled = false;
    }

    //This method searches for bodies by calculating rays between the player and a body
    void BodySearch()
    {
        foreach (Transform body in allBodies)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, body.position - transform.position);
            Debug.DrawRay(transform.position, body.position - transform.position, Color.cyan);
            if (Physics.Raycast(ray, out hit, 1000f, ~ignoreForBody))
            {

                if (hit.transform == body)
                {
                    if (bodiesFound.Contains(body.transform))
                        return;
                    bodiesFound.Add(body.transform);
                }
                else
                {

                    bodiesFound.Remove(body.transform);
                }
            }
        }
    }

    //this method is used to report the body when they are in the range of a player
    private void ReportBody(InputAction.CallbackContext obj)
    {
        if (bodiesFound == null)
            return;
        if (bodiesFound.Count == 0)
            return;
        Transform tempBody = bodiesFound[bodiesFound.Count - 1];
        allBodies.Remove(tempBody);
        bodiesFound.Remove(tempBody);
        tempBody.GetComponent<AU_Body>().Report();
    }
}