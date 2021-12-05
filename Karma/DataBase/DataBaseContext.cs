using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Database.Models;

namespace DataBase.Services
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Models.Item> Items { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<UserTakenItem> UserTakenItems { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }


        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=KarmaDb")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
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
