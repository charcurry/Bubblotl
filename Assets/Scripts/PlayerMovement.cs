using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;

    private CharacterController characterController;

    [SerializeField] private Vector3 velocity;

    public float groundSpeed = 6.0f;
    public float airSpeed = 4f;

    public float currentSpeed;

    public float distance = 1.05f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float gravity = -9.81f;

    //private float airSpeedDegredation = 0.5f;

    public float jumpforce = 10.0f;

    public float defaultGroundedTimer = 0.25f;
    [SerializeField] private float groundedTimer;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundedTimer = defaultGroundedTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();

        Vector2 movement = new Vector2(movementX, 0.0f);

        if (velocity.y < 0f && isGrounded)
        {
            velocity.y = -2.0f;
        }

        characterController.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        velocity.x = movement.x * currentSpeed;

        gameObject.transform.Translate(movement * Time.fixedDeltaTime * currentSpeed);

        if (isGrounded) 
        {
            currentSpeed = groundSpeed;
        }
        else
        {
            currentSpeed = airSpeed;
            //if (velocity.x > 0)
            //{
            //    speed = velocity.x -= (Time.deltaTime * airSpeedDegredation);
            //}
            //else if (velocity.x < 0)
            //{
            //    speed = velocity.x += (Time.deltaTime * airSpeedDegredation);
            //}
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
    }

    void OnJump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpforce * -2f * gravity);
        }
        groundedTimer = 0;
    }

    private void CheckGround()
    {
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);

        if (Physics.Raycast((transform.position), Vector3.down * distance, out RaycastHit hit, distance))
        {
            isGrounded = true;
            groundedTimer = defaultGroundedTimer;
        }
        else if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
