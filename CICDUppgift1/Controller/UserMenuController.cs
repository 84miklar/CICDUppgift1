namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using CICDUppgift1.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller class for user menu
    /// </summary>
    public class UserMenuController
    {
        private InputCheck helper = new();

        /// <summary>
        /// Controller method for deleting user.
        /// </summary>
        /// <param name="loggedInUser">Name om logged in user that will be checked if it exist in database or not.</param>
        /// <returns>Returns true or false based on success of operation.</returns>
        public bool DeleteUser(User loggedInUser)
        {
            UserDatabase context = new();
            LoginMenuView loginView = new();
            {
                var user = context.Users.FirstOrDefault(u => u.Name == loggedInUser.Name && u.Password == loggedInUser.Password);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    user = context.Users.FirstOrDefault(u => u.Name == loggedInUser.Name && u.Password == loggedInUser.Password);
                    if (user == null)
                    {
                        Console.WriteLine("\nYou have succesfully deleted your account");
                        Thread.Sleep(750);
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong with deleteing your account.");
                        MainMenuView menu = new();
                        menu.MainMenu(loggedInUser);
                        return true;
                    }
                }
                return true;
            }
        }
    }
}