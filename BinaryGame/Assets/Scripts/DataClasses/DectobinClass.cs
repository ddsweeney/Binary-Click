
[System.Serializable]
//Decimal to binary data class
public class DectobinClass
{
    public string decimalValue;
    public string binaryAnswer;

}

[System.Serializable]
//Decimal to binary array class which acts as a wrapper to convert data from json file to unity
public class DectobinArray
{
    public DectobinClass[] DectobinClass;
}



