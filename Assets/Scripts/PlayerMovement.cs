using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 velocity;

    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;


    [SerializeField] private bool isCrouching;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isGrounded && !isCrouching)
        {
            speed = runSpeed;
            if (!isCrouching && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                anim.SetTrigger("JumpTrigger");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Crouch();
                anim.SetBool("IsCrouching", true);
                controller.height = 1;
                controller.center = new Vector3(controller.center.x, 0.5f, controller.center.z);
            }
        }
        else if (isCrouching)
        {
            speed = crouchSpeed;

            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouch();
                anim.SetBool("IsCrouching", false);
                controller.height = 2;
                controller.center = new Vector3(controller.center.x, 1, controller.center.z);
            }
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);

            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Run()
    {

    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Crouch()
    {
        isCrouching = !isCrouching;
    }
}
