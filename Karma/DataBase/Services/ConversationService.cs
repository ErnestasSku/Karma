using Database.Models;
using Database.Repositories;
using DataBase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class ConversationService
    {
        private RepositoriesWrapper _repository;

        public ConversationService(IDatabaseContext dbContext)
        {
            _repository = new RepositoriesWrapper(dbContext);
        }
        public async Task<List<Conversation>> GetAllConversations()
        {
            List<Conversation> res = await _repository.ConversationRepository.GetAll();
            return res;
        }
        public async Task<Conversation> GetSpecificConversation(int id)
        {
            return await _repository.ConversationRepository.GetById(id);
        }
        public async Task<Conversation> GetUserConversations(int id)
        {
            List<Conversation> res = await _repository.ConversationRepository.GetAll();
            return res.Find(x => x.UserOne.Equals(id) || x.UserTwo.Equals(id));
        }
        public async Task<int> CreateConversation(Conversation conversation)
        {
            _repository.ConversationRepository.Add(conversation);
            int res = await _repository.SaveChanges();
            return res;
        }
        public async Task<int> DeleteConversation(Conversation conversation)
        {
            _repository.ConversationRepository.Delete(conversation);
            int res = await _repository.SaveChanges();
            return res;

        }
    }
}
