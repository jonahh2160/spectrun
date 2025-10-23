using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction jumpAction;

    [SerializeField] private string[] platformColors;
    public static string[] selectedColors;

    private Vector2 moveAmt;

    public float walkSpeed;
    public float rotateSpeed;
    public float jumpSpeed;
    public float wallRunSpeed;

    public LayerMask wall;
    public LayerMask ground;

    public float wallRunForce;
    public float maxWallRunTime;
    private float wallRunTimer;

    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    float horizontalInput;
    float verticalInput;

    public enum MovementState
    {
        walking,
        sprinting,
        wallrunning,
        crouching,
        sliding,
        air
    }

    private MovementState state;

    public bool wallrunning;
    public bool walking;

    Rigidbody rb;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        selectedColors = platformColors;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        moveAmt = moveAction.ReadValue<Vector2>();
        CheckForWall();
        StateMachine();
        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!AboveGround())
        {
            rb.AddForceAtPosition(new Vector3(0, 5f, 0), Vector3.up, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (wallrunning)
        {
            WallRunningMove();
        }
        else
        {
            Walking();
        }
    }


    private void Walking()
    {
        rb.MovePosition(rb.position + transform.forward * moveAmt.y * walkSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + transform.right * moveAmt.x * walkSpeed * Time.deltaTime);
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, transform.right, out rightWallHit, wallCheckDistance, wall);
        wallLeft = Physics.Raycast(transform.position, -transform.right, out leftWallHit, wallCheckDistance, wall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
    }

    private void StateHandler()
    {
        //Mode - Wallrunning
        if (wallrunning)
        {
            state = MovementState.wallrunning;
        }
    }

    private void StateMachine()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;

        // State 1 - wallrunning
        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {
            if (!wallrunning)
            {
                StartWallRun();
            }
        }
        else
        {
            StopWallRun();
        }
    }

    private void StartWallRun()
    {
        wallrunning = true;
    }

    private void WallRunningMove()
    {
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((transform.forward - wallForward).magnitude > (transform.forward - -wallForward).magnitude)
        {
            wallForward = -wallForward;
        }

        //forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        //push to wall
        if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
        {
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
        }
    }

    private void StopWallRun()
    {
        wallrunning = false;
        rb.useGravity = true;
    }


}