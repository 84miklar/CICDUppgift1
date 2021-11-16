namespace CICDUppgift1.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents Admin in the database
    /// </summary>
    public class Admin : Account, IAccount
    {
        [Key]
        public int AdminId { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}