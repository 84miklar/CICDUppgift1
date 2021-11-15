namespace CICDUppgift1.Views
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using System;

    /// <summary>
    /// Class that handles the view for Admin Menu
    /// </summary>
    internal class AdminMenuView
    {
        private InputCheck check = new();

        /// <summary>
        /// Outputs the Admin Menu and handles input choice
        /// </summary>
        /// <param name="loggedInUser">The Admin object used when logging in</param>
        public void AdminMenuSwitch(Admin loggedInUser)
        {
            MainMenuView mainPointer = new();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Show salary \n2.Show title \n3. Handle users \n4. Exit");
                var userChoice = check.TryParse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        loggedInUser.ShowSalary(loggedInUser);
                        break;

                    case 2:
                        loggedInUser.ShowTitle(loggedInUser);
                        break;

                    case 3:
                        HandleUsers();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Outputs the Handle Users Menu and handles input choice.
        /// </summary>
        private void HandleUsers()
        {
            Console.Clear();
            Console.WriteLine("1. Add new user \n2. See all users \n3. Delete Users \n4. Exit");
            var userChoice = check.TryParse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    AddNewUser();
                    break;

                case 2:
                    ShowAllUsers();
                    break;

                case 3:
                    DeleteUser();
                    break;

                case 4:
                    return;

                default:
                    break;
            }
        }

        /// <summary>
        /// Outputs all Users and Admins in the database.
        /// </summary>
        private void ShowAllUsers()
        {
            AdminMenuController adminController = new();
            Console.WriteLine("\nID\tUsername\t\tPassword\t\tTitle");
            foreach (var item in adminController.ShowAllUsers())
            {
                if (item is User user)
                {
                    Console.Write(user.UserId + "\t");
                }
                if (item is Admin admin)
                {
                    Console.Write(admin.AdminId + "\t");
                }
                Console.WriteLine(item.Name + "\t\t\t" + item.Password + "\t\t\t" + item.Title);
            }
            GeneralHelpers.PressEnter();
        }

        /// <summary>
        /// Handles outputs and inputs for the Delete User choice.
        /// </summary>
        private void DeleteUser()
        {
            Console.WriteLine("\nFill in username of the user you want to delete: ");
            var username = Console.ReadLine();
            Console.WriteLine("Fill in password of the user you want to delete: ");
            var password = Console.ReadLine();
            AdminMenuController adminController = new();
            adminController.DeleteUser(username, password);
            GeneralHelpers.PressEnter();
        }

        /// <summary>
        /// Handles outputs and inputs for the Add new user choice.
        /// </summary>
        private void AddNewUser()
        {
            AdminMenuController adminController = new();
            Console.WriteLine("\nBoth username and password have to contain both letters and numbers");
            Console.WriteLine("Fill in username: ");
            var username = Console.ReadLine();
            if (!check.StringCheck(username))
            {
                AddNewUser();
            }
            Console.WriteLine("Fill in password: ");
            var password = Console.ReadLine();
            if (!check.StringCheck(password))
            {
                AddNewUser();
            }
            Console.WriteLine("Is this person admin? y/n");
            bool isAdmin = false;
            var adminQuestion = Console.ReadLine().ToLower();
            if (adminQuestion == "y")
            {
                isAdmin = true;
            }
            Console.WriteLine("Fill in salary: ");
            var salary = check.TryParse(Console.ReadLine());
            Console.WriteLine("Fill in the title of person: ");
            var title = Console.ReadLine();
            adminController.AddUser(username, password, salary, title, isAdmin);
            GeneralHelpers.PressEnter();
        }
    }
}