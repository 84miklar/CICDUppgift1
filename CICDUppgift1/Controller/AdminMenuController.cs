namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class containing Admin controllers.
    /// </summary>
    public class AdminMenuController
    {
        /// <summary>
        /// Controller method for adding new user into database.
        /// </summary>
        /// <param name="username">username of added user</param>
        /// <param name="password">password of added user</param>
        /// <param name="salary">salary of added user</param>
        /// <param name="title">title of added user</param>
        /// <param name="isAdmin">bool statement if user is and admin or not</param>
        public void AddUser(string username, string password, int salary, string title, bool isAdmin)
        {
            {
                InputCheck check = new();
                if (check.StringCheck(username) && check.StringCheck(password))
                {
                    if (isAdmin)
                    {
                        if (Seeder.FillAdmin(username, password, salary, title))
                        {
                            Console.WriteLine("A new admin was added to database");
                        }
                        else
                        {
                            Console.WriteLine("The user does already exist in database");
                        }
                    }
                    else
                    {
                        if (Seeder.FillUser(username, password, salary, title))
                        {
                            Console.WriteLine($"{username} was added to database");
                        }
                        else
                        {
                            Console.WriteLine("The user does already exist in database");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Controller method for deleting existing user.
        /// </summary>
        /// <param name="username">username of user going to be deleted</param>
        /// <param name="password">password of user going to be deleted</param>
        public void DeleteUser(string username, string password)
        {
            UserDatabase context = new();
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                GeneralHelpers.SuccessMessage();
            }
            else
            {
                GeneralHelpers.FailureMessage();
            }
        }

        /// <summary>
        /// Method for adding users into list that is available in views for show.
        /// </summary>
        /// <returns>Returns a list of all users listed in database</returns>
        public List<IAccount> ShowAllUsers()
        {
            UserDatabase context = new();
            var allUsers = context.Users.ToList();
            var allAdmins = context.Admins.ToList();
            List<IAccount> all = allUsers.Cast<IAccount>().ToList();
            all.AddRange(allAdmins.Cast<IAccount>().ToList());
            return all;
        }
    }
}