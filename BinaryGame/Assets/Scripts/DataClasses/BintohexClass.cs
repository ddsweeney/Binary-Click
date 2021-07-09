
[System.Serializable]
//Binary to hexadecimal data class
public class BintohexClass
{
    public string binaryAnswer;
    public string hexValue;

}

[System.Serializable]
//Binary to hexadecimal array class which acts as a wrapper to convert data from json file to unity
public class BintohexArray
{
    public BintohexClass[] BintohexClass;
}




