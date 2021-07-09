using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPositionController : MonoBehaviour
{
    //Connects to other scipts to use the variables
    public GameController gameController;
    public PowerUpsController powerUpsController;
   
    //Variables for the spawn position game objects
    [SerializeField] private GameObject[] positions;
    private static List<GameObject> positionLeft;

    //Variables for the answer game objects
    [SerializeField] private GameObject[] gameObjects;
    private static List<GameObject> unChangedGameObject;
    private GameObject currentObject;

    private int currentState = 0;

    private Rigidbody2D rb; 

    //Varaiables for how fast it can move left and right
    [SerializeField] private int rightVelocity = 100;
    [SerializeField] private int leftVelocity = -100;


    //Test Variables
    public int numberOfAnswerGameObjects;
    public int numberOfSpawnPosGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        //Test Variables
        numberOfAnswerGameObjects = gameObjects.Length;
        numberOfSpawnPosGameObjects = positions.Length;

        ObjectPos(); //Calls the function ObjectPos
    }

    //ObjectPos function changes the position of the answer game object to match the spawn position game objects
    public void ObjectPos()
    {

        positionLeft = positions.ToList(); //Fills the list with objects from the array
        unChangedGameObject = gameObjects.ToList();//Fills the list with objects from the array

        for (int i = 0; i < unChangedGameObject.Count; i++)
        {

            int randomObject = Random.Range(i, unChangedGameObject.Count);

            currentObject = unChangedGameObject[i];


            unChangedGameObject[i] = unChangedGameObject[randomObject];

            unChangedGameObject[randomObject] = currentObject;

            //if statement for when the current level is 3 or above
            if (gameController.currentLevel >= 3)
            {
                rb = currentObject.GetComponent<Rigidbody2D>(); //Gets the current objects rigidbody component
                ChangeLookOfAnswer(currentObject); // Calls the ChangeLookOfAnswer with the current object

            }

        }
        //For loop statement which loops for the number of objects in the positionLeft list
        for (int j = 0; j < positionLeft.Count; j++)
        {
            unChangedGameObject[j].transform.position = positionLeft[j].transform.position; // Sets the current object postion in the unChangedGameObject to the current object in the positionLeft list

        }


        


    }



    //ChangeLookOfAnswer function which is called to change the behaviour of the answer game object
     void ChangeLookOfAnswer(GameObject gameObject)
     {

        rb.bodyType = RigidbodyType2D.Static;
        transform.localScale = new Vector2(1f, 1f);
        rb.velocity = new Vector2(0, 0);

        int random = Random.Range(0, 6);

        currentState = random; // Changes the currentState to equal the random integer
     
        //Switch Statement used to change the behaviour of the game object 
        switch (currentState)
        {

            case 0:

                gameObject.transform.position = gameObject.transform.position;
                gameObject.transform.localScale = new Vector2(1f, 1f); 


                break;
            case 1:



                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(rightVelocity, 0); //Moves right
                Debug.Log(1);


                break;
            case 2:


                rb.bodyType = RigidbodyType2D.Kinematic;

                rb.velocity = new Vector2(leftVelocity, 0); //Move left



                break;
            case 3:


                rb.bodyType = RigidbodyType2D.Dynamic; // Gets affected by gravity
                gameObject.transform.localScale = new Vector2(1f, 1f);




                break;
            case 4:


                gameObject.transform.localScale = new Vector2(1.5f, 1.5f); // Size is increased
                rb.bodyType = RigidbodyType2D.Static;





                break;

            default:
                rb.bodyType = RigidbodyType2D.Static;
                transform.localScale = new Vector2(1f, 1f);
                rb.velocity = new Vector2(0, 0);

                break;

        }
    }








}
