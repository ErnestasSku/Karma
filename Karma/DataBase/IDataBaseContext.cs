using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Services
{
    public interface IDatabaseContext
    {
        DbSet<Item> Items { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}