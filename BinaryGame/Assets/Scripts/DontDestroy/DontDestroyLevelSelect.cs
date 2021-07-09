using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLevelSelect : MonoBehaviour
{
    //Static public variable which will be set to not be destroyed 
    public static DontDestroyLevelSelect levelSet;


    //Awake function so when a scene is loading, its called
    private void Awake()
    {
        //If statement to create a DontDestroyOnLoad game mode object if there isn't one already one
        if (levelSet == null)
        {

            levelSet = this;

            DontDestroyOnLoad(levelSet);

        }


    }
}
