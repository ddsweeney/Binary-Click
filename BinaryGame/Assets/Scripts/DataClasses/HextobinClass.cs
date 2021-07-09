
[System.Serializable]
//Hexadecimal to binary data class
public class HextobinClass
{
    public string hexValue;
    public string binaryAnswer;

}

[System.Serializable]
//Hexadecimal to binary array class which acts as a wrapper to convert data from json file to unity
public class HextobinArray
{
    public HextobinClass[] HextobinClass;
}


