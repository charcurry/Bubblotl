using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;

    private CharacterController characterController;

    private Vector3 velocity;

    public float speed = 6.0f;

    public float distance = 1.05f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float gravity = -2;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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

        gameObject.transform.Translate(movement * Time.fixedDeltaTime * speed);
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
            velocity.y = Mathf.Sqrt(distance * -2f * gravity);
        }
    }

    private void CheckGround()
    {
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);

        if (Physics.Raycast((transform.position), Vector3.down * distance, out RaycastHit hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
