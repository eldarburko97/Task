using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Result> results { get; set; }
        public DbSet<Constituency> constituencies { get; set; }
        public DbSet<Candidate> candidates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    Code = "DT",
                    FirstName = "Donald",
                    LastName = "Trump",
                });

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 2,
                    Code = "HC",
                    FirstName = "Hillary",
                    LastName = "Clinton",
                });

            modelBuilder.Entity<Candidate>().HasData(
               new Candidate
               {
                   Id = 3,
                   Code = "JB",
                   FirstName = "Joe",
                   LastName = "Biden",
               });

            modelBuilder.Entity<Candidate>().HasData(
               new Candidate
               {
                   Id = 4,
                   Code = "JFK",
                   FirstName = "John F.",
                   LastName = "Kennedy",
               });

            modelBuilder.Entity<Candidate>().HasData(
               new Candidate
               {
                   Id = 5,
                   Code = "JR",
                   FirstName = "Jack",
                   LastName = "Randall",
               });
        }
    }
}
