using Mediatheque.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Core.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CD> CDs { get; set; }
        public DbSet<JeuxDeSociete> Jeux { get; set; }

        public DbSet<Etagere> Etageres { get; set; }

        public DbSet<Dvd> Dvd { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=Mediatheque;Uid=root;Pwd=;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

    }
}
