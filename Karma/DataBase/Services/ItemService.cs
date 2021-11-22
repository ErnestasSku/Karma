using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DataBase;

namespace DataBase.Services
{
    public class ItemService
    {

        /// <summary>
        /// Database context.
        /// </summary>
        private IDataBaseContext _dbContext;

        public ItemService(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Gets all items from DataBase.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetAllItems()
        {
            List<Item> res = await _dbContext.Items.ToListAsync();
            return res;
        }
        public async Task<Item> GetSpecificItem(int id)
        {
            return await _dbContext.Items.FindAsync(id);
        }

        /// <summary>
        /// Updates a certain item in the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> UpdateItem(Item obj)
        {
            _dbContext.Items.Update(obj);
            int res = await _dbContext.SaveChangesAsync();
            return res;
        }

        /// <summary>
        /// Inserts a new item to the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertItem(Item obj)
        {
            _dbContext.Items.Add(obj);
            int res = _dbContext.SaveChanges();
            return res;
        }

        /// <summary>
        /// Removes an item from the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteItem(Item obj)
        {
            _dbContext.Items.Remove(obj);
            int res = _dbContext.SaveChanges();
            return res;
        }
    }
}
