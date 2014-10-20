using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Web_App.Models;
using System.Collections.Generic;
using Moq;

namespace MVC_Web_App.Tests
{
    [TestClass]
    public class ProductTests
    {
        private Product[] products = {
        new Product {Name = "Kayak", Category = "Watersports", Price =
        275M},
        new Product {Name = "Lifejacket", Category = "Watersports",
        Price = 48.95M},
        new Product {Name = "Soccer ball", Category = "Soccer", Price
        = 19.50M},
        new Product {Name = "Corner flag", Category = "Soccer", Price
        = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);

            var target = new LinqValueCalculator(mock.Object);

            Assert.IsNotNull(target);
        }
    }
}
