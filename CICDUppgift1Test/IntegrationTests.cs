namespace IntegrationTests
{
    using CICDUppgift1.Controller;
    using CICDUppgift1.Database;
    using CICDUppgift1.Model;
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
        [TestCase("user1", "123")]
        public void Mock(string username, string password)
        {
            var unitTestPointer = new UnitTests();
            unitTestPointer.LoginTest(username, password);
            unitTestPointer.DeleteUserTest(username, password);
        }
    }
}