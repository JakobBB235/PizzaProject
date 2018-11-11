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

        // GET: Order
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public PartialViewResult PartialShoppingCartLoad() //ShoppingCart
        {
            List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            return PartialView("_ShoppingCart", sessionPizzas);
        }

        //Create partial view file
        public PartialViewResult PartialShoppingCartAddPizza(int id) //ShoppingCart
        {
            var thePizza = _pizzaService.GetPizzaById(id);
            List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            sessionPizzas.Add(thePizza);

            return PartialView("_ShoppingCart", sessionPizzas);
        }

        public ActionResult ShoppingCart()
        {
            List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            return View(sessionPizzas);
        }

        public ActionResult Pay()
        {
            List<Pizza> sessionPizzas = (List<Pizza>)Session["Cart"];
            int userId = 0;

            //NEW
            //var currentUser = Membership.GetUser(User.Identity.Name);
            //string username = currentUser.UserName; //** get UserName
            //Guid userId = (Guid)currentUser.ProviderUserKey; //** get user ID

            //var user = UserManager.FindById(User.Identity.GetUserId());

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //int userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString()); //working?

            try
            {
                //userId = Convert.ToInt32(User.Identity.GetUserId());//Try to get user id. does not work
                //userId = Convert.ToInt32(currentUser.ProviderUserKey.ToString());

                userId = Convert.ToInt32(user.Id);
                //System.Web.HttpContext.Current.User.Identity.Name
            }
            catch {

            }
            _orderService.PayCreateOrder(sessionPizzas, userId);
            sessionPizzas.Clear(); //Clears list
            Session["Cart"] = sessionPizzas; //Clears session

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewOrders()
        {
            var orders = _orderService.GetAllOrders(); //get active orders from DB
            //var orderItems = _orderItemService.GetAllOrderItems(); //get all orderItems from DB

            //NEW  
            //List<Pizza> pizzaList = _orderItemService.CovertOrderItemToPizza(orderItems);//Covert orderitems to pizzas
            //OrderViewModel orderViewModel = new OrderViewModel(orders, pizzaList);
            List<OrderItemViewModel> orderItemViewModels = _orderItemService.CovertOrderItemToViewModel(orders);
            OrderViewModel orderViewModel = new OrderViewModel(orders, orderItemViewModels);

            //OrderViewModel orderViewModel = new OrderViewModel(orders, orderItems);
            return View(orderViewModel); //return lists by using a view model. 
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EndOrder(int id) //Don't use get?
        {
            _orderService.EndOrder(id);
            return RedirectToAction("ViewOrders", "Home");
        }
    }
}