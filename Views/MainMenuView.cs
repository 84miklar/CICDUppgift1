using CICDUppgift1.Helpers;
using CICDUppgift1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Views
{
    public class MainMenuView
    {
        private InputCheck check = new();
        internal static void MainMenu(User loggedInUser)
        {
            Console.WriteLine("1. Show salary \n2.Show title \n3. Delete yourself \n 4. Exit");
           
        }
    }
}
