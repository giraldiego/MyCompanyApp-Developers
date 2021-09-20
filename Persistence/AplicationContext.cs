using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class AplicacionContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=Company48;User Id=SA;Password=427568.Ot";
        //cambiar por ("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =Company48")

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(ConnectionString);
            }
        }
    }
}