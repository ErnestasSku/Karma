using System;
using System.IO;
//using Backend; TODO: refactor backend
using Xamarin.Essentials;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataBase.Services
{
  public class ItemService
    {
        private DataBaseContext getContext()
        {
            /* string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "item.db3");`
             return DataBaseContext(dbPath);*/
            return new DataBaseContext();
        }

        public async Task<List<Item>> GetAllItems()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Items.ToListAsync();
            return res;
        }

        public int InsertItem(Item obj)
        {
            var _dbContext = getContext();
            _dbContext.Items.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        /// <summary>
        /// TODO: Fix, error with ID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteItem(Item obj)
        {
            var _dbContext = getContext();
            _dbContext.Items.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
