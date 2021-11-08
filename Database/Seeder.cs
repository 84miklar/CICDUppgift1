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
            FillUser("admin1", "admin1234", 1000, "admin", true);
        }
        public static void FillUser(string name, string password, int salary, string title, bool isAdmin)
        {
            using (var db = new UserDatabase())
            {
                var user = db.Users.FirstOrDefault(b => b.Name == name);
                if (user == null)
                {
                    user = new User { Name = name, Password = password, Salary = salary, Title = title, IsAdmin = isAdmin };
                    db.Update(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
