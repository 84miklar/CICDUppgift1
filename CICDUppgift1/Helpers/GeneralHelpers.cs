using System;
using System.Threading;

namespace CICDUppgift1.Helpers
{
    /// <summary>
    /// Contains general helpers for the whole project.
    /// </summary>
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

        /// <summary>
        /// Outputs success message when deleting an account.
        /// </summary>
        public static void SuccessMessage()
        {
            Console.WriteLine("\nYou have succesfully deleted the account");
            Thread.Sleep(750);
        }

        /// <summary>
        /// Outputs failure message when deleting an account was not successful.
        /// </summary>
        public static void FailureMessage()
        {
            Console.WriteLine("Something went wrong with deleteing your account.");
        }
    }
}