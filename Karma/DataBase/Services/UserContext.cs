using System;
using System.IO;
using Backend;
using Xamarin.Essentials;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Services
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Users.db");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}