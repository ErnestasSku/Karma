using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataBase.Services;
using Database.Models;

namespace UnitTests
{
    public class MockdDtabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<DataBase.Models.Item> Items { get; set; }
        public DbSet<DataBase.Models.User> Users { get; set; }
        public DbSet<UserTakenItem> UserTakenItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public MockdDtabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Mockdb")
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
