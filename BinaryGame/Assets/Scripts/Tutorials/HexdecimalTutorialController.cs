using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexdecimalTutorialController : MonoBehaviour
{

    //Declares variables


    private int currentHex1 = 0;
    private int currentHex2 = 0;

    [SerializeField] private TMP_Text currentMaxHexText;


    //Bool variables for if each button is active or not
    bool set1active8 = false;
    bool set1active4 = false;
    bool set1active2 = false;
    bool set1active1 = false;
    bool set2active8 = false;
    bool set2active4 = false;
    bool set2active2 = false;
    bool set2active1 = false;

    //Buttons for first half of the hexadecimal value
    [SerializeField] private TextMeshProUGUI set1Btn8;
    [SerializeField] private TextMeshProUGUI set1Btn4;
    [SerializeField] private TextMeshProUGUI set1Btn2;
    [SerializeField] private TextMeshProUGUI set1Btn1;

    //Buttons for second half of the hexadecimal value
    [SerializeField] private TextMeshProUGUI set2Btn8;
    [SerializeField] private TextMeshProUGUI set2Btn4;
    [SerializeField] private TextMeshProUGUI set2Btn2;
    [SerializeField] private TextMeshProUGUI set2Btn1;

    //Text objects used to display the current value for each section of the hexadecimal
    [SerializeField] private TMP_Text hex1Text;
    [SerializeField] private TMP_Text hex2Text;
    [SerializeField] private TMP_Text hex3Text;
    [SerializeField] private TMP_Text hex4Text;
   

    // Update is called once per frame
    void Update()
    {

        //Displays the current hexadecimal value for each set
        hex1Text.text = currentHex1.ToString();
        hex2Text.text = currentHex2.ToString();
        hex3Text.text = currentHex1.ToString();
        hex4Text.text = currentHex2.ToString();
        
        CurrentHex1Value();
        CurrentHex2Value();


        //Removes the display of the hex1Text if it equals zero
        if (currentHex1 > 0)
        {
            currentMaxHexText.text = hex1Text.text + hex2Text.text;
        }
        else
        {
            currentMaxHexText.text = hex2Text.text;

        }


    }


    //Switch statement to set the currentHex1 to equal the correct hexadecimal value when the decimal value equals ten or more
    void CurrentHex1Value()
    {
        switch (currentHex1)
        {
            case 10:
                
                hex1Text.text = "A";
                hex3Text.text = "A";
               
                break;
            case 11:
               
                hex1Text.text = "B";
                hex3Text.text = "B";
               
                break;
            case 12:
                
                hex1Text.text = "C";
                hex3Text.text = "C";

               
                break;
            case 13:
               
                hex1Text.text = "D";
                hex3Text.text = "D";

                break;
            case 14:
                
                hex1Text.text = "E";
                hex3Text.text = "E";

                break;
            case 15:
                
                hex1Text.text = "F";
                hex3Text.text = "F";

                break;
        }
       
    }

    //Switch statement to set the currentHex2 to equal the correct hexadecimal value when the decimal value equals ten or more
    void CurrentHex2Value()
    {
        switch (currentHex2)
        {
            case 10:

                hex2Text.text = "A";
                hex4Text.text = "A";

                break;
            case 11:

                hex2Text.text = "B";
                hex4Text.text = "B";

                break;
            case 12:

                hex2Text.text = "C";
                hex4Text.text = "C";

                break;
            case 13:

                hex2Text.text = "D";
                hex4Text.text = "D";

                break;
            case 14:

                hex2Text.text = "E";
                hex4Text.text = "E";

                break;
            case 15:

                hex2Text.text = "F";
                hex4Text.text = "F";

                break;
        }
    }


    //Series of functions which toggle buttons to display 0 or 1 and adds the binary value, each button represents together
    public void ChangeSet1Hex8()
    {

        Debug.Log("set1hex8");
        if (!set1active8)
        {
            currentHex1 += 8;
            set1active8 = true;
            set1Btn8.text = "1";

        }
        else if (set1active8)
        {
            currentHex1 -= 8;
            set1active8 = false;
            set1Btn8.text = "0";

        }
    }

    public void ChangeSet2Hex8()
    {
        if (!set2active8)
        {
            currentHex2 += 8;
            set2active8 = true;
            set2Btn8.text = "1";

        }
        else if (set2active8)
        {
            currentHex2 -= 8;
            set2active8 = false;
            set2Btn8.text = "0";

        }
    }

    public void ChangeSet1Hex4()
    {
        if (!set1active4)
        {
            currentHex1 += 4;
            set1active4 = true;
            set1Btn4.text = "1";

        }
        else if (set1active4)
        {
            currentHex1 -= 4;
            set1active4 = false;
            set1Btn4.text = "0";

        }
    }

    public void ChangeSet2Hex4()
    {
        if (!set2active4)
        {
            currentHex2 += 4;
            set2active4 = true;
            set2Btn4.text = "1";

        }
        else if (set2active4)
        {
            currentHex2 -= 4;
            set2active4 = false;
            set2Btn4.text = "0";

        }
    }
    public void ChangeSet1Hex2()
    {
        if (!set1active2)
        {
            currentHex1 += 2;
            set1active2 = true;
            set1Btn2.text = "1";

        }
        else if (set1active2)
        {
            currentHex1 -= 2;
            set1active2 = false;
            set1Btn2.text = "0";

        }
    }
    public void ChangeSet2Hex2()
    {
        if (!set2active2)
        {
            currentHex2 += 2;
            set2active2 = true;
            set2Btn2.text = "1";

        }
        else if (set2active2)
        {
            currentHex2 -= 2;
            set2active2 = false;
            set2Btn2.text = "0";

        }
    }
    public void ChangeSet1Hex1()
    {
        if (!set1active1)
        {
            currentHex1 += 1;
            set1active1 = true;
            set1Btn1.text = "1";

        }
        else if (set1active1)
        {
            currentHex1 -= 1;
            set1active1 = false;
            set1Btn1.text = "0";

        }
    }
    public void ChangeSet2Hex1()
    {
        if (!set2active1)
        {
            currentHex2 += 1;
            set2active1 = true;
            set2Btn1.text = "1";

        }
        else if (set2active1)
        {
            currentHex2 -= 1;
            set2active1 = false;
            set2Btn1.text = "0";

        }
    }
}
