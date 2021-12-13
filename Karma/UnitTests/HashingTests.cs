using NUnit.Framework;
using Backend.Utils;
namespace UnitTests
{
    public class HashingTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void HashingSameLogIn()
        {
            var salt = HashingUtilities.CreateSalt(4);
            var password = "ABC";
            var hash = HashingUtilities.GenerateSHA256Hash(password, salt);
            Assert.IsTrue(hash == HashingUtilities.GenerateSHA256Hash(password, salt));
        }
        [Test]
        public void HashingSamePassword()
        {
            var salt1 = HashingUtilities.CreateSalt(4);
            var salt2 = HashingUtilities.CreateSalt(4);
            var password = "ABC";
            Assert.IsTrue(HashingUtilities.GenerateSHA256Hash(password, salt1) != HashingUtilities.GenerateSHA256Hash(password, salt2));
        }
        [Test]
        public void HashingSameSalt()
        {
            var salt = HashingUtilities.CreateSalt(4);
            var password1 = "ABC";
            var password2 = "abc";
            Assert.IsTrue(HashingUtilities.GenerateSHA256Hash(password1, salt) != HashingUtilities.GenerateSHA256Hash(password2, salt));
        }
    }
}
