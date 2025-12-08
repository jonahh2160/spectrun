using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public TMP_Dropdown myDropdown;
    public GameObject assetsText;
    public GameObject developersText;

    void Start()
    {
        myDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(myDropdown);
        });
    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        Debug.Log("Selected option index: " + change.value);
        Debug.Log("Selected option text: " + change.options[change.value].text);
        // Perform actions based on the selected option
        if (change.options[change.value].text == "Assets")
        {
            assetsText.SetActive(true);
            developersText.SetActive(false);
        }
        else if (change.options[change.value].text == "Developers")
        {
            developersText.SetActive(true);
            assetsText.SetActive(false);
        }
    }

    public void menu()
    {
               UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
