using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpTutorialScript : MonoBehaviour
{
    //Declares variables
    public MainGameTutorialController tutorialController;

    private int newHealth;
    [SerializeField] private GameObject healthUpObject;

    //OnMouseFunction which increases the health of the player on the tutorial when the health power up is clicked on
    private void OnMouseDown()
    {

            tutorialController.health += 1;


            newHealth = tutorialController.health;

            tutorialController.healthText.text = "Health: " + newHealth;


        
    }
}
