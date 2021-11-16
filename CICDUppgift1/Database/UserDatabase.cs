using CICDUppgift1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CICDUppgift1.Database
{
    /// <summary>
    /// Context class for communicating with database.
    /// </summary>
    public class UserDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public string DatabaseName = "UserDb.db";

        /// <summary>
        /// Configuring method used for communication with database.
        /// </summary>
        /// <param name="optionsBuilder">Optionsbuilder for database methods</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.ToString();
            var path = Path.Combine(myFolder, "Databases");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseName);
            optionsBuilder.UseSqlite($"Data Source={path}; ");
        }
    }
}