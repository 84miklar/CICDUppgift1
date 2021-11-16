namespace CICDUppgift1.Views
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Helpers;
    using System;

    /// <summary>
    /// Class that handles the view for Login Menu
    /// </summary>
    internal class LoginMenuView
    {
        private readonly InputCheck check = new();
        public bool keepGoing = true;

        /// <summary>
        /// Outputs the Login Menu and handles input choice.
        /// </summary>
        public void LoginView()
        {
            Console.Clear();
            while (keepGoing)
            {
                Console.WriteLine("Welcome to the your co-worker space");
                Console.WriteLine("1. Enter your details \n2. Exit");
                var userChoice = check.TryParse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Login();
                        break;

                    case 2:
                        return;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the input and output for logging in. If success sends user to Main Menu.
        /// </summary>
        private void Login()
        {
            LoginMenuController controller = new();
            MainMenuView mainMenuPointer = new();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Clear();
            var loggedInUser = controller.Login(username, password);
            if (loggedInUser == null)
            {
                Console.WriteLine("Username or password is not in our database. Try again.");
            }
            else
            {
                keepGoing = false;
                mainMenuPointer.MainMenu(loggedInUser);
            }
        }
    }
}