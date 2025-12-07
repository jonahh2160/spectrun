using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactionRange = 5.0f;
    [SerializeField] private Vector3 offset = new Vector3(0, 1f, 0);
    [SerializeField] private InputActionAsset inputActions;

    private InputAction interactAction;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    private bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;
        Ray ray = new Ray(transform.position + offset, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))
        {
            interactable = hitInfo.collider.GetComponent<IInteractable>();
            if (interactable != null && interactable.CanInteract())
            {
                return true;
            }
        }
        
        return false;
    }

    private void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            if (DoInteractionTest(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
        }
    }
}
