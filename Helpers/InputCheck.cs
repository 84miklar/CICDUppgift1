namespace CICDUppgift1.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class InputCheck
    {
        /// <summary>
        /// Method that takes input from user and tries to parse it to a number.
        /// </summary>
        /// <returns>parsed number. If input is not a number, or <1, value is 0.</returns>
        public int TryParse()
        {
            int.TryParse(Console.ReadLine(), out int parsedValue);
            if (parsedValue <= 0)
            {
                Console.WriteLine("Invalid input. Input must be an integer more than 0.");
                return -1;
            }
            return parsedValue;
        }

        /// <summary>
        /// Sends a message to user to press enter button.
        /// </summary>
        public static void PressEnter()
        {
            Console.WriteLine("\nPlease press enter to continue.");
            Console.ReadKey();
        }
    }
}