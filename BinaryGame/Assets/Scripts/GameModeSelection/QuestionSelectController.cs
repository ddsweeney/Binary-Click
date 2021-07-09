using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSelectController : MonoBehaviour
{

    //Declares a series of static bool varaibles for each set of questions
    public static bool binToDec = false;
    public static bool decToBin = false;
    public static bool binToHex = false;
    public static bool hexToBin = false;
    public static bool decToHex = false;
    public static bool hexToDec = false;

    //Function that sets binToDec to true and the other bool to false
    public void BinToDec()
    {

        binToDec = true;
        decToBin = false;
        binToHex = false;
        hexToBin = false;
        decToHex = false;
        hexToDec = false;
       
    }

    //Function that sets decToBin to true and the other bool to false
    public void DecToBin()
    {

        decToBin = true;
        binToDec = false;
        binToHex = false;
        hexToBin = false;
        decToHex = false;
        hexToDec = false;

        
    }

    //Function that sets binToHex to true and the other bool to false
    public void BinToHex()
    {

        binToHex = true;
        binToDec = false;
        decToBin = false;
        hexToBin = false;
        decToHex = false;
        hexToDec = false;
    
    }

    //Function that sets hexToBin to true and the other bool to false
    public void HexToBin()
    {

        hexToBin = true;
        binToDec = false;
        decToBin = false;
        binToHex = false;
        decToHex = false;
        hexToDec = false;
    }

    //Function that sets decToHex to true and the other bool to false
    public void DecToHex()
    {

        decToHex = true;
        binToDec = false;
        decToBin = false;
        binToHex = false;
        hexToBin = false;
        hexToDec = false;
    }

    //Function that sets hexToDec to true and the other bool to false
    public void HexToDec()
    {

        hexToDec = true;
        binToDec = false;
        decToBin = false;
        binToHex = false;
        hexToBin = false;
        decToHex = false;

    }
}
