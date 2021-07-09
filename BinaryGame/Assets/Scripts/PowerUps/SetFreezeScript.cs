using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFreezeScript : MonoBehaviour
{
    [SerializeField] private float amountTimeForFreeze = 3f; // Amount of time for the game to stop
    [SerializeField] private GameObject freezeObject; // Frezze power game object


    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    void OnMouseDown()
    {

        if (GameModeController.endless)
        {
            freezeObject.SetActive(false);

            
        }
        
            Freeze(); //Call the freeze function
        
    }


    //Freeze function which stops the game for the amount of time set
    void Freeze()
    {


        float timeForFreeze = Time.realtimeSinceStartup + amountTimeForFreeze;


        while (Time.realtimeSinceStartup <= timeForFreeze)
        {
            Time.timeScale = 0;
        }



        Time.timeScale = 1;





    }
}