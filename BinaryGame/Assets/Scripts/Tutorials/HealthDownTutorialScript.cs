using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDownTutorialScript : MonoBehaviour
{

    //Declares variables
    public MainGameTutorialController tutorialController;

    private int newHealth;

    [SerializeField] private GameObject healthDownObject;

    //OnMouseFunction which decreases the health of the player on the tutorial
    private void OnMouseDown()
    {

            tutorialController.health -= 1;
            newHealth = tutorialController.health;
            tutorialController.healthText.text = "Health: " + newHealth;
        
    }
}
