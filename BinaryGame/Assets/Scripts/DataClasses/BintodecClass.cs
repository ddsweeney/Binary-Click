
[System.Serializable]
//Binary to decimal data class
public class BintodecClass
{
    public string binaryAnswer;
    public string decimalValue;

}


[System.Serializable]
//Binary to decimal array class which acts as a wrapper to convert data from json file to unity
public class BintodecArray
{
    public BintodecClass[] BintodecClass;
}




