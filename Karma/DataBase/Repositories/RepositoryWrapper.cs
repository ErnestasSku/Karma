using Database.Interfaces;
using DataBase.Services;
using Repository.Repositories;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private IDatabaseContext _repositoryContext;

        public ItemRepository ItemRepository;
        public UserRepository UserRepository;


        public RepositoriesWrapper(IDatabaseContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            ItemRepository = new ItemRepository(_repositoryContext);
            UserRepository = new UserRepository(_repositoryContext);
        }

        public async Task<int> SaveChanges() => await _repositoryContext.SaveChangesAsync();
    }
}