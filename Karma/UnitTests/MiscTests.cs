using NUnit.Framework;
using BusinessLogic;
using BusinessLogic.Utils;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemsToDB()
        {
            var itemDB = ItemData.GetData();
            var mockData =  "Test,Test,test".Split(',');
            for (int i = 0; i < 5; i++)
                itemDB.AddData (new Item (mockData));

            Assert.IsTrue(itemDB.ItemList.Count == 5);
           
        }

        [Test]
        public void LoggerTest()
        {
            Logger.Error("Test Error");
            Logger.Warning("Test Warning");
            Logger.Info("Test Info");
        }

        [Test]
        public void UserIndexedTest()
        {
            UserIndexed users = new UserIndexed();
            users[0] = new User("aaa", "bbb", "ccc", "111");
            users[50] = new User("ddd", "eee", "fff", "222");
            Assert.IsTrue
            (
                ("aaabbbccc111" == users[0].Name + users[0].LastName + users[0].UserName + users[0].Password) &&
                ("dddeeefff222" == users[50].Name + users[50].LastName + users[50].UserName + users[50].Password)
            );
        }
    }
}