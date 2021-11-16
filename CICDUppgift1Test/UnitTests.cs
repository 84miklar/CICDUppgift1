namespace CICDUppgift1Test
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Database;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using NUnit.Framework;
    using System.Linq;

    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
            Seeder.AddNewUsers();
        }

        [Test]
        [TestCase("user1", "testpass1")]
        [TestCase("admin1", "admin1234")]
        public void LoginTest(string username, string password)
        {
            var loginContr = new LoginMenuController();
            var returnedUser = loginContr.Login(username, password);
            Assert.AreEqual(returnedUser.Name, username);
        }

        [Test]
        [TestCase("use1", "testpass1")]
        [TestCase("user1", "testpass")]
        [TestCase("", "testpass1")]
        [TestCase("user 1", "testpass1")]
        public void LoginTest_FailExpected(string username, string password)
        {
            var loginContr = new LoginMenuController();
            var returnedUser = loginContr.Login(username, password);
            Assert.IsNull(returnedUser);
        }

        [Test]
        [TestCase("123", 123)]
        [TestCase("123j", -1)]
        public void TryParseTest(string testnumber, int expected)
        {
            var helperContr = new InputCheck();
            var actual = helperContr.TryParse(testnumber);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("hej123", true)]
        [TestCase("hej", false)]
        [TestCase("he j123", false)]
        public void StringCheckTest(string testString, bool expected)
        {
            var helperContr = new InputCheck();
            var actual = helperContr.StringCheck(testString);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("user2", "testpass2")]
        public void UserDeleteUserTest(string username, string password)
        {
            UserDatabase context = new();
            var userContr = new UserMenuController();
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            var returnedUser = userContr.DeleteUser(user);
            Assert.IsFalse(returnedUser);
        }

        [Test]
        [TestCase("user3", "testpass3")]
        public void AdminDeleteUserTest(string username, string password)
        {
            UserDatabase context = new();
            var adminContr = new AdminMenuController();
            adminContr.DeleteUser(username, password);
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            Assert.IsNull(user);
        }

        [Test]
        [TestCase("Testperson 2", "TestPass123", 25000, "CEO", false)]
        [TestCase("", "TestPass123", 25000, "CEO", false)]
        public void AddUserTest_NullExpected(string name, string password, int salary, string title, bool isAdmin)
        {
            var adminContr = new AdminMenuController();
            adminContr.AddUser(name, password, salary, title, isAdmin);
            UserDatabase context = new();
            var user = context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            Assert.IsNull(user);
        }

        [Test]
        [TestCase("Testperson1", "TestPass123", 25000, "CEO", false)]
        public void AddUserTest(string name, string password, int salary, string title, bool isAdmin)
        {
            var adminContr = new AdminMenuController();
            adminContr.AddUser(name, password, salary, title, isAdmin);
            var listOfUsers = adminContr.ShowAllUsers();
            var userResult = listOfUsers.Find(x => x.Name == name) as User;
            Assert.AreEqual(userResult.Name, name);
        }
    }
}