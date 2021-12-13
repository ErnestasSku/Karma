using Xunit;
using DataBase.Models;
using DataBase.Services;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;

namespace DataBaseTests
{
    public class ItemServiceTests
    {
        [Fact]
        public async void InsertItem_GetAllItems_Test()
        {
            var name1 = "stalas";
            var name2 = "kede";

            var data = new List<Item>
            {
                new Item { Name = name1 },
                new Item { Name = name2 },
            };

            using (var context = MockDatabaseContext.GetMockDatabaseContext("Item_1"))
            {
                var itemService = new ItemService(context);

                foreach(var item in data)
                {
                    await itemService.InsertItem(item);
                }

                var items = await itemService.GetAllItems();

                Assert.Equal(2, items.Count);
                Assert.Equal(items[0].Name, name1);
                Assert.Equal(items[1].Name, name2);
            }
            
        }

        [Fact]
        public async void DeleteItem_Test()
        {

        
            using (var context = MockDatabaseContext.GetMockDatabaseContext("Item_2"))
            {    
                var itemService = new ItemService(context);

                var name1 = "stalas";
                var item1 = new Item { Name = name1 };

                var name2 = "kede";
                var item2 = new Item { Name = name2 };

                await itemService.InsertItem(item1);
                await itemService.InsertItem(item2);

                await itemService.DeleteItem(item1);

                List<Item> items = await itemService.GetAllItems();
                Assert.Equal(items[0].Name, name2);
            }
        }
        [Fact]
        public async void GetSpecificItem_Test()
        {
            using (var context = MockDatabaseContext.GetMockDatabaseContext("Item_3"))
            {
                var itemService = new ItemService(context);

                var name1 = "stalas";
                var item1 = new Item { Name = name1 };

                var name2 = "kede";
                var item2 = new Item { Name = name2 };

                await itemService.InsertItem(item1);
                await itemService.InsertItem(item2);

                Item item = await itemService.GetSpecificItem(2);
                Assert.Equal(item.Name, name2);
            }
        }
        [Fact]
        public async void UpdateItem_Test()
        {
            using (var context = MockDatabaseContext.GetMockDatabaseContext("Item_4"))
            {
                var itemService = new ItemService(context);

                var name1 = "stalas";
                var item1 = new Item { Name = name1 };

                var name2 = "kede";
                item1.Name = name2;

                await itemService.InsertItem(item1);
                await itemService.UpdateItem(1, item1);
                Item item = await itemService.GetSpecificItem(1);
                Assert.Equal(item.Name, name2);
            }

        }
        [Fact]
        public async void GetUserPostedItems_ById_Test()
        {
            using (var context = MockDatabaseContext.GetMockDatabaseContext("Item_5"))
            {
                var itemService = new ItemService(context);

                var name1 = "stalas";
                var p_id1 = 1;
                var item1 = new Item { Name = name1, PosterId = p_id1 };

                var name2 = "kede";
                var p_id2 = 2;
                var item2 = new Item { Name = name2, PosterId = p_id2 };

                await itemService.InsertItem(item1);
                await itemService.InsertItem(item2);

                List<Item> items = (await itemService.GetUserPostedItems(p_id2)).ToList();;
                Assert.Equal(items[0].Name, name2);
            }

        }
        
    }
}
