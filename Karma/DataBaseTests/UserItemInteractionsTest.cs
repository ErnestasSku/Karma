using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Services;
using DataBase.Models;

namespace DataBaseTests
{
    public class UserItemInteractionsTest
    {

        //TODO: create a method which fills a mock database with data then test the services.

        //[Fact]
        public async void GetUserPostedItems_ByUsername_Test()
        {
            using (var context = MockDatabaseContext.GetMockDatabaseContext("UserItem_1"))
            {
                //Data is used wrongly, therefore it doesn't work
                //Note, the foreign key needs to be set before data can be querried.
                var itemService = new ItemService(context);
                var userService = new UserService(context);

                var username1 = "Jonas";
                var poster1 = new User { Username = username1 };
                await userService.InsertUser(poster1);

                var username2 = "Pranas";
                var poster2 = new User { Username = username2};
                await userService.InsertUser(poster2);

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
}
