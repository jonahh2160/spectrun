using UnityEngine;

public class SadCube : MonoBehaviour, IInteractable
{
    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        GameManager.unlockedColors[0] = 1;
        Debug.Log("Blue Unlocked");
        return true;
    }
}
