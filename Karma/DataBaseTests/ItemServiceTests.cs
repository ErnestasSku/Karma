using Xunit;
using DataBase.Models;
using DataBase.Services;
using Moq;
using System.Collections.Generic;

namespace DataBaseTests
{
    public class ItemServiceTests
    {
        
        [Fact]
        public async void InsertItem_GetAllItems_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

            var name1 = "stalas";
            var item1 = new Item { Name = name1 };

            var name2 = "kede";
            var item2 = new Item { Name = name2 };

            await itemService.InsertItem(item1);
            await itemService.InsertItem(item2);

            List<Item> items = await itemService.GetAllItems();
            Assert.Equal(items[0].Name, name1);
            Assert.Equal(items[1].Name, name2);
        }
        [Fact]
        public async void DeleteItem_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

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
        [Fact]
        public async void GetSpecificItem_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

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
}
