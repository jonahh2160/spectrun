//Credit to https://www.youtube.com/@NightRunStudio for the cutscene system tutorial series
//Modified by Megan Jones


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSE_Test : CutsceneElementBase
{
    public override void Execute()
    {
        StartCoroutine(WaitAndAdvance());
        Debug.Log("Executing " + name);
    }
}
