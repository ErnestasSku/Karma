using System;
using System.IO;
using Backend;
using Xamarin.Essentials;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Services
{
    public class ItemContext :  DbContext
    {
        public DbSet<Backend.Item> Items { get; set; }

        public ItemContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Items.db");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
