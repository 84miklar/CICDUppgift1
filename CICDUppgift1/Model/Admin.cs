using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Model
{
    /// <summary>
    /// Represents Admin in the database
    /// </summary>
    public class Admin : iAccount
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}
