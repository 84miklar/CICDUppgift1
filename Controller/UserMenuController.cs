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
    using System.Threading.Tasks;

    internal class UserMenuController
    {
        private InputCheck helper = new();

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
                        Console.WriteLine("You have succesfully deleted your account");
                        helper.PressEnter();
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
            }
            return true;
        }
    }
}