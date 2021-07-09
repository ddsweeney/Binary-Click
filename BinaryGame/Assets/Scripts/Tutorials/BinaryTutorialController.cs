using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinaryTutorialController : MonoBehaviour
{

    //Declares varibles
    private int currentDecimal = 0;


    [SerializeField] private TMP_Text currentDecimalText;


    //Bool variables for if each button is active or not

    bool active128 = false;
    bool active64 = false;
    bool active32 = false;
    bool active16 = false;
    bool active8 = false;
    bool active4 = false;
    bool active2 = false;
    bool active1 = false;

    //Buttons used to display each binary value
    [SerializeField] private TextMeshProUGUI Btn128;
    [SerializeField] private TextMeshProUGUI Btn64;
    [SerializeField] private TextMeshProUGUI Btn32;
    [SerializeField] private TextMeshProUGUI Btn16;
    [SerializeField] private TextMeshProUGUI Btn8;
    [SerializeField] private TextMeshProUGUI Btn4;
    [SerializeField] private TextMeshProUGUI Btn2;
    [SerializeField] private TextMeshProUGUI Btn1;


    // Update is called once per frame
    void Update()
    {
        currentDecimalText.text = currentDecimal.ToString();
    }

    //Series of functions which toggle buttons to display 0 or 1 and adds the binary value, each button represents together
    public void Change128()
    {
        if (!active128)
        {
            currentDecimal += 128;
            active128 = true;

            Btn128.text = "1";

        }
        else if (active128)
        {
            currentDecimal -= 128;
            active128 = false;
            Btn128.text = "0";

        }

    }
    public void Change64()
    {
        if (!active64)
        {
            currentDecimal += 64;
            active64 = true;
            Btn64.text = "1";

        }
        else if (active64)
        {
            currentDecimal -= 64;
            active64 = false;
            Btn64.text = "0";

        }
    }
    public void Change32()
    {
        if (!active32)
        {
            currentDecimal += 32;
            active32 = true;
            Btn32.text = "1";

        }
        else if (active32)
        {
            currentDecimal -= 32;
            active32 = false;
            Btn32.text = "0";

        }
    }
    public void Change16()
    {
        if (!active16)
        {
            currentDecimal += 16;
            active16 = true;
            Btn16.text = "1";

        }
        else if (active16)
        {
            currentDecimal -= 16;
            active16 = false;
            Btn16.text = "0";

        }
    }
    public void Change8()
    {
        if (!active8)
        {
            currentDecimal += 8;
            active8 = true;
            Btn8.text = "1";

        }
        else if (active8)
        {
            currentDecimal -= 8;
            active8 = false;
            Btn8.text = "0";


        }
    }
    public void Change4()
    {
        if (!active4)
        {
            currentDecimal += 4;
            active4 = true;
            Btn4.text = "1";

        }
        else if (active4)
        {
            currentDecimal -= 4;
            active4 = false;
            Btn4.text = "0";

        }
    }
    public void Change2()
    {
        if (!active2)
        {
            currentDecimal += 2;
            active2 = true;
            Btn2.text = "1";

        }
        else if (active2)
        {
            currentDecimal -= 2;
            active2 = false;
            Btn2.text = "0";

        }
    }
    public void Change1()
    {
        if (!active1)
        {
            currentDecimal += 1;
            active1 = true;
            Btn1.text = "1";

        }
        else if (active1)
        {
            currentDecimal -= 1;
            active1 = false;
            Btn1.text = "0";

        }
    }
}
