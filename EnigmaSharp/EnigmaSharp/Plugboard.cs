namespace EnigmaSharp
{
    public class Plugboard
    {
        private char[] LeftLetters;
        private char[] RightLetters;

        public Plugboard(string[] pairs)
        {
            this.LeftLetters = (char[])Globals.ALPHABETS.Clone();
            this.RightLetters = Globals.ALPHABETS;
           foreach(string pair in pairs)
            {
                char Swap1 = pair[0];
                char Swap2 = pair[1];

                int IndexToSwapFrom1 = Array.IndexOf(LeftLetters, Swap1);
                int IndexToSwapFrom2 = Array.IndexOf(LeftLetters, Swap2);

                LeftLetters[IndexToSwapFrom1] = Swap2;
                LeftLetters[IndexToSwapFrom2] = Swap1;
            }    
        }

        public int Forwards(int signal)
        {
            Console.WriteLine(signal);
            char letter = RightLetters[signal];
            return Array.IndexOf(LeftLetters, letter);
        }

        public int Backwards(int signal)
        {
            char letter = LeftLetters[signal];
            return Array.IndexOf(RightLetters, letter);
        }
    }
}
