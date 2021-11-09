using CICDUppgift1.Controller;
using CICDUppgift1.Helpers;
using CICDUppgift1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Views
{
    public class MainMenuView
    {
        private InputCheck check = new();

        private AdminMenuController adminController = new();

        internal void MainMenu(User loggedInUser)
        {
            Console.Clear();

            if (!loggedInUser.IsAdmin)
            {
                UserMenuSwitch(loggedInUser);
            }
            else
            {
                AdminMenuSwitch(loggedInUser);
            }
        }

        private void AdminMenuSwitch(User loggedInUser)
        {
            while (true)
            {
                Console.WriteLine("1. Show salary \n2.Show title \n3. Handle users \n 4. Exit");
                var userChoice = check.TryParse();
                switch (userChoice)
                {
                    case 1:
                        ShowSalary(loggedInUser);
                        break;

                    case 2:
                        ShowTitle(loggedInUser);
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
            if (!StringCheck(username))
            {
                AddNewUser();
            }
            Console.WriteLine("Fill in password: ");
            var password = Console.ReadLine();
            if (!StringCheck(password))
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

        private bool StringCheck(string input)
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

        private void UserMenuSwitch(User loggedInUser)
        {
            while (true)
            {
                Console.WriteLine("1. Show salary \n2.Show title \n3. Delete yourself \n 4. Exit");
                var userChoice = check.TryParse();
                switch (userChoice)
                {
                    case 1:
                        ShowSalary(loggedInUser);
                        continue;

                    case 2:
                        ShowTitle(loggedInUser);
                        continue;

                    case 3:
                        DeleteUser(loggedInUser);
                        continue;

                    case 4:
                        return;

                    default:
                        break;
                } 
            }
        }

        private void DeleteUser(User loggedInUser)
        {
            UserMenuController userController = new();
            userController.DeleteUser(loggedInUser);
        }

        private void ShowTitle(User loggedInUser)
        {
            Console.WriteLine($"Your title is {loggedInUser.Title}");
            check.PressEnter();
        }

        private void ShowSalary(User loggedInUser)
        {
            Console.WriteLine($"Your salary is {loggedInUser.Salary}");
            check.PressEnter();
        }
    }
}