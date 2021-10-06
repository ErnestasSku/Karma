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
    }
}