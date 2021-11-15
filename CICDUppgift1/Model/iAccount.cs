using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Model
{
    /// <summary>
    /// Interface to be inplemented by the Users and Admins in the database.
    /// </summary>
    public interface iAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }
}
