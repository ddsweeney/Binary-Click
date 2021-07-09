using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class AddToDBController : MonoBehaviour
{
    //Declare Variables
    public TMP_InputField nameInput; //InputField for player to enter name

    public int score;// the players score

    [SerializeField] private GameController gameController;


    //Function that selects which URL to connect too
    public void CallPlayerScores()
    {
        score = gameController.endlessScore; //set score to equal the players final score on the endless mode


        // if statement to say if binary to decimal is true/selected
        if (QuestionSelectController.binToDec == true)
        {
            //Connect to this URL
            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/addbintodechighscore.php"));

        }
        // if statement to say if decimal to binary is true/selected
        else if (QuestionSelectController.decToBin == true)
        {

            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/adddectobinhighscore.php"));

        }
        // if statement to say if binary to hexadecimal is true/selected
        else if (QuestionSelectController.binToHex == true)
        {
            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/addbintohexhighscore.php"));

        }
        // if statement to say if hexadecimal to binary is true/selected
        else if (QuestionSelectController.hexToBin == true)
        {
            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/addhextobinhighscore.php"));
        }
        // if statement to say if decimal to hexadecimal is true/selected
        else if (QuestionSelectController.decToHex == true)
        {        // if statement to say is binary to decimal is true

            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/adddectohexhighscore.php"));
        }
        // if statement to say if hexadecimal to decimal is true/selected
        else if (QuestionSelectController.hexToDec == true)
        {
            StartCoroutine(AddToDB("https://users.aber.ac.uk/das74/MajorProject/addhextodechighscore.php"));
        }
    }


    //IEnumerator that returns a unity web requests that adds the player name and score to the database
   public IEnumerator AddToDB(string URL)
    {
        //Creates a form to put the data in
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>
        {
            new MultipartFormDataSection("Player", nameInput.text),
            new MultipartFormDataSection("Score", score.ToString())
        };

        //Uses post to send the data to the URL
        UnityWebRequest www = UnityWebRequest.Post(URL, formData);


        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log("Form upload incomplete!");

        }
        else
        {
            Debug.Log("Form upload complete!");


            SceneManager.LoadScene(0);
        }
    }
    
    
    
}

