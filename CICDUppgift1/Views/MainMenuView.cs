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
    /// <summary>
    /// Class that handles the view for Main Menu
    /// </summary>
    public class MainMenuView
    {
        private InputCheck check = new();
        /// <summary>
        /// Method that determines which Main Menu to be showned, Admin or User Menu.
        /// </summary>
        /// <param name="loggedInUser">The iAccount object used when logging in</param>
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
        /// <summary>
        /// Shows the value of the Title property of the iAccount object
        /// </summary>
        /// <param name="loggedInUser">The iAccount object used when logging in</param>
        public void ShowTitle(iAccount loggedInUser)
        {
            Console.WriteLine($"\nYour title is {loggedInUser.Title}");
            GeneralHelpers.PressEnter();
        }
        /// <summary>
        /// Shows the value of the Salary property of the iAccount object
        /// </summary>
        /// <param name="loggedInUser">The iAccount object used when logging in</param>
        public void ShowSalary(iAccount loggedInUser)
        {
            Console.WriteLine($"\nYour salary is {loggedInUser.Salary}");
            GeneralHelpers.PressEnter();
        }
    }
}