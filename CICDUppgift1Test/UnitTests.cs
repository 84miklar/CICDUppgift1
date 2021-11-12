namespace CICDUppgift1Test
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Database;
    using CICDUppgift1.Helpers;
    using CICDUppgift1.Model;
    using NUnit.Framework;
    using System.Linq;

    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Seeder.AddNewUsers();
        }

        [Test]
        [TestCase("user1", "123")]
        public void LoginTest(string username, string password)
        {
            var loginContr = new LoginMenuController();
            var returnedUser = loginContr.Login(username, password);
            Assert.AreEqual(returnedUser.Name, username);
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
        public void StringCheckTest(string testString, bool expected)
        {
            var helperContr = new InputCheck();
            var actual = helperContr.StringCheck(testString);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("user2", "123")]
        public void DeleteUserTest(string username, string password)
        {
            UserDatabase context = new();
            var userContr = new UserMenuController();
            var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            var returnedUser = userContr.DeleteUser(user);
            Assert.IsFalse(returnedUser);
        }
    }
}