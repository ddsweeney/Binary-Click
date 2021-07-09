
[System.Serializable]
//Binary data class
public class Binary 
{
    public string binaryAnswer;

}

[System.Serializable]
//Binary array class which acts as a wrapper to convert data from json file to unity
public class BinaryArray
{
    public Binary[] Binary;

}
