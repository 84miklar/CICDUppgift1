using CICDUppgift1.Database;
using CICDUppgift1.Model;
using System;
using System.Linq;

namespace CICDUppgift1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Seeder.AddNewUsers();
            loginPointer.LoginView();
            Console.WriteLine("hejehj");
            Console.WriteLine("testtest");
        }
    }
}