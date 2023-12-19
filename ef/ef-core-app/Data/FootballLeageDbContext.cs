using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FootballLeageDbContext: DbContext
    {
        public DbSet<Team> Teams {  get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=EFCoreApp; User Id=sa;Password=1qaz!QAZ;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
