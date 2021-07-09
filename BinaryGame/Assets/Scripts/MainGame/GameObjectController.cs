using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    //Connects to other scipts to use the variables
    public GameController gameController;
    public PowerUpsController powerUpsController;
    public ObjectPositionController objectPositionController;

    //int variables to set boundaries for the answers to move too
    [SerializeField] private int leftBoundary = -684;
    [SerializeField] private int rightboundary = 604;
    [SerializeField] private int bottomBoundary = -477;
    [SerializeField] private int topboundary = 325;

    //float variables of the answer objects current vector positions
    private float currentPosY;
    private float currentPosX;
    

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
     void OnMouseDown()
    {
        //if statement for if any game objects with the tag IncorrectValue are clicked on
        if (gameObject.CompareTag("IncorrectValue") == true)
        {

            gameController.InCorrectAnswer(); //Calls the InCorrectAnswer function in the GameController
            objectPositionController.ObjectPos(); //Calls the ObjectPos function in the ObjectPositionController

        }


        //if statement for if any game objects with the tag CorrectValue are clicked on
        if (gameObject.CompareTag("CorrectValue") == true)
        {
            gameController.CorrectAnswer(); //Calls the CorrectAnswer function in the GameController
            objectPositionController.ObjectPos(); //Calls the ObjectPos function in the ObjectPositionController
         
        }

        //if statement for if any game objects with the tag CorrectValue are clicked on
        if ((gameObject.CompareTag("CorrectValue") == true) || (gameObject.CompareTag("IncorrectValue") == true))
        {
            //if statement for when the current level is 3 or above
            if (gameController.currentLevel >= 3)
            {
                powerUpsController.ChangeGoodPowerUp(); //Calls the ChangeGoodPowerUp function in the PowerUpsController
                powerUpsController.ChangeBadPowerUp(); //Calls the ChangeBadPowerUp function in the PowerUpsController
                powerUpsController.PowerUpPos(); //Calls the PowerUpPos function in the PowerUpsController

            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        //if statement for if the game objects x position is less than or equal to the left boundary then is x position is moved to the other side of the screen 
        if (gameObject.transform.position.x <= leftBoundary)
        {

            currentPosY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(gameController.maxRangeX, currentPosY, 0);
        }

        //if statement for if the game objects x position is greater than or equal to the right boundary then is x position is moved to the other side of the screen 
        if (gameObject.transform.position.x >= rightboundary)
        {

            currentPosY = gameObject.transform.position.y;

            gameObject.transform.position = new Vector3(gameController.minRangeX, currentPosY, 0);
        }

        //if statement for if the game objects y position is greater than or equal to the top boundary then is y position is moved to the other side of the screen 
        if (gameObject.transform.position.y >= topboundary)
        {

            currentPosX = gameObject.transform.position.x;

            gameObject.transform.position = new Vector3(currentPosX, gameController.minRangeY, 0);
        }

        //if statement for if the game objects y position is less than or equal to the bottom boundary then is y position is moved to the other side of the screen 
        if (gameObject.transform.position.y <= bottomBoundary)
        {

            currentPosX = gameObject.transform.position.x;

            gameObject.transform.position = new Vector3(currentPosX, gameController.maxRangeY, 0);
        }




    }
    

}
