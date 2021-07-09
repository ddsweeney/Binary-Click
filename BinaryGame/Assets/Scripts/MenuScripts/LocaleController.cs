using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleController : MonoBehaviour
{

    //ChangeEnglish function changes the language of text to english
    public void ChangeEnglish()
    {

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("en");


    }

    
    //ChangeWelsh function changes the language of text to welsh
    public void ChangeWelsh()
    {

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("cy");


    }
}

