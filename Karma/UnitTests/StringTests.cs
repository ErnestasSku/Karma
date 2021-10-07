using NUnit.Framework;
using BusinessLogic;
using BusinessLogic.Utils;

namespace UnitTests
{
    public class StringTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LevenshteinDistance1()
        {
            string first = "climax";
            string second = "volmax";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 3);
        }

        [Test]
        public void LevenshteinDistance2()
        {
            string first = "Ram";
            string second = "Raman";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 2);
        }

        [Test]
        public void LevenshteinDistance3()
        {
            string first = "kitten";
            string second = "sitten";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 1);
        }

    }
}
