using NUnit.Framework;
using BusinessLogic;
using BusinessLogic.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace UnitTests
{
    public class StringTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCategory("StringDistance")]
        public void LevenshteinDistance1()
        {
            string first = "climax";
            string second = "volmax";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 3);
        }

        [Test]
        [TestCategory("StringDistance")]
        public void LevenshteinDistance2()
        {
            string first = "Ram";
            string second = "Raman";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 2);
        }

        [Test]
        [TestCategory("StringDistance")]
        public void LevenshteinDistance3()
        {
            string first = "kitten";
            string second = "sitten";

            int dist = first.LevenshteinDistance(second);
            Assert.IsTrue(dist == 1);
        }

        [Test]
        [TestCategory("Email")]
        public void isEmail1()
        {
            string mockEmail = "example@email.com";

            Assert.IsTrue(ValidationUtils.isEmail(mockEmail));
        }

        [Test]
        [TestCategory("Email")]
        public void isEmail2()
        {
            string mockEmail = "Name.lastName123@email.com";

            Assert.IsTrue(ValidationUtils.isEmail(mockEmail));
        }

        [Test]
        [TestCategory("Email")]
        public void isEmail3()
        {
            string mockEmail = "notAnEmail.com";

            Assert.IsFalse(ValidationUtils.isEmail(mockEmail));
        }

        [Test]
        [TestCategory("PhoneNumber")]
        public void IsPhoneNumber1()
        {
            string mockPhoneNumber = "86123456";

            Assert.IsTrue(ValidationUtils.isPhoneNumber(mockPhoneNumber));
        }

        [Test]
        [TestCategory("PhoneNumber")]
        public void IsPhoneNumber2()
        {
            string mockPhoneNumber = "+370123456";

            Assert.IsTrue(ValidationUtils.isPhoneNumber(mockPhoneNumber));
        }

        [Test]
        [TestCategory("PhoneNumber")]
        public void IsPhoneNumber3()
        {
            string mockPhoneNumber = "notphonenumber";

            Assert.IsFalse(ValidationUtils.isPhoneNumber(mockPhoneNumber));
        }

        [Test]
        [TestCategory("Password")]
        public void IsPassword1()
        {
            string mockPassword = "Password123!@#";

            Assert.IsTrue(ValidationUtils.isPassword(mockPassword));
        }

        [Test]
        [TestCategory("Password")]
        public void IsPassword2()
        {
            string mockPassword = "short";

            Assert.IsFalse(ValidationUtils.isPassword(mockPassword));
        }


    }
}
