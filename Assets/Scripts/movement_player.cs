using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_player : MonoBehaviour
{
    //variable
    [SerializeField] public float speed;
    public float x;
    public float z;
    [SerializeField] private float speed_jump = 2f;
    [SerializeField] private float speed_walk = 2f;
    [SerializeField] public float speed_run = 8f;
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
        jump();
        walking();
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

    }

    private void jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(speed_jump * -2f * gravitasi);
        }

        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void walking()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speed_run;
        }
        else
        {
            speed = speed_walk;
        }
    }
}
