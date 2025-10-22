using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    public InputActionAsset inputActions;


    private InputAction moveAction;

    public GameObject freelookCam;
    public Transform player;
    public Rigidbody rb;
    private Vector2 moveAmt;

    public float rotationSpeed;
    private float _targetRotation = 0.0f;
    private float rotationVelocity;

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
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        moveAmt = moveAction.ReadValue<Vector2>();

        // normalise input direction
        Vector3 inputDirection = new Vector3(moveAmt.x, 0.0f, moveAmt.y).normalized;

        if (moveAction.IsPressed())
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  freelookCam.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref rotationVelocity,
            rotationSpeed);

            player.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }


    }
}
