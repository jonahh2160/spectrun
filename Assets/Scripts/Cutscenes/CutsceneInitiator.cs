//Credit to https://www.youtube.com/@NightRunStudio for the cutscene system tutorial series
//Modified by Megan Jones

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneInitiator : MonoBehaviour
{
    private CutSceneHandler cutSceneHandler;

    public void Start()
    {
        cutSceneHandler = GetComponent<CutSceneHandler>();
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnTriggerEnter called with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player detected, playing next element");
            cutSceneHandler.PlayNextElement();
        }
    }
}
