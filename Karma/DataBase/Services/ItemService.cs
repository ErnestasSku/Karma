using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace DataBase.Services
{
    public class ItemService
    {
        private static readonly Lazy<ItemService> instance = new Lazy<ItemService>(delegate() { return new ItemService(); });
        private ItemService()
        { 

        }
        public static ItemService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// Gets connection to the DataBase.
        /// </summary>
        /// <returns></returns>
        private DataBaseContext getContext()
        {
            return new DataBaseContext();
        }

        /// <summary>
        /// Gets all items from DataBase.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetAllItems()
        {
            DataBaseContext _dbContext = getContext();
            List<Item> res = await _dbContext.Items.ToListAsync();
            return res;
        }
        public async Task<Item> GetSpecificItem(int id)
        {
            DataBaseContext _dbContext = getContext();
            return await _dbContext.Items.FindAsync(id);
        }

        /// <summary>
        /// Updates a certain item in the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> UpdateItem(Item obj)
        {
            DataBaseContext _dbContext = getContext();
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
            DataBaseContext _dbContext = getContext();
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
            DataBaseContext _dbContext = getContext();
            _dbContext.Items.Remove(obj);
            int res = _dbContext.SaveChanges();
            return res;
        }
    }
}
