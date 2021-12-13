using DataBase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database.Services
{
    public class StatisticsService
    {

        private readonly IDatabaseContext _context;

        public StatisticsService(IDatabaseContext context)
        {
            _context = context;
        }

        public async void GetCount()
        //public async Task<IEnumerable<KeyValuePair<string, int> >> GetCount()
        {
            /*var querry =
                 from uti in _context.UserTakenItems
                 join i in _context.Items
                 on uti.ItemId equals i.ItemId
                 group i by i.Category into newGroup
                 orderby newGroup.Key
                 select newGroup;*/

            var querry =
                from i in _context.Items
                join uti in _context.UserTakenItems
                on i.ItemId equals uti.ItemId
                group i by i.Category into newGroup
                select newGroup;

            List<KeyValuePair<string, int>> count = new List<KeyValuePair<string, int>>();
            foreach(var newGroup in querry)
            {
                count.Add(new KeyValuePair<string, int>(newGroup.Key, newGroup.Count()));
            }

        }

        public async void GetTakenItemDetails()
        {
            var querry =
                from uti in _context.UserTakenItems
                join i in _context.Items
                on uti.ItemId equals i.ItemId
                select i;

            foreach (var i in querry)
                Console.WriteLine(i);
        }
    }
}
