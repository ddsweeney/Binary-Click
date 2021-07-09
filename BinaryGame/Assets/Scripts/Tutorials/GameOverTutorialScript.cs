using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTutorialScript : MonoBehaviour
{

    //Declares variables
    public MainGameTutorialController tutorialController;
    [SerializeField] private Canvas gameOverTutorial;

    //OnMouseFunction function which calls the game over function and enables the game over canvas
     void OnMouseDown()
    {

            gameOverTutorial.enabled = true;
            tutorialController.GameOver();

        
    }
}
