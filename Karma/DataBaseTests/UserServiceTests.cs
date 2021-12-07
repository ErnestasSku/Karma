using Xunit;
using DataBase.Models;
using DataBase.Services;
using Moq;
using System.Collections.Generic;

namespace DataBaseTests
{
    public class UserServiceTests
    {
        [Fact]
        public async void InsertUser_GetUsers_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var userService = new UserService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            await userService.InsertUser(poster1);
            await userService.InsertUser(poster2);

            List<User> users = await userService.GetUsers();
            Assert.Equal(users[0].Username, username1);
            Assert.Equal(users[0].Username, username2);
        }
        [Fact]
        public async void GetUserById_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var userService = new UserService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            await userService.InsertUser(poster1);
            await userService.InsertUser(poster2);

            User user = await userService.GetUserById(2);
            Assert.Equal(user.Username, username2);
        }
        [Fact]
        public async void GetUserByUsername_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var userService = new UserService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            await userService.InsertUser(poster1);
            await userService.InsertUser(poster2);

            User user = await userService.GetUserByUsername(username2);
            Assert.Equal(user.Username, username2);
        }
        [Fact]
        public async void UpdateUser_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var userService = new UserService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            await userService.InsertUser(poster1);
            await userService.UpdateUser(1, poster2);

            User user = await userService.GetUserById(1);
            Assert.Equal(user.Username, username2);
        }
        [Fact]
        public async void DeleteUser_Test()
        {
            var mock = new Mock<IDatabaseContext>();
            var userService = new UserService(mock.Object);

            var username1 = "Jonas";
            var poster1 = new User { Username = username1 };

            var username2 = "Pranas";
            var poster2 = new User { Username = username2 };

            await userService.InsertUser(poster1);
            await userService.InsertUser(poster2);
            await userService.DeleteUser(1);

            List<User> users = await userService.GetUsers();
            Assert.Equal(users[0].Username, username2);
        }
    }
}