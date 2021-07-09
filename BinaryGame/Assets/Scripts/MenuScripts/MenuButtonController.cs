using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    //Declares variable 

    [SerializeField] private Button button; 
    [SerializeField] private string sceneName; 

    // Start is called before the first frame update
    void Start()
    {

        button = GetComponent<Button>(); // Initialises the button

        button.onClick.AddListener(LoadScene); //Sets the onClick function of the button to call LoadScene function


    }

  
    //LoadScene fucntions loads scenes
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName); //Loads the scene written in the inspector
    }


  
}
