using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplierTutorialScript : MonoBehaviour
{

    //Declare varaibles 
    public MainGameTutorialController tutorialController; //Allow access to public variables on the MainGameTutorialController

    //Variables for how long the power up should be active
    private float amountTimeForScoreMultipler = 0;
    [SerializeField] private float maxAmountTimeForScoreMultipler = 10f;

    [SerializeField] private GameObject multiplerObject; //score multiplier game object
    [SerializeField] private TMP_Text image; 

    bool countDown = false;


    // Start is called before the first frame update
     void Start()
    {
        amountTimeForScoreMultipler = maxAmountTimeForScoreMultipler;
        image.enabled = false;
    }

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
     void OnMouseDown()
    {
        if (gameObject.CompareTag("PowerUps") == true)
        {

            countDown = true;//When clicked, sets the countDwon to true

        }
    }

    // Update is called once per frame
     void Update()
    {

        //if statement for if the countDown is true then
        if (countDown)
        {
            Debug.Log("start");

            multiplerObject.GetComponentInChildren<Text>().enabled = false;
            amountTimeForScoreMultipler -= Time.deltaTime;//the power up timer starts to count down

            image.enabled = true;
            tutorialController.amountOfScore = 2;//the amount of score goes up by 2 when clicking the correct answer

        }

        //if statement for if the amountTimeForScoreMultiplier is less than or equal to zero, the amount of score goes back to one
        if (amountTimeForScoreMultipler <= 0)
        {

            amountTimeForScoreMultipler = maxAmountTimeForScoreMultipler;

            image.enabled = false;


            tutorialController.amountOfScore = 1;

            countDown = false;

            multiplerObject.GetComponentInChildren<Text>().enabled = true;

        }

    }

}
