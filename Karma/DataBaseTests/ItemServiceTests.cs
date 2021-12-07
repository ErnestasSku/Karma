using Xunit;
using DataBase.Models;
using DataBase.Services;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseTests
{
    public class ItemServiceTests
    {
        
        [Fact]
        public async void InsertItem_GetAllItems_Test()
        {
            var mockSet = new Mock<DbSet<Item>>();
            
            var mock = new Mock<MockDatabaseContext>();
            mock.Setup(m => m.Items).Returns(mockSet.Object);
            
            var itemService = new ItemService(mock.Object);

            var name1 = "stalas";
            var item1 = new Item { Name = name1 };

            var name2 = "kede";
            var item2 = new Item { Name = name2 };

            await itemService.InsertItem(item1);
            await itemService.InsertItem(item2);

            //You can verify if the data was added at least one with this method,
            //user other similar methods for more accuracity
            mockSet.Verify(m => m.Add(It.IsAny<Item>()), Times.AtLeastOnce());
            //In this example IQuerrable is not setup, so GetAllItems won't work at the moment
            /*List<Item> items = await itemService.GetAllItems();
            Assert.Equal(items[0].Name, name1);
            Assert.Equal(items[1].Name, name2);*/
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
        [Fact]
        public async void UpdateItem_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

            var name1 = "stalas";
            var item1 = new Item { Name = name1 };

            var name2 = "kede";
            var item2 = new Item { Name = name2 };

            await itemService.InsertItem(item1);
            await itemService.UpdateItem(1, item2);
            Item item = await itemService.GetSpecificItem(1);
            Assert.Equal(item.Name, name2);
        }
        [Fact]
        public async void GetUserPostedItems_ById_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

            var name1 = "stalas";
            var p_id1 = 1;
            var item1 = new Item { Name = name1, PosterId = p_id1 };

            var name2 = "kede";
            var p_id2 = 2;
            var item2 = new Item { Name = name2, PosterId = p_id2 };

            await itemService.InsertItem(item1);
            await itemService.InsertItem(item2);

            IEnumerable<Item> items = await itemService.GetUserPostedItems(p_id2);
            var enumerator = items.GetEnumerator();
            Assert.Equal(enumerator.Current.Name, name2);
        }
        [Fact]
        public async void GetUserPostedItems_ByUsername_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var itemService = new ItemService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            var name1 = "stalas";
            var item1 = new Item { Name = name1, Poster = poster1 };

            var name2 = "kede";
            var item2 = new Item { Name = name2, Poster = poster2 };

            await itemService.InsertItem(item1);
            await itemService.InsertItem(item2);

            List<Item> items = await itemService.GetUserPostedItems(username2);
            Assert.Equal(items[0].Name, name2);
        }
    }
}
