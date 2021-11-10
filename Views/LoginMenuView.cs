namespace CICDUppgift1.Views
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class LoginMenuView
    {
        private InputCheck check = new();
        public bool keepGoing = true;

        public void LoginView()
        {
            while (keepGoing)
            {
                Console.WriteLine("Welcome to the your co-worker space");
                Console.WriteLine("1. Enter your details \n2. Exit");
                var userChoice = check.TryParse();
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

        private void Login()
        {
            LoginMenuController controller = new();
            MainMenuView mainMenuPointer = new();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
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