using Database.Interfaces;
using DataBase.Services;
using DataBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseContext _dbContext;

        public UserRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user) => _dbContext.Users.Add(user);

        public async Task<List<User>> GetAll() => await _dbContext.Users.ToListAsync();

        public async Task<User> GetById(int id) => await _dbContext.Users.FindAsync(id);

        public void UpdateItem(User obj) => _dbContext.Users.Update(obj);

        public void Delete(User obj) => _dbContext.Users.Remove(obj);

    }
}
