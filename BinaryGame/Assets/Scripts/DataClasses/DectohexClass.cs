
[System.Serializable]
//Decimal to hexadecimal data class
public class DectohexClass
{
        public string decimalValue;
        public string hexValue;

}

[System.Serializable]
//Decimal to hexadecimal array class which acts as a wrapper to convert data from json file to unity
public class DectohexArray
{
    public DectohexClass[] DectohexClass;
}



