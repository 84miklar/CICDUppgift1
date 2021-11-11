using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Helpers
{
    public static class GeneralHelpers
    {
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
