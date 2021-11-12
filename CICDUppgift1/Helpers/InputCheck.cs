namespace CICDUppgift1.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InputCheck
    {
        /// <summary>
        /// Method that takes input from user and tries to parse it to a number.
        /// </summary>
        /// <returns>parsed number. If input is not a number, or <1, value is 0.</returns>
        public int TryParse(string number)
        {
            int.TryParse(number, out int parsedValue);
            if (parsedValue <= 0)
            {
                Console.WriteLine("Invalid input. Input must be an integer more than 0.");
                return -1;
            }
            return parsedValue;
        }

        public bool StringCheck(string input)
        {
            bool letterOk = false;
            bool digitOk = false;
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
            }
            return digitOk && letterOk;
        }
    }
}