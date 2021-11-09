using CICDUppgift1.Database;
using CICDUppgift1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Controller
{
    public class MainMenuController
    {
        private UserDatabase context = new();

        public User DeleteUser(User loggedInUser)
        {
            {
                var user = context.Users.FirstOrDefault(u => u.Name == loggedInUser.Name && u.Password == loggedInUser.Password);
                if (user != null)
                {
                    context.Users.Remove(loggedInUser);
                    context.Users.Update(user);
                    context.SaveChanges();
                }
            }
            return null;
        }
    }
}