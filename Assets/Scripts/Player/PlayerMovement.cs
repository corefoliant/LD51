using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    private float speed;
    public float crouchSpeed;
    public float runSpeed;

    private Vector3 velocity;

    public float turnSmoothTime;
    private float turnSmoothVelocity;


    private bool isCrouching;
    private bool isGrounded;
    public LayerMask groundMask;
    public float groundCheckDistance;
    private float gravity = -9.8f;

    public float jumpHeight;

    private Animator anim;

    private Vector2 _inputAxis;

    public static bool enableJump = true;
    public static bool invertedMovement = false;
    public static char minusKey = '-';
    public Vector3 forward;
    public Vector3 right;
    public Vector3 direction;
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

        

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsRunning", _inputAxis.magnitude > 0.1f);

        if (isGrounded)
        {
            forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0f;
            right = Camera.main.transform.TransformDirection(Vector3.right);
            direction = _inputAxis.x * right + _inputAxis.y * forward;


            if (minusKey == 'A')
                _inputAxis = new Vector2(Mathf.Max(Input.GetAxis("Horizontal"), 0), Input.GetAxis("Vertical"));
            else if (minusKey == 'S')
                _inputAxis = new Vector2(Input.GetAxis("Horizontal"), Mathf.Max(Input.GetAxis("Vertical"), 0));
            else if (minusKey == 'D')
                _inputAxis = new Vector2(Mathf.Min(Input.GetAxis("Horizontal"), 0), Input.GetAxis("Vertical"));
            else if (minusKey == 'W')
                _inputAxis = new Vector2(Input.GetAxis("Horizontal"), Mathf.Min(Input.GetAxis("Vertical"), 0));
            else if (minusKey == 'Q')
                _inputAxis = new Vector2(0, Mathf.Min(Input.GetAxis("Vertical"), 0));
            else
                _inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (invertedMovement)
                _inputAxis = new Vector2(_inputAxis.x * -1, _inputAxis.y * -1);


            if (invertedMovement)
            {
                if (enableJump && Input.GetKeyDown(KeyCode.LeftControl))
                {
                    Jump();
                    anim.SetTrigger("JumpTrigger");
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Crouch(!isCrouching);
                }
            }
            else
            {
                if (enableJump && Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    anim.SetTrigger("JumpTrigger");
                }

                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    Crouch(!isCrouching);
                }
            }

            if (isCrouching)
            {
                speed = crouchSpeed;   
            } else
            {
                speed = runSpeed;
            }
        } else
        {
            Crouch(false);
        }

        if (_inputAxis.magnitude > 0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Crouch(bool state)
    {
        isCrouching = state;
        anim.SetBool("IsCrouching", isCrouching);
        controller.height = isCrouching ? 1f : 2f;
        controller.center = new Vector3(controller.center.x, isCrouching ? 0.5f : 1f, controller.center.z);
    }
}
