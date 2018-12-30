using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PizzaProject2.Models;
using PizzaProject2.Models.Database;
using PizzaProject2.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PizzaProject2.Controllers
{
    public class OrderController : Controller
    {
        private PizzaService _pizzaService = new PizzaService();
        private OrderService _orderService = new OrderService();
        private OrderItemService _orderItemService = new OrderItemService();

        //Create partial view for the shoppingcart
        public PartialViewResult PartialShoppingCartLoad() 
        {
            //List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            //return PartialView("_ShoppingCart", sessionPizzas);

            List<OrderItemViewModel> sessionPizzas = (List<OrderItemViewModel>)Session["Cart"];
            return PartialView("_ShoppingCart", sessionPizzas);
        }

        //Add pizza to the partial view for the shoppingcart
        public PartialViewResult PartialShoppingCartAddPizza(int id)
        {
            var thePizza = _pizzaService.GetPizzaById(id);
            //List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            //sessionPizzas.Add(thePizza);
            List<OrderItemViewModel> sessionPizzas = (List<OrderItemViewModel>)Session["Cart"];
            //foreach(OrderItemViewModel item in sessionPizzas)
            //{
            //    if(item.ThePizza == thePizza) //If this does not work check id instead
            //    {
            //        item.Amount++;
            //        break;
            //    }
            //    else if ()
            //    {
            //        sessionPizzas.Add(new OrderItemViewModel() { ThePizza = thePizza, Amount = 1 });
            //        break;
            //    }
            //}

            for (int i = 0; i <= sessionPizzas.Count; i++)
            {

                if (i == sessionPizzas.Count)
                {
                    sessionPizzas.Add(new OrderItemViewModel() { ThePizza = thePizza, Amount = 1 });
                    break;
                }
                if (sessionPizzas[i].ThePizza.Id == thePizza.Id) //If this does not work check id instead
                {
                    sessionPizzas[i].Amount++;
                    break;
                }    
               
            }

            return PartialView("_ShoppingCart", sessionPizzas);
        }

        //public ActionResult RemovePizzaFromOrder()
        //{

        //}

        public ActionResult ShoppingCart()
        {
            List<OrderItemViewModel> sessionPizzas = (List<OrderItemViewModel>)Session["Cart"];
            return View(sessionPizzas);
        }

        //User can pay after adding items to shoppingcart. FIX USERID RELATIONS?
        public ActionResult Pay()
        {
            List<OrderItemViewModel> sessionPizzas = (List<OrderItemViewModel>)Session["Cart"];
            //int userId = 0;
            String userId = "None";

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            if(user != null)
                userId = user.Id;

            _orderService.PayCreateOrder(sessionPizzas, userId);
            sessionPizzas.Clear(); //Clears list
            Session["Cart"] = sessionPizzas; //Clears session

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewOrders()
        {
            var orders = _orderService.GetAllOrders(); //get active orders from DB

            //Convert to view models
            //List<OrderItemViewModel> orderItemViewModels = _orderItemService.CovertOrderItemToViewModel(orders);
            //OrderViewModel orderViewModel = new OrderViewModel(orders, orderItemViewModels);

            //List<OrderItemViewModel> orderItemViewModels = _orderItemService.CovertOrderItemToViewModel(orders);
            //List<OrderViewModel> orderViewModels = new OrderViewModel(orders, orderItemViewModels);

            //List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            //foreach (Order order in orders) {
            //    List<OrderItemViewModel> orderItemViewModels = _orderItemService.GetOrderItemViewModels(order);
            //    orderViewModels.Add(new OrderViewModel() { order = order, orderItemViewModels = orderItemViewModels });
            //}
            List<OrderViewModel> orderViewModels = _orderService.ConvertOrderToOrderViewModel(orders);

            return View(orderViewModels);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EndOrder(int id) //Don't use get?
        {
            _orderService.EndOrder(id);
            return RedirectToAction("ViewOrders", "Order");
        }
    }
}