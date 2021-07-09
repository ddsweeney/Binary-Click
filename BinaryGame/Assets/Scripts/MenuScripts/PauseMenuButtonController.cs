using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButtonController : MonoBehaviour
{

    //Declares variables

    [SerializeField] public Canvas pauseMenuCanvas; //Pause menu canvas
    [SerializeField] private Button button; // pause button
    
    public static bool isPaused = false; // boolean value to say if it is paused or not

    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; 
        pauseMenuCanvas.enabled = false; //Sets the canvas to be disabled/ not appear
        button = GetComponent<Button>(); // Initialises the button

    }

    // Update is called once per frame
    void Update()
    {
        // if statement to say if the game over canvas isnt active or start canvas is active, the pause menu can be enabled
        if (gameController.gameOverCanvas.enabled == false && gameController.StartBtnCanvas.enabled == false)
        {
            button.onClick.AddListener(gameStatus);

            if (Input.GetKeyDown("escape")) 
            {
                gameStatus();
            }
        }
    }

    //gameStatus function toggles between pausing the game
   public void gameStatus()
    {
        if (!isPaused)
        {
            gamePaused();
        }
        else if (isPaused)
        {
            gameUnpaused();
        }
    }

    //gamePaused function pauses the game and enables the canvas to appear
    void gamePaused()
    {

        isPaused = true;
        Time.timeScale = 0;
        pauseMenuCanvas.enabled = true;
    }

    //gameUnpaused function unpauses the game and disables the canvas so it disappears
    void gameUnpaused()
    {
        isPaused = false;
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;

    }

}
