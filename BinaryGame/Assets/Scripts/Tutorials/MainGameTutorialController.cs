using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainGameTutorialController : MonoBehaviour
{
    //Declare variables
    public Canvas gameOverTutorial; // game over menu
  
    //Health Variables
    public TMP_Text healthText;
    public int health = 100;

    //Score Variables
    [SerializeField] private TMP_Text scoreText;
    public int score = 0;
    public int amountOfScore = 1;

    //Time Variables
    private float timeLeft; 
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float maxTime = 30f;

    [SerializeField] private GameObject showbutton; //Incorrect Answer game object

    //PowerUp scripts
    public ShieldScript shield;
    public BombScript bomb;

    [SerializeField] private Image image; //active power up image

    public DynamticLocaleVaribles dynamticLocale;

    //Series of power up game objects
    [SerializeField] private GameObject freeze;
    [SerializeField] private GameObject multi;
    [SerializeField] private GameObject bombObject;
    [SerializeField] private GameObject healthup;
    [SerializeField] private GameObject healthdown;
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private GameObject skull;


    // Start is called before the first frame update
    void Start()
    {

        //Sets game variables
        score = 0;
        gameOverTutorial.enabled = false;
        timeLeft = maxTime;

        Time.timeScale = 1;

        image.enabled = false;

        scoreText.text = "Score: " + score;

        healthText.text = "Health: " + health;

    }

    // Update is called once per frame
    void Update()
    {

        //Sets all power up game objects to stay on the scene
        freeze.SetActive(true);
        multi.SetActive(true);
        bombObject.SetActive(true);
        healthup.SetActive(true);
        healthdown.SetActive(true);
        shieldObject.SetActive(true);
        skull.SetActive(true);

        timeLeft -= Time.deltaTime;

        timerText.text = "Time: " + timeLeft.ToString("f2");

        //if statement to reset timer when equals zero
        if (timeLeft <= 0)
        {

            timeLeft = maxTime;

        }

        //if statement to reset health when equals zero
        if (health <= 0)
        {
            health = 100;
        }


        //if statements for bomb power up 
        if (bomb.bombActive == true)
        {
            showbutton.SetActive(false);
           

        }
        else if (bomb.bombActive == false)
        {
            showbutton.SetActive(true);

           

        }
    }

    //GameOver function pauses the game and enables the game over canvas to show
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverTutorial.enabled = true;

    }

    //CorrectAnswer function is called when correct answer is clicked
    public void CorrectAnswer()
    {

        ScoreIncreases(); //Calls the function ScoreIncreases

        if (bomb.bombActive == true)
        {
            bomb.bombActive = false;
            image.enabled = false;
        }

    }

    //InCorrectAnswer function is called when incorrect answer is clicked
    public void InCorrectAnswer()
    {
        //if shield is active, player doesnt lose health
        if (shield.shieldActive == true)
        {
            shield.shieldActive = false;

            image.enabled = false;

        }
        else
        {
            HealthDecreases(); //Calls the function HealthDecreases
        }


        if (bomb.bombActive == true) {
            bomb.bombActive = false;
            image.enabled = false;
        }
    }

    //ScoreIncreases function increases the score when called
    void ScoreIncreases()
    {
        score += amountOfScore;
        scoreText.text = "Score: " + score;
    }

    //HealthDecreases function decreases the players health when called
    void HealthDecreases()
    {
        health -= 1;
        healthText.text = "Health: " + health;

    }
}
