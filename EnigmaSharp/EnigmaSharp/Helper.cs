namespace EnigmaSharp;

public class Helper
{
    // Write a function to shift an array to the right by x places. If it moves 1 place, then [A,B,C,D] becomed [D,A,B,C]. Take the number of shifts as a parameter.
    public static char[] ShiftRight(char[] array, int shift)
    {
        char[] newArray = new char[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int newIndex = i + shift;
            if (newIndex >= array.Length)
            {
                newIndex = newIndex - array.Length;
            }
            newArray[newIndex] = array[i];
        }
        return newArray;
    }
    // Make a similar function which will rotate to left by x places as parameter
    public static char[] ShiftLeft(char[] array, int shift)
    {
        char[] newArray = new char[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int newIndex = i - shift;
            if (newIndex < 0)
            {
                newIndex = newIndex + array.Length;
            }
            newArray[newIndex] = array[i];
        }
        return newArray;
    }
    
}