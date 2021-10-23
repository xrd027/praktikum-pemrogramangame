using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_player : MonoBehaviour
{
    //variable
    private float speed = 5f;
    public float x;
    public float z;
    [SerializeField] private float gravitasi = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGrounded;
    Vector3 velocity;

    //reference
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        move();
    }

    private void move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 moving = transform.right * x + transform.forward * z;
        controller.Move(moving * speed * Time.deltaTime);
    }

    private void gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}