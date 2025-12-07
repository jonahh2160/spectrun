using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial Level(s)");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
