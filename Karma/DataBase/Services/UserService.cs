using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace DataBase.Services
{
    public class UserService
    {

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDataBaseContext _dbContext;

        public UserService(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<List<User>> GetUsers()
        {
            List<User> res = await _dbContext.Users.ToListAsync();
            return res;
        }
        
        /// <summary>
        /// Gets specified user.
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            User user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        /// <summary>
        /// Gets user by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User> GetUserByUsername(string username)
        {
            User user = await _dbContext.Users.FindAsync(username);
            return user;
        }

        /// <summary>
        /// Updates specified user data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> UpdateUser(User obj)
        {
            _dbContext.Users.Update(obj);
            int res = await _dbContext.SaveChangesAsync();
            return res;
        }

        /// <summary>
        /// Adds new user.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertUser(User obj)
        {
            _dbContext.Users.Add(obj);
            int res = _dbContext.SaveChanges();
            return res;
        }

        public int DeleteUser(User obj)
        {
            _dbContext.Users.Remove(obj);
            int res = _dbContext.SaveChanges();
            return res;
        }
    }
}
