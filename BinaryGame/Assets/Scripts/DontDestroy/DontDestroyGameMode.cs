using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyGameMode: MonoBehaviour
{
    //Static public variable which will be set to not be destroyed 
    public static DontDestroyGameMode gameMode;


    //Awake function so when a scene is loading, its called
    private void Awake()
    {
        //If statement to create a DontDestroyOnLoad game mode object if there isn't one already one
        if (gameMode == null)
        {

            gameMode = this;

            DontDestroyOnLoad(gameMode);

        }
        
 
    }

}
