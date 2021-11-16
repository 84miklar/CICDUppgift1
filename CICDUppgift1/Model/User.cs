using System.ComponentModel.DataAnnotations;

namespace CICDUppgift1.Model
{
    /// <summary>
    /// Represents a User in the database
    /// </summary>
    public class User : Account, iAccount
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}