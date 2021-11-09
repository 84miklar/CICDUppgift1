namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AdminMenuController
    {
        private UserDatabase context = new();

        public void AddUser(string username, string password, int salary, string title, bool isAdmin)
        {
            {
                if (Seeder.FillUser(username, password, salary, title, isAdmin))
                {
                    Console.WriteLine("User was added to database");
                }
                else
                {
                    Console.WriteLine("The user does already exist in database");
                }
            }
        }

        //public User FindUser(User l)
        //{
        //    {
        //        var user = context.Users.FirstOrDefault(u => u.Name == loggedInUser.Name && u.Password == loggedInUser.Password);
        //        if (user != null)
        //        {
        //            context.Users.Remove(user);
        //            context.SaveChanges();
        //            user = context.Users.FirstOrDefault(u => u.Name == loggedInUser.Name && u.Password == loggedInUser.Password);
        //            if (user == null)
        //            {
        //                Console.WriteLine("You have succesfully deleted your account");
        //                helper.PressEnter();
        //            }
        //            else
        //            {
        //                Console.WriteLine("Something went wrong with deleteing your account.");
        //                MainMenuView menu = new();
        //                menu.MainMenu(loggedInUser);
        //            }
        //        }
        //    }
        //    return null;
        //}
    }
}