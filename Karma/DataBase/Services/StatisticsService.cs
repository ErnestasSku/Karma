using DataBase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataBase.Models;

namespace Database.Services
{
    public class StatisticsService
    {

        private readonly IDatabaseContext _context;

        public StatisticsService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetTakenItemsByCategory(string targetCategory)
        {
            var querry =
                from i in _context.Items
                join uti in _context.UserTakenItems
                on i.ItemId equals uti.ItemId
                where i.Category.Equals(targetCategory)
                select i;
            return await querry.ToListAsync();
        }

        public KeyValuePair<string, int> GetCountByCatgory(string targetCategory)
        {
            var querry =
                   from i in _context.Items
                   join uti in _context.UserTakenItems
                   on i.ItemId equals uti.ItemId
                   select i;
            var grouped = ((querry.ToList()).Where(x => x.Category.Equals(targetCategory))).GroupBy(x => x.Category);

            List<KeyValuePair<string, int>> count = new List<KeyValuePair<string, int>>();
            foreach (var newGroup in grouped)
            {
                count.Add(new KeyValuePair<string, int>(newGroup.Key, newGroup.Count()));
            }
            return count.FirstOrDefault();
        }

        public async Task<List<KeyValuePair<string, int>>> GetCount()
        {
            var querry =
                from i in _context.Items
                join uti in _context.UserTakenItems
                on i.ItemId equals uti.ItemId
                select i;
            var grouped = (querry.ToList()).GroupBy(x => x.Category);

            List<KeyValuePair<string, int>> count = new List<KeyValuePair<string, int>>();
            foreach(var newGroup in grouped)
            {
                count.Add(new KeyValuePair<string, int>(newGroup.Key, newGroup.Count()));
            }
            return count;

        }

        public async Task<List<Item>> GetTakenItemDetails()
        {
            var querry =
                from uti in _context.UserTakenItems
                join i in _context.Items
                on uti.ItemId equals i.ItemId
                select i;

            return await querry.ToListAsync();
        }
    }
}
