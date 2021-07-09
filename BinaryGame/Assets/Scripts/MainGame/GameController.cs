using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.Localization.Components;

/*Code reuse/rewrote from Youtube Tutorial by Brackeys 
 * URL: https://www.youtube.com/watch?v=5CW1yGsVg4k
 * 
 * Lines: 31 to 71 
 *  
 * Code in LoadValue Function line 461

 * Code in GetValue Function line 603
 * 
 * Code in functions RemoveBinToDecValue,RemoveBinToHexValue,RemoveHexToDecValue,
 * RemoveHexToBinValue,RemoveDecToBinValue,RemoveDecToHexValue
 * 
 * 
 */




public class GameController : MonoBehaviour
{
    
    //Declare variables
    bool start = false;

    //Variables used to store and help display the question set, binary to decimal
    public BintodecClass[] binToDec;
    public static List<BintodecClass> unUsedBinToDecValue;
    public BintodecClass currentBinToDecValue;

    //Variables used to store and help display the question set, decimal to binary 
    private DectobinClass[] decToBin;
    private static List<DectobinClass> unUsedDecToBinValue;
    private DectobinClass currentDecToBinValue;

    //Variables used to store and help display the question set, binary to hexadecimal
    private BintohexClass[] binToHex;
    private static List<BintohexClass> unUsedBinToHexValue;
    private BintohexClass currentBinToHexValue;

    //Variables used to store and help display the question set, hexadecimal to binary
    private HextobinClass[] hexToBin;
    private static List<HextobinClass> unUsedHexToBinValue;
    private HextobinClass currentHexToBinValue;

    //Variables used to store and help display the question set, decimal to hexadecimal
    private DectohexClass[] decToHex;
    private static List<DectohexClass> unUsedDecToHexValue;
    private DectohexClass currentDecToHexValue;

    //Variables used to store and help display the question set, hexadecimal to binary
    private HextodecClass[] hexToDec;
    private static List<HextodecClass> unUsedHexToDecValue;
    private HextodecClass currentHexToDecValue;

    //Variables used to store and display the incorrect answers for binary answers
    private Binary[] binary;
    private static List<Binary> unUsedBinaryValue;
    private Binary currentBinary;

    //Variables used to store and help display the incorrect answers for hexadecimal answers
    private Hexadecimal[] hexValues;
    private static List<Hexadecimal> unUsedHexValue;
    private Hexadecimal currentHexadecimal;

    public TMP_Text questionDisplay; //Text object used to display the question
    public TMP_Text correctAnswerText; //Text object used to display the correct answer
    public GameObject correctAnswer; //The correct answer game object

    //Variables used to change and display the incorrect answers in order
    public GameObject[] answerValue;
    public static List<GameObject> unChangedAnswer;
    public GameObject currentAnswer;

    public string currentDecimal;//Current random decimal value for incorrect answers

    //Integer variables to boundaries for the game objects to not pass
    public int minRangeX = 0;
    public int maxRangeX = 0;
    public int minRangeY = 0;
    public int maxRangeY = 0;

    public TMP_Text healthText; //Text object that displays players health
    public int health = 3; //Integer variable for players health
    [SerializeField] private TMP_Text scoreText;//Text object that displays the players score

    public int endlessScore = 0; //Integer variable  for score for the endless game mode
    public int timeTrialScore = 0; //Integer variable  for score for the time trial game mode
    public int amountOfScore = 1; //Integer variable  for amount of score is increases when an correct answer is clicked
    public int totalScoreEndless;//Integer variable  for the total score for the endless game mode

    [SerializeField] private TMP_Text timerText; //Text object that displays players health
    [SerializeField] private float maxTime = 30f; //Integer variable for the max time 

    [SerializeField] private TMP_Text gameOverScore;//Text object that displays final score
    [SerializeField] private TMP_Text gameOverTotalScoreText;//Text object that displays players best score

    //Canvas variables for menus
    public Canvas gameOverCanvas;
    public Canvas timeTrialCanvas;
    public Canvas StartBtnCanvas;
    [SerializeField] private TMP_Text endlessText;
    [SerializeField] private TMP_Text timeTrialText;

    public int currentLevel = 1; //Integer variable for the current level
    [SerializeField] private TMP_Text levelText; //Text object that displays the current level
    [SerializeField] private TMP_Text levelTitleText; //Text object that displays the current level title 


    //Game object varaibles for each incorrect answer game objects
    [SerializeField] private GameObject showbutton;
    [SerializeField] private GameObject showbuttonOne;
    [SerializeField] private GameObject showbuttonTwo;
    [SerializeField] private GameObject showbuttonThree;
    [SerializeField] private GameObject showbuttonFour;
    [SerializeField] private GameObject showbuttonFive;
    [SerializeField] private GameObject showbuttonSix;
    [SerializeField] private GameObject showbuttonSeven;
    [SerializeField] private GameObject showbuttonEight;
    [SerializeField] private GameObject showbuttonNine;

    private float timeLeft; //Float variable for the time left in timer
    private float bestTime; //Float variable for the players best time
    [SerializeField] private TMP_Text totalTimetext; //Text object that displays the players time at the end of the time trial
    [SerializeField] private TMP_Text bestTimetext; //Text object that displays the players best time at the end of the time trial

    //Vairables that link power up scripts to game controller
    public ShieldScript shield;
    public BombScript bomb;

    //String varaibles for each data set for when retrieving data formm the json files
    public string dataSet1;
    public string dataSet2;

    [SerializeField] private Image activePowerUpImage; //Image variable that displays the currentActivePowerUp

    [SerializeField] private TMP_Text powerUpText; //Text object variable that displays title about active power up image

    int endScore; //Integer variable used to store player pref value
    float saveTime; //Float variable used to store player pref value

    


    // Start is called before the first frame update
    void Start()
    {
       

        //Empties all lists
        unUsedBinToDecValue = null;
        unUsedBinToHexValue = null;
        unUsedDecToBinValue = null;
        unUsedDecToHexValue = null;
        unUsedHexToBinValue = null;
        unUsedHexToDecValue = null;
        unChangedAnswer = null;
        unUsedBinaryValue = null;
        unUsedHexValue = null;

        // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
        if (QuestionSelectController.binToDec == true)
        {            
            //Connect to this URL 
            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/bintodec.JSON"));
        }

        if (QuestionSelectController.decToBin == true)
        {
            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/dectobin.JSON"));
            StartCoroutine(LoadRandomAnswerData("https://users.aber.ac.uk/das74/MajorProject/binary.json"));

        }

        if (QuestionSelectController.binToHex == true)
        {
            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/bintohex.JSON"));
            StartCoroutine(LoadRandomAnswerData("https://users.aber.ac.uk/das74/MajorProject/hexadecimal.json"));

        }

        if (QuestionSelectController.hexToBin == true)
        {

            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/hextobin.JSON"));
            StartCoroutine(LoadRandomAnswerData("https://users.aber.ac.uk/das74/MajorProject/binary.json"));

        }

        if (QuestionSelectController.decToHex == true)
        {

            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/dectohex.JSON"));
            StartCoroutine(LoadRandomAnswerData("https://users.aber.ac.uk/das74/MajorProject/hexadecimal.json"));


        }

        if (QuestionSelectController.hexToDec == true)
        {

            StartCoroutine(LoadQuestionData("https://users.aber.ac.uk/das74/MajorProject/hextodec.JSON"));
        }


        Time.timeScale = 0; //Pauses the game

        
        StartBtnCanvas.enabled = true; //Sets the start canvas enabled to true which makes it appear/enabled
        gameOverCanvas.enabled = false; //Sets the game over canvas enabled to false which makes it disappear/disabled
        timeTrialCanvas.enabled = false; //Sets the time trial game over canvas enabled to false which makes it disappear/disabled


        BestScore(); // Calls the BestScore function;


        //if statement for if endless is true
        if (GameModeController.endless == true)
        {
            endlessText.enabled = true;
            timeTrialText.enabled = false;
            timeLeft = maxTime;//timeleft is equal to maxtime

            DisableAnswers();//Calls the DisableAnswers function
        }

        //if statement for if timeTrial is true
        if (GameModeController.timeTrial == true)
        {

            endlessText.enabled = false;
            timeTrialText.enabled = true;

            timeLeft = 0; //timeleft is set to zero

            powerUpText.enabled = false; //Sets the powerUpText enabled to false which makes it disappear/disabled

            //Sets all incorrect answers SetActive to true which makes them all visable and active in game
            showbuttonOne.SetActive(true);
            showbuttonTwo.SetActive(true);
            showbuttonThree.SetActive(true);
            showbuttonFour.SetActive(true);
            showbuttonFive.SetActive(true);
            showbuttonSix.SetActive(true);
            showbuttonSeven.SetActive(true);
            showbuttonEight.SetActive(true);
            showbuttonNine.SetActive(true);
        }

        correctAnswer.SetActive(true);//Sets the correct answer to be active and appear
        showbutton.SetActive(true);//Sets the first incorrect answer to be active and appear
        activePowerUpImage.enabled = false;//Sets the activePowerUpImage enable to be false and not appear

        scoreText.text = "Score: " + endlessScore;
    }



    // Update is called once per frame
    void Update()
    {

        LevelUp(); // Calls the LevelUp function

        // if statement for if bomb power up is active and true
        if (bomb.bombActive == true)
        {
            // Sets a set of incorrect answers SetActive to false which makes them disappear
            showbuttonOne.SetActive(false);
            showbuttonThree.SetActive(false);
            showbuttonFive.SetActive(false);
            showbuttonSeven.SetActive(false);
            showbuttonNine.SetActive(false);

        }
        // if statement for if bomb power up is not active and false
        else if (bomb.bombActive == false)
        {
            // Series of if statement that set the incorrect answers to be active depending on the players score
            if (endlessScore >= 10)
            {
                showbuttonOne.SetActive(true);

            }
            if (endlessScore >= 30)
            {
                showbuttonThree.SetActive(true);

            }
            if (endlessScore >= 50)
            {
                showbuttonFive.SetActive(true);

            }
            if (endlessScore >= 70)
            {
                showbuttonSeven.SetActive(true);

            }
            if (endlessScore >= 90)
            {
                showbuttonNine.SetActive(true);

            }

        }

        //if statement that sets varaibles for the time trial mode
        if (GameModeController.timeTrial == true)
        {
            timeLeft += Time.deltaTime;

            timerText.text = timeLeft.ToString("f2");

            healthText.enabled = false;
            levelText.enabled = false;
            levelTitleText.enabled = false;
            health = 1000;

            if (timeTrialScore >= 10)
            {
                Time.timeScale = 0;
                timeTrialCanvas.enabled = true;
                DisableAnswers();
                BestTime();
                BestScore();
            }
        }
        //else if statement that sets varaibles for the endless mode
        else if (GameModeController.endless == true)
        {


            timeLeft -= Time.deltaTime;

            timerText.text = timeLeft.ToString("f2");

            if (timeLeft <= 0)
            {

                GameOver();

                DisableAnswers();

            }

        }



        //if statement for if health is less than or equal for 0
        if (health <= 0)
        {
            health = 0; //health is equal to zero

            GameOver(); //Calls GameOver function
        }


        //if statement if start is true
        if (start == true)
        {

            LoadValue(); //Call LoadValue function

                
                unChangedAnswer = answerValue.ToList(); //game objects from the answerValue array are put into the unChangedAnswer list

            //For loop that loops the number of objects in the unChangedAnswer list
                for (int i = 0; i < unChangedAnswer.Count; i++)
                {

                    currentAnswer = unChangedAnswer[i];//Current answer is equal to the current object in list

                //if statement for when the current game object text in list is equal to the correct answer text then 
                if (currentAnswer.GetComponentInChildren<TMP_Text>().text == correctAnswerText.text) {

                    // if statement to say if binary to decimal is true/selected or if hexadecimal to decimal is true/selected
                    if ((QuestionSelectController.binToDec == true) || (QuestionSelectController.hexToDec == true))
                    {

                        int randomDecimal = Random.Range(0, 129); //Generates a random decimal value between 0 and 129

                        currentDecimal = randomDecimal.ToString(); //currentDecimal is set to equal the random decimal value
                        currentAnswer.GetComponentInChildren<TMP_Text>().text = currentDecimal;//the text object, which is the child of current answer game object in list, is set to equal the new current decimal



                    }
                    // if statement to say if decimal to binary is true/selected or if hexadecimal to binary is true/selected
                    if ((QuestionSelectController.decToBin == true) || (QuestionSelectController.hexToBin == true))
                    {
                        int randomBinary = Random.Range(0, unUsedBinaryValue.Count); //Generates a random decimal value between 0 and the number of objects in the list

                        currentBinary = unUsedBinaryValue[randomBinary]; //currentBinary is equal to the current random binary value from the list 
                        currentAnswer.GetComponentInChildren<TMP_Text>().text = currentBinary.binaryAnswer; //the text object, which is the child of current answer game object in list, is set to equal the new binaryAnswer


                    }
                    // if statement to say if binary to hexadecimal is true/selected or if decimal to hexadecimal is true/selected
                    if ((QuestionSelectController.binToHex == true) || (QuestionSelectController.decToHex == true))
                    {
                        int randomHexadecimal = Random.Range(0, unUsedHexValue.Count);//Generates a random decimal value between 0 and the number of objects in the list

                        currentHexadecimal = unUsedHexValue[randomHexadecimal]; //currentHexadecimal is equal to the current random hexadecimal value from the list 
                        currentAnswer.GetComponentInChildren<TMP_Text>().text = currentHexadecimal.hexValue;//the text object, which is the child of current answer game object in list, is set to equal the new hexValue



                    }

                }
            }


            
        }
    }

    //StartGame Function which when called, unpauses and starts the game
    public void StartGame()
    {


        Time.timeScale = 1;

        currentLevel = 1;
        endlessScore = 0;
        timeTrialScore = 0;

        LoadValue();
        GetValues();
        GetRandomValue();

        start = true;

        StartBtnCanvas.enabled = false;



    }


    //LoadValue function which puts the data redieved from the json file into the correct arrays and lists for the game to work
    void LoadValue() {



        // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
        if (QuestionSelectController.binToDec == true)
        
        {
            //if statement to say if the list is null/empty or equals zero
            if (unUsedBinToDecValue == null || unUsedBinToDecValue.Count == 0)
            {


                BintodecArray bintodecArray = JsonUtility.FromJson<BintodecArray>(dataSet1); //Gains data from the json file and puts it in the class binarytodecArray (wrapper)


                binToDec = bintodecArray.BintodecClass; //data from the array in the bintodecArray class is put into the binToDec array


                unUsedBinToDecValue = binToDec.ToList(); //data sets from the binToDec array are put into the unUsedBinToDecValue list


            }
        }


        if (QuestionSelectController.decToBin == true)
            {

            if (unUsedDecToBinValue == null || unUsedDecToBinValue.Count == 0)
            {

              

            
                DectobinArray dectobinArray = JsonUtility.FromJson<DectobinArray>(dataSet1); //Gains data from the json file and puts it in the class dectobinArray (wrapper)

                decToBin = dectobinArray.DectobinClass; //data from the array in the dectobinArray class is put into the decToBin array

                unUsedDecToBinValue = decToBin.ToList(); //data sets from the decToBin array are put into the unUsedDecToBinValue list



                BinaryArray binaryArray = JsonUtility.FromJson<BinaryArray>(dataSet2); //Gains data from the json file and puts it in the class binaryArray (wrapper)

                binary = binaryArray.Binary; // data from the array in the binaryArray class is put into the binary array

                unUsedBinaryValue = binary.ToList(); //data sets from the binary array are put into the unUsedBinaryValue list



            }
        }

        if (QuestionSelectController.binToHex == true)
            {
            if (unUsedBinToHexValue == null || unUsedBinToHexValue.Count == 0)
            {
            

                

                BintohexArray bintohexArray = JsonUtility.FromJson<BintohexArray>(dataSet1); //Gains data from the json file and puts it in the class bintohexArray (wrapper)

                binToHex = bintohexArray.BintohexClass; //data from the array in the bintohexArray class is put into the binToHex array

                unUsedBinToHexValue = binToHex.ToList(); //data sets from the binToHex array are put into the unUsedBinToHexValue list



                HexadecimalArray hexadecimalArray = JsonUtility.FromJson<HexadecimalArray>(dataSet2); //Gains data from the json file and puts it in the class hexadecimalArray (wrapper)

                hexValues = hexadecimalArray.Hexadecimal; //data from the array in the hexadecimalArray class is put into the hexValues array

                unUsedHexValue = hexValues.ToList(); //data sets from the hexValues array are put into the unUsedHexValue list



            }
        }


        if (QuestionSelectController.hexToBin == true)
            {
            if (unUsedHexToBinValue == null || unUsedHexToBinValue.Count == 0)
            {


                HextobinArray hextobinArray = JsonUtility.FromJson<HextobinArray>(dataSet1); //Gains data from the json file and puts it in the class hextobinArray (wrapper)

                hexToBin = hextobinArray.HextobinClass; //data from the array in the hextobinArray class is put into the hexToBin array

                unUsedHexToBinValue = hexToBin.ToList(); //data sets from the hexToBin array are put into the unUsedHexToBinValue list



                BinaryArray binaryArray = JsonUtility.FromJson<BinaryArray>(dataSet2); //Gains data from the json file and puts it in the class binaryArray (wrapper)

                binary = binaryArray.Binary; //data from the array in the dectobinArray class is put into the decToBin array

                unUsedBinaryValue = binary.ToList(); //data sets from the binary array are put into the unUsedBinaryValue list


            }
        }

        if (QuestionSelectController.decToHex == true)
            {
            if (unUsedDecToHexValue == null || unUsedDecToHexValue.Count == 0)
            {


              
                DectohexArray dectohexArray = JsonUtility.FromJson<DectohexArray>(dataSet1); //Gains data from the json file and puts it in the class dectohexArray (wrapper)

                decToHex = dectohexArray.DectohexClass; //data from the array in the dectohexArray class is put into the decToHex array

                unUsedDecToHexValue = decToHex.ToList(); //data sets from the decToHex array are put into the unUsedDecToHexValue list


                HexadecimalArray hexadecimalArray = JsonUtility.FromJson<HexadecimalArray>(dataSet2); //Gains data from the json file and puts it in the class hexadecimalArray (wrapper)

                hexValues = hexadecimalArray.Hexadecimal; //data from the array in the hexadecimalArray class is put into the hexValues array

                unUsedHexValue = hexValues.ToList(); //data sets from the hexValues array are put into the unUsedHexValue list

            }
        }


        if (QuestionSelectController.hexToDec == true)
            {
            if (unUsedHexToDecValue == null || unUsedHexToDecValue.Count == 0)
            {
               

               
                HextodecArray hextodecArray = JsonUtility.FromJson<HextodecArray>(dataSet1); //Gains data from the json file and puts it in the class hextodecArray (wrapper)

                hexToDec = hextodecArray.HextodecClass; //data from the array in the hextodecArray class is put into the hexToDec array

                unUsedHexToDecValue = hexToDec.ToList(); //data sets from the hexToDec array are put into the unUsedHexToDecValue list


            }
        }
        
    }
    // GetValues function gets the next question and its correct answer and displays it
    void GetValues()
    {

        // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
        if (QuestionSelectController.binToDec == true)
        {
            int randomQuestion = Random.Range(0, unUsedBinToDecValue.Count); // Randomly generates a decimal number between 0 and the number of values in the list

            currentBinToDecValue = unUsedBinToDecValue[randomQuestion]; //currentBinToDecValue is equal to the current random set of binary to decimal data from the list

            questionDisplay.text = currentBinToDecValue.binaryAnswer; //questionDisplay is equal and display the current binary value
            correctAnswerText.text = currentBinToDecValue.decimalValue; //correctAnswerText is equal and display the current decimal value
        }

        else if (QuestionSelectController.decToBin == true)
        {
            int randomQuestion = Random.Range(0, unUsedDecToBinValue.Count); // Randomly generates a decimal number between 0 and the number of values in the list


            currentDecToBinValue = unUsedDecToBinValue[randomQuestion]; //currentDecToBinValue is equal to the current random set of decimal to binary data from the list

            questionDisplay.text = currentDecToBinValue.decimalValue; //questionDisplay is equal and display the current decimal value
            correctAnswerText.text = currentDecToBinValue.binaryAnswer; //correctAnswerText is equal and display the current binary value
        }

        else if (QuestionSelectController.binToHex == true)
        {
            int randomQuestion = Random.Range(0, unUsedBinToHexValue.Count); 

            currentBinToHexValue = unUsedBinToHexValue[randomQuestion];

            questionDisplay.text = currentBinToHexValue.binaryAnswer; 
            correctAnswerText.text = currentBinToHexValue.hexValue; 
        }

        else if (QuestionSelectController.hexToBin == true)
        {
            int randomQuestion = Random.Range(0, unUsedHexToBinValue.Count); // Randomly generates a decimal number between 0 and the number of values in the list


            currentHexToBinValue = unUsedHexToBinValue[randomQuestion]; //currentHexToBinValue is equal to the current random set of hexadecimal to binary data from the list

            questionDisplay.text = currentHexToBinValue.hexValue; //questionDisplay is equal and display the current hexadecimal value
            correctAnswerText.text = currentHexToBinValue.binaryAnswer; //correctAnswerText is equal and display the current binary value
        }

        else if (QuestionSelectController.decToHex == true)
        {
            int randomQuestion = Random.Range(0, unUsedDecToHexValue.Count); 


            currentDecToHexValue = unUsedDecToHexValue[randomQuestion]; 

            questionDisplay.text = currentDecToHexValue.decimalValue; 
            correctAnswerText.text = currentDecToHexValue.hexValue; 
        }
        else if (QuestionSelectController.hexToDec == true)
        {
            int randomQuestion = Random.Range(0, unUsedHexToDecValue.Count); 


            currentHexToDecValue = unUsedHexToDecValue[randomQuestion]; 

            questionDisplay.text = currentHexToDecValue.hexValue; 
            correctAnswerText.text = currentHexToDecValue.decimalValue; 
        }
       
    }

    //CorrectAnswer function is called when a correct answer is clicked
    public void CorrectAnswer()
    {

        ScoreIncreases(); // Calls ScoreIncreases function

        ReloadValue(); // Calls ReloadValue function

        //Two if statements that remove power up images depending on if they are already active or not
        if (bomb.bombActive == true)
        {
            bomb.bombActive = false; 
            activePowerUpImage.enabled = false; 
             
            
            if (shield.shieldActive == true)
            {
                activePowerUpImage.enabled = true;
                activePowerUpImage.sprite = shield.shieldImage;

            }
        }

    }

    //InCorrectAnswer function is called when a incorrect answer is clicked
    public void InCorrectAnswer()
    {

       //if statement for is the shield is active, and a incorrect answer is clicked, player doesnt lose health
            if (shield.shieldActive == true)
            {
                shield.shieldActive = false;

         

           }
        else
            {
                HealthDecreases();// Calls HealthDecreases function
        }

        


        ReloadValue();// Calls ReloadValue function

        if (bomb.bombActive == true)
        {
            bomb.bombActive = false;

            activePowerUpImage.enabled = false;

            
        }


    }


    //GetRandomValue Function which gets the random value for all the incorrect answer game objects
    void GetRandomValue()
    {


        unChangedAnswer = answerValue.ToList();//game objects from the answerValue array are put into the unChangedAnswer list


            //For loop that loops the number of objects in the unChangedAnswer list
            for (int i = 0; i < unChangedAnswer.Count; i++)
            {

                currentAnswer = unChangedAnswer[i];//Current answer is equal to the current object in list



            // if statement to say if binary to decimal is true/selected or if hexadecimal to decimal is true/selected
            if ((QuestionSelectController.binToDec == true) || (QuestionSelectController.hexToDec == true))
            {

                int randomDecimal = Random.Range(0, 129); //Generates a random decimal value between 0 and 129

                currentDecimal = randomDecimal.ToString(); //currentDecimal is set to equal the random decimal value
                currentAnswer.GetComponentInChildren<TMP_Text>().text = currentDecimal;//the text object, which is the child of current answer game object in list, is set to equal the new current decimal



            }
            // if statement to say if decimal to binary is true/selected or if hexadecimal to binary is true/selected
            if ((QuestionSelectController.decToBin == true) || (QuestionSelectController.hexToBin == true))
            {
                int randomBinary = Random.Range(0, unUsedBinaryValue.Count); //Generates a random decimal value between 0 and the number of objects in the list

                currentBinary = unUsedBinaryValue[randomBinary]; //currentBinary is equal to the current random binary value from the list  
                currentAnswer.GetComponentInChildren<TMP_Text>().text = currentBinary.binaryAnswer; //the text object, which is the child of current answer game object in list, is set to equal the new binaryAnswer


            }
            // if statement to say if binary to hexadecimal is true/selected or if decimal to hexadecimal is true/selected
            if ((QuestionSelectController.binToHex == true) || (QuestionSelectController.decToHex == true))
            {
                int randomHexadecimal = Random.Range(0, unUsedHexValue.Count);//Generates a random decimal value between 0 and the number of objects in the list

                currentHexadecimal = unUsedHexValue[randomHexadecimal]; //currentHexadecimal is equal to the current random hexadecimal value from the list 
                currentAnswer.GetComponentInChildren<TMP_Text>().text = currentHexadecimal.hexValue;//the text object, which is the child of current answer game object in list, is set to equal the new hexValue



            }


        }
    }

    //ReloadValue function is used to remove the current data sets and load the next one 
    void ReloadValue()
    {

        // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
        if (QuestionSelectController.binToDec == true)
        {

            RemoveBinToDecValue();

        }

        else if (QuestionSelectController.decToBin == true)
        {
            RemoveDecToBinValue();

        }

        else if (QuestionSelectController.binToHex == true)
        {
            RemoveBinToHexValue();

        }

        else if (QuestionSelectController.hexToBin == true)
        {
            RemoveHexToBinValue();

        }

        else if (QuestionSelectController.decToHex == true)
        {
            RemoveDecToHexValue();

        }
        else if (QuestionSelectController.hexToDec == true)
        {
            RemoveHexToDecValue();

        }
       

        GetValues();
        GetRandomValue();



    }

    //RemoveBinToDecValue function removes the current binary to decimal value from the list 
    void RemoveBinToDecValue()
    {

        unUsedBinToDecValue.Remove(currentBinToDecValue);

        unUsedBinToDecValue = binToDec.ToList();

    }


    //RemoveDecToBinValue function removes the current decimal to binary value from the list 
    void RemoveDecToBinValue()
    {

        unUsedDecToBinValue.Remove(currentDecToBinValue);

        unUsedDecToBinValue = decToBin.ToList();

    }


    //RemoveBinToHexValue function removes the current binary to hexadecimal value from the list 
    void RemoveBinToHexValue()
    {

        unUsedBinToHexValue.Remove(currentBinToHexValue);

        unUsedBinToHexValue = binToHex.ToList();

    }


    //RemoveHexToBinValue function removes the current hexadecimal to binary value from the list 
    void RemoveHexToBinValue()
    {

        unUsedHexToBinValue.Remove(currentHexToBinValue);

        unUsedHexToBinValue = hexToBin.ToList();

    }


    //RemoveDecToHexValue function removes the current decimal to hexadecimal value from the list 
    void RemoveDecToHexValue()
    {

        unUsedDecToHexValue.Remove(currentDecToHexValue);

        unUsedDecToHexValue = decToHex.ToList();

    }


    //RemoveHexToDecValue function removes the current hexadecimal to decimal value from the list 
    void RemoveHexToDecValue()
    {

        unUsedHexToDecValue.Remove(currentHexToDecValue);

        unUsedHexToDecValue = hexToDec.ToList();

    }

    //ScoreIncreases functions increases the score by the amount set at the time
    void ScoreIncreases()
    {
        //If statement to say if endless is true/selected
        if (GameModeController.endless == true)
        {
            //Updates the current locales text with the variable
            endlessScore += amountOfScore;
            scoreText.text = "Score: " + endlessScore;

        }
        //Else if statement to say if timeTrial is true/selected
        else if (GameModeController.timeTrial == true)
        {
            timeTrialScore += amountOfScore;
            scoreText.text = "Score: " + timeTrialScore;

        }
    }

    //HealthDecreases functions decreases the health by one
    void HealthDecreases()
    {
        health -= 1;

        //Updates the current locales text with the variable
        healthText.text = "Health: " + health;

    }


    //GameOver function stops the game and displays the endless game over canvas
    public void GameOver()
    {
        Time.timeScale = 0;

        DisableAnswers();

        //If statement to say if endless is true/selected
        if (GameModeController.endless == true)
        {
            gameOverCanvas.enabled = true;


            BestScore();
        }

    }

    void BestScore()
    {

        //If statement to say if endless is true/selected
        if (GameModeController.endless == true)
        {

            // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
            if (QuestionSelectController.binToDec == true)
            {

                 endScore = PlayerPrefs.GetInt("BintodecScore"); //Gets the best score for binary to decimal questions 


            }
            if (QuestionSelectController.decToBin == true)
            {
                endScore = PlayerPrefs.GetInt("DectobinScore"); //Gets the best score for decimal to binary questions 

            }
            if (QuestionSelectController.binToHex == true)
            {
                endScore = PlayerPrefs.GetInt("BintohexScore"); //Gets the best score for binary to hexadecimal questions 

            }
            if (QuestionSelectController.hexToBin == true)
            {
                endScore = PlayerPrefs.GetInt("HextobinScore"); //Gets the best score for hexadecimal to binary questions 

            }
            if (QuestionSelectController.decToHex == true)
            {
                endScore = PlayerPrefs.GetInt("DectohexScore"); //Gets the best score for decimal to hexadecimal questions 

            }
            if (QuestionSelectController.hexToDec == true)
            {
                endScore = PlayerPrefs.GetInt("HextodecScore"); //Gets the best score for hexadecimal to decimal questions 

            }

          //  dynamticLocaleVaribles.displayScore = endlessScore.ToString();
            gameOverScore.text = "Score: " + endlessScore; //Displays the players current score in the text object on the game over canvas

            gameOverTotalScoreText.text = "Best Score: " + endScore; // Displays the players best score from player prefs in the text object on the game over canvas


            //if statement for if the best score integer is less than or equal to the current score
            if (totalScoreEndless <= endlessScore)
            {
                totalScoreEndless = endlessScore; // The best score integer is set to the current score


                //if statement for if the best score integer is greater than or equal to the current best score saved in player prefs
                if (totalScoreEndless >= endScore)
                {


                    // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
                    if (QuestionSelectController.binToDec == true)
                    {

                        PlayerPrefs.SetInt("BintodecScore", totalScoreEndless); //Saves the new best score to the player prefs


                    }
                    if (QuestionSelectController.decToBin == true)
                    {
                        PlayerPrefs.SetInt("DectobinScore", totalScoreEndless); //Saves the new best score to the player prefs

                    }
                    if (QuestionSelectController.binToHex == true)
                    {
                        PlayerPrefs.SetInt("BintohexScore", totalScoreEndless); //Saves the new best score to the player prefs

                    }
                    if (QuestionSelectController.hexToBin == true)
                    {
                        PlayerPrefs.SetInt("HextobinScore", totalScoreEndless); //Saves the new best score to the player prefs

                    }
                    if (QuestionSelectController.decToHex == true)
                    {
                        PlayerPrefs.SetInt("DectohexScore", totalScoreEndless); //Saves the new best score to the player prefs

                    }
                    if (QuestionSelectController.hexToDec == true)
                    {
                        PlayerPrefs.SetInt("HextodecScore", totalScoreEndless); //Saves the new best score to the player prefs

                    }

                    gameOverTotalScoreText.text = "Best Score: " + totalScoreEndless; // Displays the new best score on the game over canvas

                }
              

            }

        }

       
        
    }
        

    

    void BestTime()
    {





        //If statement to say if timetrial is true/selected
        if (GameModeController.timeTrial == true)
        {

            // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
            if (QuestionSelectController.binToDec == true)
            {
                saveTime = PlayerPrefs.GetFloat("BintodecTime"); //Gets the best time for binary to decimal questions 

            }
            if (QuestionSelectController.decToBin == true)
            {
                saveTime = PlayerPrefs.GetFloat("DectobinTime"); //Gets the best time for decimal to binary questions 

            }
            if (QuestionSelectController.binToHex == true)
            {
                saveTime = PlayerPrefs.GetFloat("BintohexTime"); //Gets the best time for binary to hexadecimal questions 

            }
            if (QuestionSelectController.hexToBin == true)
            {
                saveTime = PlayerPrefs.GetFloat("HextobinTime"); //Gets the best time for hexadecimal to binary questions 

            }
            if (QuestionSelectController.decToHex == true)
            {
                saveTime = PlayerPrefs.GetFloat("DectohexTime"); //Gets the best time for decimal to hexadecimal questions 

            }
            if (QuestionSelectController.hexToDec == true)
            {
                saveTime = PlayerPrefs.GetFloat("HextodecTime"); //Gets the best time for hexadecimal to decimal questions 

            }

            totalTimetext.text = "Time: " + timeLeft; //Displays the players current time on the time trial canvas

            bestTimetext.text = "Best Time: " + saveTime; //Displays the players best time from player prefs on the time trial canvas

            //if statement for if best time is greater than or equal to the current time or zero
            if ((bestTime >= timeLeft) || (bestTime == 0))
            {
                bestTime = timeLeft; // best time equals the current time


                //if statement for if best time is less than or equal to the current best time from the player pre or is the time from player pref equals zero
                if ((bestTime <= saveTime) || (saveTime == 0))
                {

                    // Series of if statements which depend on which button is clicked from the question select scene (question set is selected/boolean is true)
                    if (QuestionSelectController.binToDec == true)
                    {
                        PlayerPrefs.SetFloat("BintodecTime", bestTime); //Saves the new best time to the player prefs

                    }
                    if (QuestionSelectController.decToBin == true)
                    {
                        PlayerPrefs.SetFloat("DectobinTime", bestTime); //Saves the new best time to the player prefs

                    }
                    if (QuestionSelectController.binToHex == true)
                    {
                        PlayerPrefs.SetFloat("BintohexTime", bestTime); //Saves the new best time to the player prefs

                    }
                    if (QuestionSelectController.hexToBin == true)
                    {
                        PlayerPrefs.SetFloat("HextobinTime", bestTime); //Saves the new best time to the player prefs

                    }
                    if (QuestionSelectController.decToHex == true)
                    {
                        PlayerPrefs.SetFloat("DectohexTime", bestTime); //Saves the new best time to the player prefs

                    }
                    if (QuestionSelectController.hexToDec == true)
                    {
                        PlayerPrefs.SetFloat("HextodecTime", bestTime); //Saves the new best time to the player prefs

                    }

                    bestTimetext.text = "Best Time: " + bestTime; //Displays the players new best time on the time trial canvas

                }

            }


        }
    }

    //DisableAnswer function which sets all answer game objects setactive to false and removes them from game
    void DisableAnswers()
    {
        correctAnswer.SetActive(false);
        showbutton.SetActive(false);
        showbuttonOne.SetActive(false);
        showbuttonTwo.SetActive(false);
        showbuttonThree.SetActive(false);
        showbuttonFour.SetActive(false);
        showbuttonFive.SetActive(false);
        showbuttonSix.SetActive(false);
        showbuttonSeven.SetActive(false);
        showbuttonEight.SetActive(false);
        showbuttonNine.SetActive(false);
    }

    
    //LevelUp function
    public void LevelUp()
    {
        switch (currentLevel) //Switch statement for that when the score goes up by ten, current level increase by one, maxtime decreases by one and a new incorrect answer game object is added
        {
            case 1:

                if (currentLevel == 1 && endlessScore >= 10)
                {
                    currentLevel = 2;

                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonOne.SetActive(true);


                }


                break;

            case 2:
                if (currentLevel == 2 && endlessScore >= 20)
                {
                    currentLevel = 3;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonTwo.SetActive(true);
                }

                break;

            case 3:
                if (currentLevel == 3 && endlessScore >= 30)
                {
                    currentLevel = 4;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonThree.SetActive(true);
                }

                break;
            case 4:
                if (currentLevel == 4 && endlessScore >= 40)
                {
                    currentLevel = 5;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonFour.SetActive(true);
                }

                break;
            case 5:
                if (currentLevel == 5 && endlessScore >= 50)
                {
                    currentLevel = 6;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonFive.SetActive(true);
                }

                break;
            case 6:
                if (currentLevel == 6 && endlessScore >= 60)
                {
                    currentLevel = 7;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonSix.SetActive(true);
                }

                break;
            case 7:
                if (currentLevel == 7 && endlessScore >= 70)
                {
                    currentLevel = 8;
                    maxTime -= 1;
                    timeLeft = maxTime;

                    levelText.text = currentLevel.ToString();

                    showbuttonSeven.SetActive(true);
                }

                break;
            case 8:
                if (currentLevel == 8 && endlessScore >= 80)
                {
                    maxTime -= 1;
                    timeLeft = maxTime;

                    currentLevel = 9;

                    levelText.text = currentLevel.ToString();

                    showbuttonEight.SetActive(true);
                }

                break;
            case 9:
                if (currentLevel == 9 && endlessScore >= 90)
                {
                    maxTime -= 1;
                    timeLeft = maxTime;

                    currentLevel = 10;

                    levelText.text = currentLevel.ToString();

                    showbuttonNine.SetActive(true);
                }

                break;

        }

    }

    //IEnumerator that returns data from a question set json file
    public IEnumerator LoadQuestionData(string URL)
    {

        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();





        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log("Retrieved data failed!");

        }
        else
        {
            Debug.Log("Retrieved data complete!");



            Debug.Log(www.downloadHandler.text);

            dataSet1 = www.downloadHandler.text;

        }
    }

    //IEnumerator that returns data from a incorrect answers json file
   public IEnumerator LoadRandomAnswerData(string URL)
    {

        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();




        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log("Retrieved data failed!");

        }
        else
        {
            Debug.Log("Retrieved data complete!");



            Debug.Log(www.downloadHandler.text);

            dataSet2 = www.downloadHandler.text;

        }
    }
}
