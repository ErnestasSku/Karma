using Database.Interfaces;
using Database.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ConversationRepository : IRepository<Conversation>
    {
        private IDatabaseContext _dbContext;

        public ConversationRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Conversation obj) => _dbContext.Conversations.Add(obj);


        public void Delete(Conversation obj) => _dbContext.Conversations.Remove(obj);


        public async Task<List<Conversation>> GetAll() => await _dbContext.Conversations.ToListAsync();


        public async Task<Conversation> GetById(int id) => await _dbContext.Conversations.FindAsync(id);


        public void UpdateItem(Conversation obj) => _dbContext.Conversations.Update(obj);

    }
}