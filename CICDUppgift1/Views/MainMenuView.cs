namespace CICDUppgift1.Views
{
    using CICDUppgift1.Model;
    using System;

    /// <summary>
    /// Class that handles the view for Main Menu
    /// </summary>
    public class MainMenuView
    {
        /// <summary>
        /// Method that determines which Main Menu to be showned, Admin or User Menu.
        /// </summary>
        /// <param name="loggedInUser">The iAccount object used when logging in</param>
        internal void MainMenu(IAccount loggedInUser)
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
    }
}