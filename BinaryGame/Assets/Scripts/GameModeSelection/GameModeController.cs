using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameModeController : MonoBehaviour
{
    //Declare variables
    public static bool endless = false; //bool for endless game mode
    public static bool timeTrial = false;//bool for time trial game mode

    //Function that sets endless to true and timeTrial to false
    public void EndlessMode()
    {

        endless = true;
        timeTrial = false;

    }

    //Function that sets timeTrial to true and endless to false
    public void TimeTrial()
    {

        timeTrial = true;
        endless = false;


    }


}
