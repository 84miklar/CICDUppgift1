using CICDUppgift1.Database;
using CICDUppgift1.Model;
using System;
using System.Linq;

namespace CICDUppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Seeder.AddNewUsers();
            loginPointer.LoginView();
        }
    }
}
