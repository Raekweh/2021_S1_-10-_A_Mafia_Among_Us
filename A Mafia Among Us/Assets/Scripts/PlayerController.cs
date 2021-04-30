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
        myRb = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);

        myAnimator = GetComponent<Animator>();
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

}
