using System.Runtime.CompilerServices;
using UnityEngine;

public class Platform_Visibility : MonoBehaviour
{
    [SerializeField] private GameObject redPlatforms;
    [SerializeField] private GameObject greenPlatforms;
    [SerializeField] private GameObject bluePlatforms;
    [SerializeField] private GameObject blackPlatforms;
    [SerializeField] private GameObject whitePlatforms;
    [SerializeField] private GameObject purplePlatforms;
    [SerializeField] private GameObject orangePlatforms;
    [SerializeField] private GameObject yellowPlatforms;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.updatePlatforms) {
            updatePlatforms();
        }
    }

    public void updatePlatforms()
    {
        Menu.updatePlatforms = false;
        redPlatforms.SetActive(false);
        greenPlatforms.SetActive(false);
        bluePlatforms.SetActive(false);
        blackPlatforms.SetActive(false);
        whitePlatforms.SetActive(false);
        purplePlatforms.SetActive(false);
        yellowPlatforms.SetActive(false);
        orangePlatforms.SetActive(false);
        foreach (string color in PlayerMovement.selectedColors)
        {
            if (color == "Red")
            {
                redPlatforms.SetActive(true);
            }
            else if (color == "Yellow")
            {
                yellowPlatforms.SetActive(true);
            }
            else if (color == "Green")
            {
                greenPlatforms.SetActive(true);
            }
            else if (color == "Blue")
            {
                bluePlatforms.SetActive(true);
            }
            else if (color == "Orange")
            {
                orangePlatforms.SetActive(true);
            }
            else if (color == "Purple")
            {
                purplePlatforms.SetActive(true);
            }
            else if (color == "White")
            {
                whitePlatforms.SetActive(true);
            }
            else if (color == "Black")
            {
                blackPlatforms.SetActive(true);
            }
        }
    }
}
