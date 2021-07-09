using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public void ReturnMainMenu()
    {

        SceneManager.LoadScene("MainMenuScene"); //Loads the main menu
    }

    public void Replay()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Loads the current scene
    }

}
