using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using System.Globalization;

public class LanguageMenuController : MonoBehaviour
{

    [SerializeField]  private Canvas languageMenu; //Variable for the langauge canvas

    // Start is called before the first frame update
    void Start()
    {
        languageMenu.enabled = false; // Sets the language menu to not appear/disables it

      
    }


    //OpenMenu function opens the langauge menu
    public void OpenMenu()
    {
        languageMenu.enabled = true; // Sets the language menu to appear/enables it
    }

    //CloseMenu function closes the language menu
    public void CloseMenu()
    {
        languageMenu.enabled = false; // Sets the language menu to not appear/disables it
    }

   
}
