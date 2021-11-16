namespace CICDUppgift1.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a User in the database
    /// </summary>
    public class User : Account, IAccount
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}