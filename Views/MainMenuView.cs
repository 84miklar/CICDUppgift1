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

        internal void MainMenu(User loggedInUser)
        {
            AdminMenuView adminPointer = new();
            UserMenuView userPointer = new();
            Console.Clear();

            if (!loggedInUser.IsAdmin)
            {
                userPointer.UserMenuSwitch(loggedInUser);
            }
            else
            {
                adminPointer.AdminMenuSwitch(loggedInUser);
            }
        }

        public void ShowTitle(User loggedInUser)
        {
            Console.WriteLine($"Your title is {loggedInUser.Title}");
            check.PressEnter();
        }

        public void ShowSalary(User loggedInUser)
        {
            Console.WriteLine($"Your salary is {loggedInUser.Salary}");
            check.PressEnter();
        }
    }
}