using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bilbo";
            //-- Act
            string actual = customer.FullName;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.LastName = "Baggins";
            string expected = "Baggins";
            //-- Act
            string actual = customer.FullName;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            string expected = "Bilbo";
            //-- Act
            string actual = customer.FullName;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            var c1 = new Customer();
            c1.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Rosie";
            Customer.InstanceCount += 1;

            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            var customer = new Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "b@baggins.com";

            var expected = true;

            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            var customer = new Customer();
            customer.EmailAddress = "B@baggins.com";

            var expected = false;

            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingEmailAddress()
        {
            var customer = new Customer();
            customer.LastName = "Baggins";

            var expected = false;

            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);
        }
    }
}
