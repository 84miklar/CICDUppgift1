namespace CICDUppgift1.Model
{
    /// <summary>
    /// Interface to be inplemented by the Users and Admins in the database.
    /// </summary>
    public interface IAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}