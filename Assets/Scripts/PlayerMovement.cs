using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;

    private CharacterController characterController;

    private Vector3 velocity;

    public float speed = 6.0f;

    public float distance = 1.05f;
    private bool isGrounded;
    [SerializeField] private float gravity = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
