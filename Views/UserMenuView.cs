namespace CICDUppgift1.Views
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UserMenuView
    {
        private InputCheck check = new();

        public void UserMenuSwitch(User loggedInUser)
        {
            MainMenuView mainPointer = new();
            LoginMenuView loginPointer = new();
            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("1. Show salary \n2.Show title \n3. Delete yourself \n 4. Exit");
                var userChoice = check.TryParse();
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

        public bool DeleteUser(User loggedInUser)
        {
            UserMenuController userController = new();
            Console.WriteLine("Please enter your username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            var password = Console.ReadLine();
            if (username == loggedInUser.Name && password == loggedInUser.Password)
            {
                return userController.DeleteUser(loggedInUser);
            }
            else
            {
                Console.WriteLine("Input does not match any valid user information");
                return true;
            }
        }
    }
}