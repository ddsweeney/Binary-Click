
[System.Serializable]
//Hexadecimal data class
public class Hexadecimal
{
    public string hexValue;

}

[System.Serializable]
//Hexadecimal array class which acts as a wrapper to convert data from json file to unity
public class HexadecimalArray
{
    public Hexadecimal[] Hexadecimal;
}

