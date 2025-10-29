using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction pauseKey;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void Awake()
    {
        pauseKey = InputSystem.actions.FindAction("Pause");
    }
    void Update()
    {
        if (pauseKey.WasPressedThisFrame())
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("tittle");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}