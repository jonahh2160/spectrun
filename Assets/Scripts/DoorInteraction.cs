using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{

    private PlayerAndSystem PlayerAndSystem;

    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        PlayerAndSystem.spawnAtTutorials();
        return true;
    }

    public void Awake()
    {
        PlayerAndSystem = FindFirstObjectByType<PlayerAndSystem>();
    }
}
