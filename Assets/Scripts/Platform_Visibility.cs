using System.Runtime.CompilerServices;
using UnityEngine;

public class Platform_Visibility : MonoBehaviour
{
    [SerializeField] private GameObject redPlatforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redPlatforms.SetActive(false);
        foreach (string color in PlayerMovement.selectedColors)
        {
            if (color == "Red")
            {
                redPlatforms.SetActive(true);
            }
        }
    }
}
