using AutoLogin.Domain.Entities;
using AutoLogin.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AutoLogin.Persistence.Context
{
    public sealed class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

    }
}
