using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpScript : MonoBehaviour
{

    //Declare variables
    public GameController gameController;
    private int newHealth;
    [SerializeField] private GameObject healthUpObject;

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    void OnMouseDown()
    {
      
        healthUpObject.SetActive(false);



        
            gameController.health += 1; //health is increased by 1

        //if health is greater than or equal to three   
        if (gameController.health >= 3) 
            {
                gameController.health = 3; // Health is set to 3
            }
            newHealth = gameController.health;
            gameController.healthText.text = "Health: " + newHealth; //new health is displayed


    }
}
