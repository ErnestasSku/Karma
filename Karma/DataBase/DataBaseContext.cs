using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Database.Models;
using DataBase.Models;

namespace DataBase.Services
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        //Todo: figure out how to create model with these
        //public DbSet<UserTakenItem> UserTakenItems { get; set; }
        //public DbSet<Message> Messages { get; set; }
        //public DbSet<SentMessage> SentMessages { get; set; }


        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=KarmaDb")
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
