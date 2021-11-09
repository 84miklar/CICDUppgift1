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
        private MainMenuController controllerPointer = new();

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
                    DeleteUser(loggedInUser);
                    break;

                case 4:
                    return;

                default:
                    break;
            }
        }

        private void UserMenuSwitch(User loggedInUser)
        {
            Console.WriteLine("1. Show salary \n2.Show title \n3. Delete yourself \n 4. Exit");
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
                    DeleteUser(loggedInUser);
                    break;

                case 4:
                    return;

                default:
                    break;
            }
        }

        private void DeleteUser(User loggedInUser)
        {
            controllerPointer.DeleteUser(loggedInUser);
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