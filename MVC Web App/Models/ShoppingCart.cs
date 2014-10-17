using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Web_App.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;

        public ShoppingCart(IValueCalculator calcParameter)
        {
            calc = calcParameter;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}