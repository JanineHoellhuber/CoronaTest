
using ClassLibrary1;
using ClassLibrary1.Entities;
using CoronaTest.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace CoronaTest.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VerificationToken> VerificationTokens { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<TestCenter> TestCenter { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Examination> Examination { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();


            Debug.WriteLine(configuration);

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }
    }


}



