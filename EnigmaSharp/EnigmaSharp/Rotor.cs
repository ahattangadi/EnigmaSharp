using System.Globalization;

namespace EnigmaSharp
{
    /// <summary>
    /// This class is an implementation of the enigma machine's rotor.
    /// </summary>
    public class Rotor
    {
        public char[] LeftLetters;
        private char[] RightLetters;
        public char TurnoverNotch;

        /// <summary>
        /// This method is the class constructor.
        /// </summary>
        /// <param name="wiring">The wiring configuration provided as a 26 letter string.</param>
        /// <param name="turnoverNotch">The turnover notch provided as a character.</param>
        public Rotor(string wiring, char turnoverNotch)
        {
            this.LeftLetters = Globals.ALPHABETS;
            this.RightLetters = wiring.ToCharArray();
            this.TurnoverNotch = turnoverNotch;
        }
        /// <summary>
        /// This method enciphers the letter in the forward direction (1st pass).
        /// </summary>
        /// <param name="signal">The integer value of the letter to be enciphered</param>
        /// <returns>The integer value of the enciphered letter.</returns>
        public int Forwards(int signal)
        {
            char letter = RightLetters[signal];
            return Array.IndexOf(LeftLetters, letter);
        }

        /// <summary>
        /// This method enciphers the letter in the backward direction (2nd pass).
        /// </summary>
        /// <param name="signal">The integer value of the letter to be enciphered</param>
        /// <returns>The integer value of the enciphered letter.</returns>
        public int Backwards(int signal)
        {
            char letter = LeftLetters[signal];
            return Array.IndexOf(RightLetters, letter);
        }

        /// <summary>
        /// This method shows the value of the rotor positions.
        /// </summary>
        public void ShowValues()
        {
            //Console.WriteLine("LEFT: " + this.LeftLetters.ToString() + "\n" + "RIGHT:" + this.RightLetters.ToString());
            foreach (char letter in this.LeftLetters)
            {
                Console.Write(letter);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Turnover: " + this.TurnoverNotch);
            Console.WriteLine("=============");
            
        }
        
        /// <summary>
        /// This method shifts position of the rotor in the direction so desired.
        /// </summary>
        /// <param name="NumberOfShifts">Integer value of number of shifts so desired.</param>
        /// <param name="ShiftLeft">A boolean value, representing if the rotor should be moved to the left (true=left, false=right) </param>
        public void Rotate(int NumberOfShifts, bool ShiftLeft)
        {
            if (ShiftLeft)
            {
                this.LeftLetters = Helper.ShiftLeft(LeftLetters, NumberOfShifts);
                this.RightLetters = Helper.ShiftLeft(RightLetters, NumberOfShifts);
            }
            else
            {
                this.LeftLetters = Helper.ShiftRight(LeftLetters, NumberOfShifts);
                this.RightLetters = Helper.ShiftRight(RightLetters, NumberOfShifts);
            }

        }

        /// <summary>
        /// This method rotates the rotor to a specific letter.
        /// </summary>
        /// <param name="letter">The character to which the rotor should be rotated</param>
        public void RotateToLetter(char letter)
        {
            int numberOfShifts = Array.IndexOf(this.LeftLetters, letter);
            this.LeftLetters = Helper.ShiftLeft(LeftLetters, numberOfShifts);
            this.RightLetters = Helper.ShiftLeft(RightLetters, numberOfShifts);
        }


    }
}