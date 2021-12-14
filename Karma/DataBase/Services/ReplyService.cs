using Database.Models;
using Database.Repositories;
using DataBase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class ReplyService
    {
        private RepositoriesWrapper _repository;

        public ReplyService(IDatabaseContext dbContext)
        {
            _repository = new RepositoriesWrapper(dbContext);
        }

        public async Task<List<Reply>> GetAllReplies()
        {
            List<Reply> res = await _repository.ReplyRepository.GetAll();
            return res;
        }
        public async Task<Reply> GetReplyById(int id)
        {
            return await _repository.ReplyRepository.GetById(id);
        }
        public async Task<Reply> GetConversationReplies(int conversationId)
        {
            List<Reply> res = await _repository.ReplyRepository.GetAll();
            return res.Find(x => x.ConversationId == conversationId);
        }
        public async Task<int> CreateReply(Reply reply)
        {
            _repository.ReplyRepository.Add(reply);
            int res = await _repository.SaveChanges();
            return res;
        }
        public async Task<int> DeleteReply(Reply reply)
        {
            _repository.ReplyRepository.Delete(reply);
            int res = await _repository.SaveChanges();
            return res;
        }
    }
}
