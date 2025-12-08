using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start Scene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void credits()
    {
               UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
}
