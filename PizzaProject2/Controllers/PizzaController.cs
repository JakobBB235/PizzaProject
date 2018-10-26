using PizzaProject2.Models.Database;
using PizzaProject2.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaProject2.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaService _pizzaService = new PizzaService();

        // GET: Pizza
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPizza(int id)
        {
            var thePizza = _pizzaService.GetPizzaById(id);
            return View(thePizza);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPizza(Pizza updatedPizza)
        {
            //_pizzaService.EditPizza(updatedPizza);
            //return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                _pizzaService.EditPizza(updatedPizza);
                return RedirectToAction("Index", "Home");
            }
            else
                return View(updatedPizza);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult DeletePizza(int id)
        {
            _pizzaService.DeletePizzaById(id);   
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ResetPizzaMenu()
        {
            _pizzaService.ResetPizzaList();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePizza()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePizza(Pizza newPizza)
        {
            if (ModelState.IsValid)
            {
                _pizzaService.CreatePizza(newPizza);
                //return View();
                //return View(newPizza);
                return RedirectToAction("Index", "Home");
            }
            else
                return View(newPizza);
                //return View();
        }
    }
}