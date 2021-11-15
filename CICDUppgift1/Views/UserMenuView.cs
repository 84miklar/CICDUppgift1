namespace CICDUppgift1.Views
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// Class that handles the view for User Menu
    /// </summary>
    internal class UserMenuView
    {
        private InputCheck check = new();
        /// <summary>
        /// Outputs the User Menu and handles input choice
        /// </summary>
        /// <param name="loggedInUser">The User object used when logging in</param>
        public void UserMenuSwitch(User loggedInUser)
        {
            MainMenuView mainPointer = new();
            LoginMenuView loginPointer = new();
            var keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine("1. Show salary \n2. Show title \n3. Delete yourself \n4. Exit");
                var userChoice = check.TryParse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        mainPointer.ShowSalary(loggedInUser);
                        continue;

                    case 2:
                        mainPointer.ShowTitle(loggedInUser);
                        continue;

                    case 3:
                        if (!(keepGoing = DeleteUser(loggedInUser))) loginPointer.LoginView();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Method for deleting the logged in User object
        /// </summary>
        /// <param name="loggedInUser">The User object used when logging in</param>
        /// <returns> True if deleteing has failed. This to control the keepGoing bool in while loop in UserMenuView </returns>
        public bool DeleteUser(User loggedInUser)
        {
            UserMenuController userController = new();
            Console.WriteLine("\nPlease enter your username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            var password = Console.ReadLine();
            if (username == loggedInUser.Name && password == loggedInUser.Password)
            {
                return userController.DeleteUser(loggedInUser);
            }
            else
            {
                Console.WriteLine("Input does not match your user information");
                Thread.Sleep(750);
                return true;
            }
        }
    }
}