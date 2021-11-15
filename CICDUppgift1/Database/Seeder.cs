using CICDUppgift1.Model;
using System.Linq;

namespace CICDUppgift1.Database
{
    /// <summary>
    /// Seeder class that are filling upp database if it's not already filled.
    /// </summary>
    public class Seeder
    {
        /// <summary>
        /// Seeder method user for filling up database with mock data.
        /// </summary>
        public static void AddNewUsers()
        {
            FillAdmin("admin1", "admin1234", 1000, "admin");
            FillUser("user1", "testpass1", 2000, "IT");
            FillUser("user2", "testpass2", 3000, "Service");
            FillUser("user3", "testpass3", 4000, "Chef");
            FillUser("user4", "testpass4", 5000, "Cleaner");
        }

        /// <summary>
        /// Method for inserting normal users into database.
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <param name="password">Password of user</param>
        /// <param name="salary">Salary of user</param>
        /// <param name="title">Title of user</param>
        /// <returns></returns>
        public static bool FillUser(string name, string password, int salary, string title)
        {
            using (var db = new UserDatabase())
            {
                var user = db.Users.FirstOrDefault(b => b.Name == name);
                if (user == null)
                {
                    user = new User { Name = name, Password = password, Salary = salary, Title = title };
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Method for inserting admin users into database.
        /// </summary>
        /// <param name="name">Name of admin user</param>
        /// <param name="password">Password of admin user</param>
        /// <param name="salary">Salary of admin user</param>
        /// <param name="title">Title of admin user</param>
        /// <returns></returns>
        public static bool FillAdmin(string name, string password, int salary, string title)
        {
            using (var db = new UserDatabase())
            {
                var admin = db.Admins.FirstOrDefault(b => b.Name == name);
                if (admin == null)
                {
                    admin = new Admin { Name = name, Password = password, Salary = salary, Title = title };
                    db.Update(admin);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}