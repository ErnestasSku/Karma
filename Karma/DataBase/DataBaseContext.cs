using System;
using System.IO;
using Backend;
using Xamarin.Essentials;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;



namespace DataBase.Services
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Models.Item> Items { get; set; }
        public DbSet<Models.User> Users { get; set; }


        public DataBaseContext()
        {
            /* SQLitePCL.Batteries_V2.Init();
             Database.EnsureCreated();*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=KarmaDb")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


        //TODO: old method, might be needed in the future.
        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {

              string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MainDataBase.db");

              optionsBuilder.UseSqlite($"Filename={dbPath}");
          }*/

    }
}
