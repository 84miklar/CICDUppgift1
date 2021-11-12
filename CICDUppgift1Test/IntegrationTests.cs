namespace IntegrationTests
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Model;
    using NUnit.Framework;
    using System.Linq;

    public class IntegrationTests
    {
        [Test]
        [TestCase("Testperson1", "TestPass123", 25000, "CEO", false)]
        public void AddUserTest(string name, string password, int salary, string title, bool isAdmin)
        {
            var adminContr = new AdminMenuController();
            adminContr.AddUser(name, password, salary, title, isAdmin);
            var listOfUsers = adminContr.ShowAllUsers();
            var userResult = listOfUsers.FirstOrDefault(x => x.Name == name) as User;
            Assert.AreEqual(userResult.Name, name);
        }
    }
}