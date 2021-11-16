namespace CICDUppgift1.Helpers
{
    using System;

    public class InputCheck
    {
        /// <summary>
        ///  Method that takes input from user and tries to parse it to a number.
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <returns>parsed number. If input is not a number, or <1, value is 0.</returns>
        public int TryParse(string number)
        {
            var parseTest = int.TryParse(number, out int parsedValue);
            if (parseTest && parsedValue <= 0)
            {
                Console.WriteLine("Invalid input. Input must be an integer more than 0.");
                return -1;
            }
            return parsedValue;
        }

        /// <summary>
        /// Checks if the input string contains both letters and digits.
        /// </summary>
        /// <param name="input">The string to test</param>
        /// <returns>True if input string contains both letters and digits.</returns>
        public bool StringCheck(string input)
        {
            var letterOk = false;
            var digitOk = false;
            var noWhiteSpace = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digitOk = true;
                }
                else if (Char.IsLetter(input[i]))
                {
                    letterOk = true;
                }
                else if (Char.IsWhiteSpace(input[i]))
                {
                    noWhiteSpace = false;
                }
            }
            return digitOk && letterOk && noWhiteSpace;
        }
    }
}