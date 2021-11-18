namespace IntegrationTests
{
    using CICDUppgift1.Database;
    using CICDUppgift1Test;
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
        [TestCase("admin1", "admin1234")]
        public void AdminDeleteUserIntegrationTest(string username, string password)
        {
            UserDatabase context = new();
            var unitTestPointer = new UnitTests();
            var testPersonName = "IntegrationTestPerson1";
            var testPersonPass = "IntegrationTestPass1";
            unitTestPointer.LoginTest(username, password);
            unitTestPointer.AddUserTest(testPersonName, testPersonPass, 25000, "Janitor", false);
            var user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.AreEqual(testPersonName, user.Name);
            unitTestPointer.AdminDeleteUserTest(testPersonName, testPersonPass);
            user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.IsNull(user);
        }

        [Test]
        [TestCase("admin1", "admin1234")]
        public void UserDeleteUserIntegrationTest(string username, string password)
        {
            UserDatabase context = new();
            var unitTestPointer = new UnitTests();
            var testPersonName = "IntegrationTestPerson2";
            var testPersonPass = "IntegrationTestPass2";
            unitTestPointer.LoginTest(username, password);
            unitTestPointer.AddUserTest(testPersonName, testPersonPass, 20000, "Service", false);
            unitTestPointer.LoginTest(testPersonName, testPersonPass);
            var user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.AreEqual(testPersonName, user.Name);
            unitTestPointer.UserDeleteUserTest(testPersonName, testPersonPass);
            user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.IsNull(user);
        }
    }
}