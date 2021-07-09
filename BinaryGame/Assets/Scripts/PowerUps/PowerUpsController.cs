using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    public GameController gameController;

    //Series of game objects for each power up
    [SerializeField] private GameObject freezeObject;
    [SerializeField] private GameObject multiplierObject;
    [SerializeField] private GameObject bombObject;
    [SerializeField] private GameObject healthUpObject;
    [SerializeField] private GameObject healthDownObject;
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private GameObject gameOverObject;

    //Integer varaibles used for switch statement
    private int currentGood = 0; 
    private int currentBad = 0;

    //Variables for the spawn position game objects
    [SerializeField] private GameObject[] positions;
    private static List<GameObject> positionLeft;

    //Variables for the power up game objects
    [SerializeField] private GameObject[] powerUps;
    private static List<GameObject> unChangedpowerUps;
    private GameObject currentpowerUps;


    //Test Variables
    public int numberOfPowerUpGameObjects;
    public int numberOfSpawnPosGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        //Test Variables
        numberOfPowerUpGameObjects = powerUps.Length;
        numberOfSpawnPosGameObjects = positions.Length;


        //Sets all power ups to be not active and not appear
        freezeObject.SetActive(false);
        multiplierObject.SetActive(false);
        bombObject.SetActive(false);
        healthUpObject.SetActive(false);
        healthDownObject.SetActive(false);
        shieldObject.SetActive(false);
        gameOverObject.SetActive(false);



    }

    //PowerUpPos function is the same as the function ObjectPos from the script ObjectPositionController but for the power ups
    public void PowerUpPos()
    {
        positionLeft = positions.ToList();
        unChangedpowerUps = powerUps.ToList();

        

        for (int i = 0; i < unChangedpowerUps.Count; i++)
        {

            int randomObject = Random.Range(i, unChangedpowerUps.Count);

            currentpowerUps = unChangedpowerUps[i];

            unChangedpowerUps[i] = unChangedpowerUps[randomObject];

            unChangedpowerUps[randomObject] = currentpowerUps;


        }

        for (int j = 0; j < positionLeft.Count; j++)
        {
            unChangedpowerUps[j].transform.position = positionLeft[j].transform.position;

        }

    }


    //ChangeGoodPowerUp function is used to spawn the good powerups
    public void ChangeGoodPowerUp()
        {

        int random = Random.Range(0, 10);


        currentGood = random;

        //Switch statement to make only one good power up to spawn at once
            switch (currentGood)
            {

                case 0:


                   
                        freezeObject.SetActive(true);
                        multiplierObject.SetActive(false);
                        bombObject.SetActive(false);
                        healthUpObject.SetActive(false);
                        shieldObject.SetActive(false);

                    break;
                case 1:

                    multiplierObject.SetActive(true);

                    freezeObject.SetActive(false);
                    bombObject.SetActive(false);
                    healthUpObject.SetActive(false);
                    shieldObject.SetActive(false);

     
                    break;
                case 2:

                    bombObject.SetActive(true);

                    freezeObject.SetActive(false);
                    multiplierObject.SetActive(false);
                    healthUpObject.SetActive(false);
                    shieldObject.SetActive(false);
            

                    break;
                case 3:


                    healthUpObject.SetActive(true);

                    freezeObject.SetActive(false);
                    bombObject.SetActive(false);
                    multiplierObject.SetActive(false);
                    shieldObject.SetActive(false);


                    break;

                case 4:


                    shieldObject.SetActive(true);

                    freezeObject.SetActive(false);
                    bombObject.SetActive(false);
                    healthUpObject.SetActive(false);
                    multiplierObject.SetActive(false);
        
                    break;
            
        }
    }


    //ChangeBadPowerUp function is used to spawn the bad powers
    public void ChangeBadPowerUp()
    {
        int random = Random.Range(0, 8);

        currentBad = random;

        //Switch statement to make only one bad power to spawn at once
        switch (currentBad)
            {

                case 0:

                    healthDownObject.SetActive(true);
                    gameOverObject.SetActive(false);

                  
                    break;
                case 1:

                    gameOverObject.SetActive(true);

                    healthDownObject.SetActive(false);

                    break;
            
        }


        
    }

 

}
