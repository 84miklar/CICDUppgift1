using CICDUppgift1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDUppgift1.Database
{
    public class UserDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public string DatabaseName = "UserDb.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var myDocs = System.Environment.GetFolderPath(
            //System.Environment.SpecialFolder.MyDocuments);
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var myFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var path = Path.Combine(myFolder, "Databases");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseName);
            optionsBuilder.UseSqlite($"Data Source={path}; ");
        }
    }
}