using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Model
{
    /// <summary>
    /// Represents a User in the database
    /// </summary>
    public class User : iAccount
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}
