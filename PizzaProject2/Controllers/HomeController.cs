using PizzaProject2.Models.Database;
using PizzaProject2.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaProject2.Controllers
{
    public class HomeController : Controller
    {
        private PizzaService _pizzaService = new PizzaService();

        public ActionResult Index()
        {
            Console.WriteLine("Hej");
            var pizzas = _pizzaService.GetAllPizzas();
            if (pizzas != null)
                return View(pizzas);
            else
                return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminMenu() {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}