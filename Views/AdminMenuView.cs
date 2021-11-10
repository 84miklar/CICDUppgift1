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

    internal class AdminMenuView
    {
        private InputCheck check = new();

        private AdminMenuController adminController = new();

        public void AdminMenuSwitch(User loggedInUser)
        {
            MainMenuView mainPointer = new();
            while (true)
            {
                Console.WriteLine("1. Show salary \n2.Show title \n3. Handle users \n 4. Exit");
                var userChoice = check.TryParse();
                switch (userChoice)
                {
                    case 1:
                        mainPointer.ShowSalary(loggedInUser);
                        break;

                    case 2:
                        mainPointer.ShowTitle(loggedInUser);
                        break;

                    case 3:
                        HandleUsers();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void HandleUsers()
        {
            Console.WriteLine("1. Add new user \n 2. See all users \n 3. Delete Users \n 4. Exit");
            var userChoice = check.TryParse();
            switch (userChoice)
            {
                case 1:
                    AddNewUser();
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:
                    return;

                default:
                    break;
            }
        }

        private void AddNewUser()
        {
            Console.WriteLine("Both username and password have to contain both letters and numbers");
            Console.WriteLine("Fill in username: ");
            var username = Console.ReadLine();
            if (!check.StringCheck(username))
            {
                AddNewUser();
            }
            Console.WriteLine("Fill in password: ");
            var password = Console.ReadLine();
            if (!check.StringCheck(password))
            {
                AddNewUser();
            }
            Console.WriteLine("Is this person admin? y/n");
            bool isAdmin = false;
            var adminQuestion = Console.ReadLine().ToLower();
            if (adminQuestion == "y")
            {
                isAdmin = true;
            }
            Console.WriteLine("Fill in salary: ");
            var salary = check.TryParse();

            Console.WriteLine("Fill in the title of person: ");
            var title = Console.ReadLine();

            adminController.AddUser(username, password, salary, title, isAdmin);
        }
    }
}