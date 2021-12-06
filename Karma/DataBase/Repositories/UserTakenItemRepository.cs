using Database.Interfaces;
using Database.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UserTakenItemRepository /*: IRepository<UserTakenItem>*/
    {
        private IDatabaseContext _dbContext;

       /* public UserTakenItemRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserTakenItem obj) => _dbContext.UserTakenItems.Add(obj);

        public async Task<List<UserTakenItem>> GetAll() => await _dbContext.UserTakenItems.ToListAsync();

        public async Task<UserTakenItem> GetById(int id) => await _dbContext.UserTakenItems.FindAsync(id);

        public void UpdateItem(UserTakenItem obj) => _dbContext.UserTakenItems.Update(obj);

        public void Delete(UserTakenItem obj) => _dbContext.UserTakenItems.Remove(obj);
    */
    }
}

