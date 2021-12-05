using Database.Interfaces;
using DataBase.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private IDatabaseContext _dbContext;

        public ItemRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Item item) => _dbContext.Items.Add(item);

        public async Task<List<Item>> GetAllItems() => await _dbContext.Items.ToListAsync();

        public async Task<Item> GetById(int id) => await _dbContext.Items.FindAsync(id);

        public void UpdateItem(Item obj) => _dbContext.Items.Update(obj);

        public void Delete(Item obj) => _dbContext.Items.Remove(obj);
    }
}
