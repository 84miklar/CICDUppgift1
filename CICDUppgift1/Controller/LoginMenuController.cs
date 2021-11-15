namespace CICDUppgift1.Controller
{
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
    using System.Linq;

    /// <summary>
    /// Controller class for Login Menu
    /// </summary>
    public class LoginMenuController
    {
        /// <summary>
        /// Controller method for logging in.
        /// </summary>
        /// <param name="username">Username of user wanting to log in</param>
        /// <param name="password">Password of user wanting to log in</param>
        /// <returns>Interface of user or admin that are in database</returns>
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