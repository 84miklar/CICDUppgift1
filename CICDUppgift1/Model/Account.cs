using CICDUppgift1.Helpers;
using System;

namespace CICDUppgift1.Model
{
    public abstract class Account
    {
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