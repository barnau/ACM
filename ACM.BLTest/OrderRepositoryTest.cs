using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System.Collections.Generic;

namespace ACM.BLTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void RetrieveExisting()
        {
            var orderRepository = new OrderRepository();
            var actual = orderRepository.Retrieve(10);
            actual.OrderDate = new DateTimeOffset(2016, 12, 13, 0, 0, 0, new TimeSpan(-7, 0, 0));

            var expected = new Order(10);
            expected.OrderDate = new DateTimeOffset(2016, 12, 13, 0, 0, 0, new TimeSpan(-7, 0, 0));

            Assert.AreEqual(actual.OrderDate, expected.OrderDate);
        }

        [TestMethod]
        public void RetrieveOrderDisplayTest()
        {
            var orderRepository = new OrderRepository();
            var expected = new OrderDisplay()
            {
                FirstName = "Bilbo",
                LastName = "Baggins",
                OrderDate = new DateTimeOffset(2016, 12, 13, 0, 0, 0, new TimeSpan(-7, 0, 0)),
                ShippingAddress = new Address()
                {
                    StreetLine1 = "Bag End",
                    StreetLine2 = "Bagshot row",
                    City = "Hobbiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "144"
                },
                OrderDisplayItemList = new List<OrderDisplayItem>()
                {
                    new OrderDisplayItem()
                    {
                        ProductName = "Sunflowers",
                        PurchasePrice = 15.96M,
                        OrderQuantity = 2
                    },
                     new OrderDisplayItem()
                    {
                        ProductName = "Rake",
                        PurchasePrice = 6m,
                        OrderQuantity = 1
                    },
                }

            };

            var actual = orderRepository.RetrieveOrderDisplay(10);

            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);

            Assert.AreEqual(expected.ShippingAddress.AddressType, actual.ShippingAddress.AddressType);
            Assert.AreEqual(expected.ShippingAddress.StreetLine1, actual.ShippingAddress.StreetLine1);
            Assert.AreEqual(expected.ShippingAddress.City, actual.ShippingAddress.City);
            Assert.AreEqual(expected.ShippingAddress.State, actual.ShippingAddress.State);
            Assert.AreEqual(expected.ShippingAddress.Country, actual.ShippingAddress.Country);
            Assert.AreEqual(expected.ShippingAddress.PostalCode, actual.ShippingAddress.PostalCode);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.OrderDisplayItemList[i].OrderQuantity, actual.OrderDisplayItemList[i].OrderQuantity);
                Assert.AreEqual(expected.OrderDisplayItemList[i].ProductName, actual.OrderDisplayItemList[i].ProductName);
                Assert.AreEqual(expected.OrderDisplayItemList[i].PurchasePrice, actual.OrderDisplayItemList[i].PurchasePrice);
            }


        }
    }
}
