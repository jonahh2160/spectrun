//Credit to https://www.youtube.com/@NightRunStudio for the cutscene system tutorial series
//Modified by Megan Jones

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneHandler : MonoBehaviour
{
    private CutsceneElementBase[] cutsceneElements;
    private int index = -1;

    public void Start()
    {
        cutsceneElements = GetComponents<CutsceneElementBase>();
        
    }

    private void ExecuteCurrentElement()
    {
        if (index >= 0 && index < cutsceneElements.Length)
        {
            cutsceneElements[index].Execute();
        }
    }

    public void PlayNextElement()
    {
        index++;
        if (index < cutsceneElements.Length)
        {
            ExecuteCurrentElement();
        }
    }
        
}