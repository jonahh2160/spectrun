//Credit to https://www.youtube.com/@NightRunStudio for the cutscene system tutorial series
//Modified by Megan Jones

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneElementBase : MonoBehaviour
{
    public float duration;
    private CutSceneHandler cutsceneHandler;

    public void Start()
    {
        cutsceneHandler = GetComponent<CutSceneHandler>();
    }

    public virtual void Execute()
    {
        
    }

    protected IEnumerator WaitAndAdvance()
    {
        yield return new WaitForSeconds(duration);
        cutsceneHandler.PlayNextElement();
    }



}
