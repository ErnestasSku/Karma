using DataBase.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTests
{
    public class MockDatabaseContext : DbContext, IDatabaseContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public MockDatabaseContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Mockdb")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Poster)
                .WithMany(b => b.PostedItems)
                .HasForeignKey(u => u.PosterId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
