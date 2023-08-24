namespace EnigmaSharp
{
    public class Keyboard
    {
        public int GetSignal(char letter)
        {
            int signal = Array.IndexOf(Globals.ALPHABETS, letter);
            return signal;
        }

        public char GetLetter(int signal)
        {
            char letter = Globals.ALPHABETS[signal];
            return letter;
        }
    }
}
