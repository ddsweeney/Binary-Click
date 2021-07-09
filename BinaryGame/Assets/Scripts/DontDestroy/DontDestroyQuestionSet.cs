using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyQuestionSet : MonoBehaviour
{

    //Static public variable which will be set to not be destroyed 
    public static DontDestroyQuestionSet questionSet;


    //Awake function so when a scene is loading, its called
    private void Awake()
    {
        //If statement to create a DontDestroyOnLoad game mode object if there isn't one already one
        if (questionSet == null)
        {

            questionSet = this;

            DontDestroyOnLoad(questionSet);

        }
        

    }
}
