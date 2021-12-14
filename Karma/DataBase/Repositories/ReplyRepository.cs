using Database.Interfaces;
using Database.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ReplyRepository : IRepository<Reply>
    {
        private IDatabaseContext _dbContext;

        public ReplyRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Reply obj) => _dbContext.Replies.Add(obj);


        public void Delete(Reply obj) => _dbContext.Replies.Remove(obj);

        public async Task<List<Reply>> GetAll() => await _dbContext.Replies.ToListAsync();

        public async Task<Reply> GetById(int id) => await _dbContext.Replies.FindAsync(id);

        public void UpdateItem(Reply obj) => _dbContext.Replies.Update(obj);

    }
}
