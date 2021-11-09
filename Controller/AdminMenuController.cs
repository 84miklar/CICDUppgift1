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
    }
}