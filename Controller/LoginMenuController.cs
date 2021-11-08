namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class LoginMenuController
    {
        private UserDatabase context = new();

        public User Login(string username, string password)
        {
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
                if (user != null)
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user;
                }
            }
            return null;
        }
    }
}