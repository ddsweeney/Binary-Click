using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DisplayDbController : MonoBehaviour
{
    //Declares variables

    //Series of text objects, used to display the data from database
    public TMP_Text nametxt1;
    public TMP_Text nametxt2;
    public TMP_Text nametxt3;
    public TMP_Text nametxt4;
    public TMP_Text nametxt5;
    public TMP_Text scoretxt1;
    public TMP_Text scoretxt2;
    public TMP_Text scoretxt3;
    public TMP_Text scoretxt4;
    public TMP_Text scoretxt5;

    public TMP_Text extraname;
    public TMP_Text extrascore;

    public string playerScores; //String ariable used to hold data from databse

    public string[] data; //String array to hold each piece of data from each cell of the database

    //Function that selects the URL used for binary to decimal
    public void DisplayBintodecDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplaybintodecDB.php")); //Connect using this URL
    }

    //Function that selects the URL used for binary to hexadecimal
    public void DisplayBintohexDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplaybintohexDB.php"));

    }



    //Function that selects the URL used for decimal to binary
    public void DisplayDectobinDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplaydectobinDB.php"));
    }

    //Function that selects the URL used for decimal to hexadecimal
    public void DisplayDectohexDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplaydectohexDB.php"));
    }

    //Function that selects the URL used for hexadecimal to binary
    public void DisplayHextobinDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplayhextobinDB.php"));

    }

    //Function that selects the URL used for hexadecimal to decimal
    public void DisplayHextodecDB()
    {
        StartCoroutine(RetrieveDB("https://users.aber.ac.uk/das74/MajorProject/DisplayhextodecDB.php"));

    }

    //IEnumerator that returns a unity web requests that gets the player name and score from the database and displays it in unity
    IEnumerator RetrieveDB(string URL)
    {


        nametxt1.text = null;
        nametxt2.text = null;
        nametxt3.text = null;
        nametxt4.text = null;
        nametxt5.text = null;

        scoretxt1.text = null;
        scoretxt2.text = null;
        scoretxt3.text = null;
        scoretxt4.text = null; 
        scoretxt5.text = null;

        extraname.text = null;
        extrascore.text = null;

        //Uses get to retrieve data from the URL
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log("Connection loaded incomplete!");

        }
        else
        {
            Debug.Log("Connection loaded complete!");
            Debug.Log(www.downloadHandler.text);


            //Sets string variable to equal the data from the web request
            playerScores = www.downloadHandler.text;

            //Splits the data and puts it into a string array
            data = playerScores.Split();

            if (data.Length >= 2)
            {
                extraname.text = data[0];
                extrascore.text = data[1];

            }

            if (data.Length >= 4)
            {

                nametxt1.text = data[2];
                scoretxt1.text = data[3];
            }

            if (data.Length >= 6)
            {

                nametxt2.text = data[4];
                scoretxt2.text = data[5];
            }

            if (data.Length >= 8)
            {
                nametxt3.text = data[6];
                scoretxt3.text = data[7];
            }

            if (data.Length >= 10)
            {
                nametxt4.text = data[8];
                scoretxt4.text = data[9];
            }
            if (data.Length >= 12)
            {
                nametxt5.text = data[10];
                scoretxt5.text = data[11];
            }
        }
    }

   

}
