using DataBase.Models;
using Database.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DataBase.Services
{
    public class ItemService
    {

        /// <summary>
        /// Database context.
        /// </summary>
        private RepositoriesWrapper _repository;

        public ItemService(IDatabaseContext dbContext)
        {
            _repository = new RepositoriesWrapper(dbContext);
        }


        /// <summary>
        /// Gets all items from DataBase.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetAllItems()
        {
            List<Item> res = await _repository.ItemRepository.GetAllItems();
            return res;
        }
        public async Task<Item> GetSpecificItem(int id)
        {
            return await _repository.ItemRepository.GetById(id);
        }

        /// <summary>
        /// Updates a certain item in the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> UpdateItem(int id, Item obj)
        {
            obj.ItemId = id;
            _repository.ItemRepository.UpdateItem(obj);
            int res = await _repository.SaveChanges();
            return res;
        }

        /// <summary>
        /// Inserts a new item to the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> InsertItem(Item obj)
        {
            _repository.ItemRepository.Add(obj);
            int res = await _repository.SaveChanges();
            return res;
        }

        /// <summary>
        /// Removes an item from the DataBase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<int> DeleteItem(Item obj)
        {
            _repository.ItemRepository.Delete(obj);
            int res = await _repository.SaveChanges();
            return res;
        }

        /// <summary>
        /// Returns a specific page items.
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="itemNumber">Number of items shown on page</param>
        /// <returns></returns>
        public async Task<IEnumerable<Item>> GetPageItems(int pageNumber, int itemNumber)
        {
            return (await _repository.ItemRepository.GetAllItems()).Skip(pageNumber * itemNumber).Take(itemNumber);
        }
    }
}
