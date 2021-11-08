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
        private LoginMenuController controller = new();
        private InputCheck check = new();

        public void LoginView()
        {
            Console.WriteLine("Welcome to the your co-worker space");
            Console.WriteLine("1. Enter your details \n2. Exit");
            var userChoice = check.TryParse();
            switch (userChoice)
            {
                case 1:
                    Login();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private void Login()
        {
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
            }
        }
    }
}