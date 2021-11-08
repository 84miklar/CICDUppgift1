using CICDUppgift1.Database;
using CICDUppgift1.Model;
using CICDUppgift1.Views;
using System;
using System.Linq;

namespace CICDUppgift1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LoginMenuView loginPointer = new();

            Seeder.AddNewUsers();
            loginPointer.LoginView();
            Console.WriteLine("hej");
        }
    }
}