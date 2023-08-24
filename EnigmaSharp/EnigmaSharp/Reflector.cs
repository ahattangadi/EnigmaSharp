namespace EnigmaSharp
{
    public class Reflector
    {
        private char[] LeftLetters;
        private char[] RightLetters;

        public Reflector(string wiring)
        {
            this.LeftLetters = Globals.ALPHABETS;
            this.RightLetters = wiring.ToCharArray();
        }
        
        public int Reflect(int signal)
        {
            char letter = RightLetters[signal];
            return Array.IndexOf(LeftLetters, letter);
        }

        
    }
}