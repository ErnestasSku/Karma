using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Utils;

namespace UnitTests
{
    class ItemClassTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        public List<Item> GetMockItems1()
        {
            List<Item> mockList = new List<Item>();

            mockList.Add(new Item() { Name = "Second", Date = DateTime.Parse("2018-09-19")});
            mockList.Add(new Item() { Name = "First", Date = DateTime.Parse("2017-09-19")});
            mockList.Add(new Item() { Name = "Fourth", Date = DateTime.Parse("2020-09-19")});
            mockList.Add(new Item() { Name = "Third", Date = DateTime.Parse("2019-09-19")});

            return mockList;
        }

        [Test]
        public void ItemSort1()
        {
            List<Item> mockList = GetMockItems1();
            mockList.SortItems(Item.SortType.Name);

            List<string> sortedList = new List<string>();
            sortedList.Add("First");
            sortedList.Add("Fourth");
            sortedList.Add("Second");
            sortedList.Add("Third");

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (!sortedList[i].Equals(mockList[i].Name))
                    Assert.Fail();
            }
            Assert.Pass();

        }

        [Test]
        public void ItemSort2()
        {
            List<Item> mockList = GetMockItems1();
            mockList.SortItems(Item.SortType.Name);

            List<string> sortedList = new List<string>();
            sortedList.Add("Fourth");
            sortedList.Add("First");
            sortedList.Add("Third");
            sortedList.Add("Second");

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i].Equals(mockList[i].Name))
                    Assert.Fail();
            }
            Assert.Pass();

        }

        [Test]
        public void ItemSort3()
        {
            List<Item> mockList = GetMockItems1();
            mockList.SortItems(Item.SortType.Date);

            List<DateTime> sortedList = new List<DateTime>();
            sortedList.Add(DateTime.Parse("2017-09-19"));
            sortedList.Add(DateTime.Parse("2018-09-19"));
            sortedList.Add(DateTime.Parse("2019-09-19"));
            sortedList.Add(DateTime.Parse("2020-09-19"));

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (!sortedList[i].Equals(mockList[i].Date))
                    Assert.Fail();
            }
            Assert.Pass();

        }

        [Test]
        public void ItemSort4()
        {
            List<Item> mockList = GetMockItems1();
            mockList.SortItems(Item.SortType.Date);

            List<DateTime> sortedList = new List<DateTime>();
            sortedList.Add(DateTime.Parse("2018-09-19"));
            sortedList.Add(DateTime.Parse("2017-09-19"));
            sortedList.Add(DateTime.Parse("2020-09-19"));
            sortedList.Add(DateTime.Parse("2019-09-19"));

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i].Equals(mockList[i].Date))
                    Assert.Fail();
            }
            Assert.Pass();

        }

    }
}
