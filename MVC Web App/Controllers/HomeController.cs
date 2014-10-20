using MVC_Web_App.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web_App.Controllers
{
    public class HomeController : Controller
    {
        Product[] products = {new Product{Name = "Kayak", Price=275M},
                                  new Product{Name = "Life jacket",Price=48.96M},
                                  new Product{Name = "Soccerball", Price=19.50M},
                                  new Product{Name = "Corner", Price=34.95M}
                              };

        Product myProduct = new Product { 
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        IValueCalculator calc;

        // GET: Home
        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            return View(products);
        }

        //old way without dependency injection
        public ActionResult Calculations()
        {
            //IValueCalculator calc = new LinqValueCalculator();
            //ShoppingCart cart = new ShoppingCart(calc) { Products = products};
            //decimal totalValue = cart.CalculateProductTotal();
            //return View(totalValue);
            return View();
        }

        //new method using dependancy injection
        public ActionResult CalculationsDI()
        {
            IKernel ninject = new StandardKernel();
            ninject.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = ninject.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }

        //Added a Ninject DependancyResolver class to the Models folder
        //This will bind the IValueCalculator to the LinqValueCalculator
        //also added a bit of code to instantiate the dependency resolver
        //A default constructor is added
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult CalcualateDIWithResolver()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}