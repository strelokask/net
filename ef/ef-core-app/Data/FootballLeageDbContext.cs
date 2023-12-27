﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FootballLeageDbContext: DbContext
    {
        public FootballLeageDbContext(DbContextOptions<FootballLeageDbContext> options): base(options)
        {
            
        }
        public DbSet<Team> Teams {  get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<vw_TeamsAndLeagues> vw_TeamsAndLeagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<vw_TeamsAndLeagues>()
                .HasNoKey()
                .ToView(nameof(vw_TeamsAndLeagues))
                ;
        }
        public override int SaveChanges()
        {
            TrackUpdatedEntities();
            return base.SaveChanges();
        }
        void TrackUpdatedEntities()
        {
            var newEntries = ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            var currentDateTime = DateTimeOffset.Now;
            foreach (var entry in newEntries)
            {
                entry.Entity.CreatedDate = currentDateTime;
                entry.Entity.LastModifiedDate = currentDateTime;
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer("Data Source=localhost; Initial Catalog=FootballLeageEFCoreApp; User Id=sa;Password=1qaz!QAZ;Integrated Security=True;TrustServerCertificate=True;")
        //        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        //        //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        //        .EnableSensitiveDataLogging()
        //        .EnableDetailedErrors()
        //        ;
        //}
    }
}
