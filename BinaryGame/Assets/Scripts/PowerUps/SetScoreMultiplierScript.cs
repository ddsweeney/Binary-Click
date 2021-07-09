using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreMultiplierScript : MonoBehaviour
{
    //Declares variables

    public GameController gameController;


    private float amountTimeForScoreMultiplier = 0; // Current amount of time for score multiplier
    [SerializeField] private float maxAmountTimeForScoreMultiplier = 10f; // max amount of time for score multiplier

    [SerializeField] private GameObject multiplerObject;
    [SerializeField] private TMP_Text twoTimes;
    bool countDown = false;


    // Start is called before the first frame update
    private void Start()
    {
        amountTimeForScoreMultiplier = maxAmountTimeForScoreMultiplier;

        
        twoTimes.enabled = false;

    }

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    void OnMouseDown()
    {

        //if statement for if the game object has the tag PowerUps then
        if (gameObject.CompareTag("PowerUps") == true)
        {



            countDown = true; // countDown set to true and timer for multiplier starts


        }
    }

    // Update is called once per frame
    void Update()
    {


        //if statement for if the countDown is true then
        if (countDown)
        {

            multiplerObject.GetComponentInChildren<Text>().enabled = false;
            amountTimeForScoreMultiplier -= Time.deltaTime; //the power up timer starts to count down



            gameController.amountOfScore = 2; //the amount of score goes up by 2


            twoTimes.enabled = true; //image of the active power up is displayed



        }


        //if statement for if the amountTimeForScoreMultiplier is less than or equal to zero, the amount of score goes back to 0ne
        if (amountTimeForScoreMultiplier <= 0)
        {

            amountTimeForScoreMultiplier = maxAmountTimeForScoreMultiplier;


            gameController.amountOfScore = 1;

            twoTimes.enabled = false;




        }

        //Variables get reset
        countDown = false;

            multiplerObject.GetComponentInChildren<Text>().enabled = true;
            multiplerObject.SetActive(false);

        

    }
     

          
  

}
