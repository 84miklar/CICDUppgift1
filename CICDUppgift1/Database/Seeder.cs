using CICDUppgift1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Database
{
    public class Seeder
    {
        public static void AddNewUsers()
        {
            FillAdmin("admin1", "admin1234", 1000, "admin");
            FillUser("user1", "123", 2000, "IT");
            FillUser("user2", "123", 2000, "IT");
            FillUser("user3", "123", 2000, "IT");
            FillUser("user4", "123", 2000, "IT");
        }

        public static bool FillUser(string name, string password, int salary, string title)
        {
            using (var db = new UserDatabase())
            {
                var user = db.Users.FirstOrDefault(b => b.Name == name);
                if (user == null)
                {
                    user = new User { Name = name, Password = password, Salary = salary, Title = title};
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool FillAdmin(string name, string password, int salary, string title)
        {
            using (var db = new UserDatabase())
            {
                var admin = db.Admins.FirstOrDefault(b => b.Name == name);
                if (admin == null)
                {
                    admin = new Admin { Name = name, Password = password, Salary = salary, Title = title};
                    db.Update(admin);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}