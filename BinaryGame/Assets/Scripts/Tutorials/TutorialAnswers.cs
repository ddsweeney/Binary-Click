using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnswers : MonoBehaviour
{

    public MainGameTutorialController tutorialController;
    //OnMouseFunction is called when player clicked on collider
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("IncorrectValue") == true)
        {
            tutorialController.InCorrectAnswer();
            Debug.Log("incorrect");
        }
        if (gameObject.CompareTag("CorrectValue") == true)
        {
            tutorialController.CorrectAnswer();
            Debug.Log("correct");

        }

    }
}
