using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDownScript : MonoBehaviour
{
    //Declare variables
    public GameController gameController;
    public DynamticLocaleVaribles localeVaribles;
    private int newHealth;

    
    [SerializeField] private GameObject healthDownObject;

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
     void OnMouseDown()
    {
        healthDownObject.SetActive(false);

      
            gameController.health -= 1; //health decreases by 1

            newHealth = gameController.health;
            gameController.healthText.text = "Health: " + newHealth; //new health is displayed



    }
}
