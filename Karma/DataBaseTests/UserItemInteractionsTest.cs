using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Services;
using DataBase.Models;
using Database.Models;
using Database.Services;

namespace DataBaseTests
{
    public class UserItemInteractionsTest
    {

        //TODO: create a method which fills a mock database with data then test the services.


        public static void FillContextWithData(IDatabaseContext context)
        {
            var users = new List<User>
            {
                new User {Username = "User1"},
                new User {Username = "User2"},
                new User {Username = "User3"},
                new User {Username = "User4"}
            };

            var items = new List<Item>
            {
                new Item {Name = "Item1", Poster = users[0], PosterId = 1},
                new Item {Name = "Item2", Poster = users[0], PosterId = 1},
                new Item {Name = "Item3", Poster = users[0], PosterId = 1},
                new Item {Name = "Item4", Poster = users[1], PosterId = 2},
                new Item {Name = "Item5", Poster = users[1], PosterId = 2},
                new Item {Name = "Item6", Poster = users[1], PosterId = 2},
                new Item {Name = "Item7", Poster = users[1], PosterId = 2},
                new Item {Name = "Item8", Poster = users[2], PosterId = 3},
                new Item {Name = "Item9", Poster = users[3], PosterId = 4},
                new Item {Name = "Item10", Poster = users[3], PosterId = 4},
            };

            var userTakenItem = new List<UserTakenItem>
            {
                new UserTakenItem {User = users[2], UserId = users[2].UserId, Item = items[0], ItemId = items[0].ItemId },
                new UserTakenItem {User = users[2], UserId = users[2].UserId, Item = items[1], ItemId = items[1].ItemId },
                new UserTakenItem {User = users[2], UserId = users[2].UserId, Item = items[2], ItemId = items[2].ItemId },
                new UserTakenItem {User = users[0], UserId = users[0].UserId, Item = items[3], ItemId = items[3].ItemId },
                new UserTakenItem {User = users[0], UserId = users[0].UserId, Item = items[4], ItemId = items[4].ItemId },
                new UserTakenItem {User = users[1], UserId = users[1].UserId, Item = items[5], ItemId = items[5].ItemId },
            };

            foreach(var i in users)
            {
                context.Users.Add(i);
            }
            foreach (var i in items)
            {
                context.Items.Add(i);
            }
            foreach (var i in userTakenItem)
            {
                context.UserTakenItems.Add(i);
            }
            context.SaveChanges();
        }

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

        [Fact]
        public void Test()
        {
            using (var context = MockDatabaseContext.GetMockDatabaseContext("UTI1"))
            {
                FillContextWithData(context);
                var statisticsService = new StatisticsService(context);
                statisticsService.GetCount();
                statisticsService.GetTakenItemDetails();
            }
        }

    }
}
