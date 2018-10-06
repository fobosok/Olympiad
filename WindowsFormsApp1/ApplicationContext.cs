using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Result> Results { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Olympiad;Trusted_Connection=True;");
        }
    }
}
