namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdminMenuController
    {
        public void AddUser(string username, string password, int salary, string title, bool isAdmin)
        {
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

        public void DeleteUser(string username, string password)
        {
            UserDatabase context = new();
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                Console.WriteLine($"You have succesfully removed {username}");
            }
            else
            {
                Console.WriteLine("No user was found...");
            }
        }

        public List<iAccount> ShowAllUsers()
        {
            UserDatabase context = new();
            var allUsers = context.Users.ToList();
            var allAdmins = context.Admins.ToList();
            List<iAccount> all = allUsers.Select(x => (iAccount)x).ToList();
            all.AddRange(allAdmins.Select(x => (iAccount)x).ToList());
            return all;
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