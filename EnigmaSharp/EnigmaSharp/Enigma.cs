using System.Diagnostics;

namespace EnigmaSharp
{
    /// <summary>
    /// This class provides the enigma machine which can be directly
    /// run.
    /// </summary>
    public class Enigma
    {
        private Keyboard keyboard;
        private Plugboard plugboard;
        private Rotor rotor1;
        private Rotor rotor2;
        private Rotor rotor3;
        private Reflector reflector;

        /// <summary>
        /// This method is the class constructor.
        /// </summary>
        /// <param name="_keyboard">An instance of the keyboard class.</param>
        /// <param name="_plugboard">An instance of the plugboard class.</param>
        /// <param name="_rotor1">First rotor instance.</param>
        /// <param name="_rotor2">Second rotor instance</param>
        /// <param name="_rotor3">Third rotor instance.</param>
        /// <param name="_reflector">An instance of the reflector class.</param>
        public Enigma(Keyboard _keyboard, Plugboard _plugboard, Rotor _rotor1, Rotor _rotor2, Rotor _rotor3, Reflector _reflector)
        {
            this.keyboard = _keyboard;
            this.plugboard = _plugboard;
            this.reflector = _reflector;
            this.rotor1 = _rotor1;
            this.rotor2 = _rotor2;
            this.rotor3 = _rotor3;
        }

        /// <summary>
        /// This method sets the starting position of the rotors.
        /// </summary>
        /// <param name="key">Starting position is provided as a string, alphabets only - in the order, R1, R2, R3 </param>
        public void setKey(string key)
        {
            this.rotor1.RotateToLetter(key[0]);
            this.rotor2.RotateToLetter(key[1]);
            this.rotor3.RotateToLetter(key[2]);
        }

        /// <summary>
        /// This method shows the values of each rotor
        /// </summary>
        public void showRotorValues()
        {
            this.rotor1.ShowValues();
            this.rotor2.ShowValues();
            this.rotor3.ShowValues();
        }

        /// <summary>
        /// This method enciphers the letter by rotating the required rotors, and
        /// then passing the letter through the various elements of the
        /// enigma machine.
        /// </summary>
        /// <param name="letter">The character which is to be enciphered</param>
        /// <returns>The enciphered character</returns>
        public char encrypt(char letter)
        {
            // Rotating the rotors
            if (this.rotor2.LeftLetters[0] == this.rotor2.TurnoverNotch && this.rotor3.LeftLetters[0] == this.rotor3.TurnoverNotch)
            {
                this.rotor1.Rotate(1, true);
                this.rotor2.Rotate(1, true);
                this.rotor3.Rotate(1, true);
            }
            else if (this.rotor2.LeftLetters[0] == this.rotor2.TurnoverNotch)
            {
                this.rotor1.Rotate(1, true);
                this.rotor2.Rotate(1, true);
                this.rotor3.Rotate(1, true);
            }
            else if (this.rotor3.LeftLetters[0] == this.rotor3.TurnoverNotch)
            {
                this.rotor2.Rotate(1, true);
                this.rotor3.Rotate(1, true);
            }
            else
            {
                this.rotor3.Rotate(1, true);
            }

            int signal;
            signal = this.keyboard.GetSignal(letter);
            signal = this.plugboard.Forwards(signal);
            signal = this.rotor3.Forwards(signal);
            signal = this.rotor2.Forwards(signal);
            signal = this.rotor1.Forwards(signal);
            signal = this.reflector.Reflect(signal);
            signal = this.rotor1.Backwards(signal);
            signal = this.rotor2.Backwards(signal);
            signal = this.rotor3.Backwards(signal);
            signal = this.plugboard.Backwards(signal);
            letter = this.keyboard.GetLetter(signal);
            return letter;
        }
    }
}