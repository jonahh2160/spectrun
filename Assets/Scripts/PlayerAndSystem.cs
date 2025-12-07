using UnityEngine;

public class PlayerAndSystem : MonoBehaviour
{
    [SerializeField] private GameObject body;

    public void Awake()
    {
        GameManager.body = body;
    }

    public void spawnAtTutorials()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial Level(s)");
    }
}
