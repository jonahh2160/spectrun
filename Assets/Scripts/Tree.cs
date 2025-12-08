using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        GameManager.unlockedColors[1] = 1;
        Debug.Log("Green Unlocked");
        return true;
    }
}
