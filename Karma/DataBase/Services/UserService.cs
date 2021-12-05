using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Database.Repositories;

namespace DataBase.Services
{
    public class UserService
    {

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly RepositoriesWrapper _repositoryWrapper;

        public UserService(IDatabaseContext repositoryWrapper)
        {
            _repositoryWrapper = new RepositoriesWrapper(repositoryWrapper);
        }

        
        public async Task<List<User>> GetUsers()
        {
            List<User> res = await _repositoryWrapper.UserRepository.GetAll();
            return res;
        }
        
        /// <summary>
        /// Gets specified user.
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            User user = await _repositoryWrapper.UserRepository.GetById(id);
            return user;
        }

        /// <summary>
        /// Gets user by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User> GetUserByUsername(string username)
        {
            List <User> users = await _repositoryWrapper.UserRepository.GetAll();
            return users.Find(x => x.Username.Equals(username));
        }

        /// <summary>
        /// Updates specified user data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> UpdateUser(int id, User obj)
        {
            obj.UserId = id;
            _repositoryWrapper.UserRepository.Delete(obj);
            int res = await _repositoryWrapper.SaveChanges();
            return res;
        }

        /// <summary>
        /// Adds new user.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> InsertUser(User obj)
        {
            _repositoryWrapper.UserRepository.Add(obj);
            int res = await _repositoryWrapper.SaveChanges();
            return res;
        }

        public async Task<int> DeleteUser(int id)
        {
            User user = await _repositoryWrapper.UserRepository.GetById(id);
            _repositoryWrapper.UserRepository.Delete(user);
            int res = await _repositoryWrapper.SaveChanges();
            return res;
        }
    }
}
