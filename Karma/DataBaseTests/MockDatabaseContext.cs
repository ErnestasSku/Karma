using Database.Models;
using DataBase.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataBaseTests
{
    public class MockDatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTakenItem> UserTakenItems { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public MockDatabaseContext(DbContextOptions<MockDatabaseContext> options) : base(options)
        {

        }


        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Mockdb")
                 .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
         }*/
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

        public static MockDatabaseContext GetMockDatabaseContext(string name)
        {
            var options = new DbContextOptionsBuilder<MockDatabaseContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;
            return new MockDatabaseContext(options);
        }

    }
}
