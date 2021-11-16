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
        public void AddUserIntegrationTest(string username, string password)
        {
            UserDatabase context = new();
            var unitTestPointer = new UnitTests();
            var testPersonName = "IntegrationTestPerson1";
            var testPersonPass = "IntegrationTestPass123";
            unitTestPointer.LoginTest(username, password);
            unitTestPointer.AddUserTest(testPersonName, testPersonPass, 15000, "Intern", false);
            var user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.AreEqual(testPersonName, user.Name);
        }

        [Test]
        [TestCase("admin1", "admin1234")]
        public void DeleteUserIntegrationTest(string username, string password)
        {
            UserDatabase context = new();
            var unitTestPointer = new UnitTests();
            var testPersonName = "IntegrationTestPerson2";
            var testPersonPass = "IntegrationTestPass1234";
            unitTestPointer.LoginTest(username, password);
            unitTestPointer.AddUserTest(testPersonName, testPersonPass, 20000, "Service", false);
            unitTestPointer.LoginTest(testPersonName, testPersonPass);
            unitTestPointer.UserDeleteUserTest(testPersonName, testPersonPass);
            var user = context.Users.FirstOrDefault(u => u.Name == testPersonName && u.Password == testPersonPass);
            Assert.IsNull(user);
        }
    }
}