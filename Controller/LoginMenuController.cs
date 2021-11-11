namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginMenuController
    {
        public iAccount Login(string username, string password)
        {
            UserDatabase context = new();
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
                if (user != null)
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user;
                }
                else
                {
                    var admin = context.Admins.FirstOrDefault(u => u.Name == username && u.Password == password);
                    if (admin != null)
                    {
                        context.Admins.Update(admin);
                        context.SaveChanges();
                        return admin;
                    }
                }
            }
            return null;
        }
    }
}