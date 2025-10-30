using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction pauseKey;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject HUD;
    public Color color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject colorSelectButtons;

    public Color slotSelected;

    private Color selectedColor;

    private int selectedSlot;

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
        if (GameIsPaused)
        {
            
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
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

    void selectRed()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Red";
        colorSelectButtons.SetActive(false);
    }

    void selectBlue()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Blue";
        colorSelectButtons.SetActive(false);
    }

    void selectGreen()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Green";
        colorSelectButtons.SetActive(false);
    }

    void selectYellow()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Yellow";
        colorSelectButtons.SetActive(false);
    }

    void selectPurple()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Purple";
        colorSelectButtons.SetActive(false);
    }

    void selectOrange()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Orange";
        colorSelectButtons.SetActive(false);
    }

    void selectBlack()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Black";
        colorSelectButtons.SetActive(false);
    }

    void selectWhite()
    {
        PlayerMovement.selectedColors[selectedSlot] = "White";
        colorSelectButtons.SetActive(false);
    }

    void selectColor1()
    {
        selectedSlot = 0;
        colorSelectButtons.SetActive(true);
    }

    void selectColor2()
    {
        selectedSlot = 1;
        colorSelectButtons.SetActive(true);
    }

    void selectColor3()
    {
        selectedSlot = 2;
        colorSelectButtons.SetActive(true);
    }
}