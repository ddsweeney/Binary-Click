
[System.Serializable]
//Hexadecimal to decimal data class
public class HextodecClass
{

    public string hexValue;
    public string decimalValue;


}

[System.Serializable]
//Hexadecimal to decimal array class which acts as a wrapper to convert data from json file to unity
public class HextodecArray
{
    public HextodecClass[] HextodecClass;
}


