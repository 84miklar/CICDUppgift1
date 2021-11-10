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

        internal void MainMenu(iAccount loggedInUser)
        {
            AdminMenuView adminPointer = new();
            UserMenuView userPointer = new();
            Console.Clear();

            if (loggedInUser is User)
            {
                userPointer.UserMenuSwitch(loggedInUser as User);
            }
            else
            {
                adminPointer.AdminMenuSwitch(loggedInUser as Admin);
            }
        }

        public void ShowTitle(iAccount loggedInUser)
        {
            Console.WriteLine($"Your title is {loggedInUser.Title}");
            check.PressEnter();
        }

        public void ShowSalary(iAccount loggedInUser)
        {
            Console.WriteLine($"Your salary is {loggedInUser.Salary}");
            check.PressEnter();
        }
    }
}