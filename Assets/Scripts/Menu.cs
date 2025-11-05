using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.ComponentModel;

public class Menu : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction pauseKey;

    public static bool GameIsPaused = false;

    public static bool updatePlatforms = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject HUD;
    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject colorSelectButtons;

    [SerializeField] private GameObject HUDColor1;
    [SerializeField] private GameObject HUDColor2;
    [SerializeField] private GameObject HUDColor3;

    [SerializeField] private Material charRed;
    [SerializeField] private Material charBlue;
    [SerializeField] private Material charYellow;
    [SerializeField] private Material charGreen;
    [SerializeField] private Material charPurple;
    [SerializeField] private Material charOrange;
    [SerializeField] private Material charWhite;
    [SerializeField] private Material charBlack;
    [SerializeField] private Material charGrey;

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
    }

    private void setColor(GameObject slot, int index)
    {
        Color tempColor;
        string colorName = PlayerMovement.selectedColors[index];
        switch (colorName)
        {
            case "Red":
                tempColor = Color.red;
                colorPlayer(index, charRed);
                break;
            case "Blue":
                tempColor = Color.blue;
                colorPlayer(index, charBlue);
                break;
            case "Green":
                tempColor = Color.green;
                colorPlayer(index, charGreen);
                break;
            case "Yellow":
                tempColor = Color.yellow;
                colorPlayer(index, charYellow);
                break;
            case "Purple":
                tempColor = new Color(0.5f, 0f, 0.5f);
                colorPlayer(index, charPurple);
                break;
            case "Orange":
                tempColor = new Color(1f, 0.65f, 0f);
                colorPlayer(index, charOrange);
                break;
            case "Black":
                tempColor = Color.black;
                colorPlayer(index, charBlack);
                break;
            case "White":
                tempColor = Color.white;
                colorPlayer(index, charWhite);
                break;
            default:
                tempColor = Color.gray; // Default color if none is selected
                colorPlayer(index, charGrey);
                break;
        }
        slot.GetComponent<UnityEngine.UI.Image>().color = tempColor;
        updatePlatforms = true;
    }


    private void colorPlayer(int index, Material mat)
    {
        switch (index)
        {
            case 0:
                PlayerMovement.head.GetComponent<SkinnedMeshRenderer>().material = mat;
                break;
            case 1:
                PlayerMovement.leftArm.GetComponent<SkinnedMeshRenderer>().material = mat;
                PlayerMovement.rightArm.GetComponent<SkinnedMeshRenderer>().material = mat;
                PlayerMovement.body.GetComponent<SkinnedMeshRenderer>().material = mat;
                break;
            case 2:
                PlayerMovement.leftLeg.GetComponent<SkinnedMeshRenderer>().material = mat;
                PlayerMovement.rightLeg.GetComponent<SkinnedMeshRenderer>().material = mat;
                break;
        }
    }

    public void Resume()
    {
        setColor(HUDColor1, 0);
        setColor(HUDColor2, 1);
        setColor(HUDColor3, 2);
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        upDateColorButtons();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void upDateColorButtons()
    {
        setColor(color1, 0);
        setColor(color2, 1);
        setColor(color3, 2);
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

    public void selectRed()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Red";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectBlue()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Blue";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectGreen()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Green";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectYellow()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Yellow";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectPurple()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Purple";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectOrange()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Orange";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectBlack()
    {
        PlayerMovement.selectedColors[selectedSlot] = "Black";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectWhite()
    {
        PlayerMovement.selectedColors[selectedSlot] = "White";
        colorSelectButtons.SetActive(false);
        upDateColorButtons();
    }

    public void selectColor1()
    {
        selectedSlot = 0;
        colorSelectButtons.SetActive(true);
    }

    public void selectColor2()
    {
        selectedSlot = 1;
        colorSelectButtons.SetActive(true);
    }

    public void selectColor3()
    {
        selectedSlot = 2;
        colorSelectButtons.SetActive(true);
    }
}