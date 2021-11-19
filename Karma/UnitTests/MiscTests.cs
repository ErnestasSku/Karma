using NUnit.Framework;
using Backend.Utils;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

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