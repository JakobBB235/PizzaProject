using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models.Services
{
    public class OrderService : IOrderService
    {
        private DataClasses1DataContext _dbContext = new DataClasses1DataContext();

        public void EndOrder(int orderId) 
        {
            Order orderDB = GetOrderById(orderId); // Find order in DB
            orderDB.IsActive = false; //Stored as bit in DB, only accepts boolean values here.
            _dbContext.SubmitChanges();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> allOrders = (from p in _dbContext.Orders where p.IsActive select p).ToList();
            return allOrders;
        }

        public Order GetOrderById(int orderId)
        {
            Order order = _dbContext.Orders.First(g => g.Id == orderId);
            return order;
        }

        public void PayCreateOrder(List<OrderItemViewModel> sessionPizzas, String userId) 
        {
            if (sessionPizzas.Count > 0)
            {
                Order order = new Order();
                order.DateTimeCreated = DateTime.UtcNow.ToString(); 
                order.IsActive = true; //Set order active to true
                order.UserId = userId;//Set UserId

                _dbContext.Orders.InsertOnSubmit(order);
                _dbContext.SubmitChanges();

                List<OrderItem> orderItems = new List<OrderItem>();
                for (int i = 0; i < sessionPizzas.Count; i++)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = order.Id;
                    orderItem.PizzaId = sessionPizzas[i].ThePizza.Id;
                    orderItem.Amount = sessionPizzas[i].Amount;
                    orderItems.Add(orderItem);
                }

                _dbContext.OrderItems.InsertAllOnSubmit(orderItems);
                _dbContext.SubmitChanges();
            }
        }

        public List<OrderViewModel> ConvertOrderToOrderViewModel(List<Order> orders)
        {
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            OrderItemService orderItemService = new OrderItemService();
            foreach (Order order in orders)
            {
                List<OrderItemViewModel> orderItemViewModels = orderItemService.GetOrderItemViewModels(order);
                orderViewModels.Add(new OrderViewModel() { order = order, orderItemViewModels = orderItemViewModels });
            }

            return orderViewModels;
        }
    }
}