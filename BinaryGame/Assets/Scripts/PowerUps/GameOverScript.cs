using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{


    //Declare variables
    public GameController gameController;
    [SerializeField] private Canvas gameOverGame;

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    void OnMouseDown()
    {

        
            gameController.GameOver();

            gameOverGame.enabled = true;

        

        
    }


   
}
