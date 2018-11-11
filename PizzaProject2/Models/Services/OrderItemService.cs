using PizzaProject2.Models.Database;
using PizzaProject2.Models.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models.Services
{
    public class OrderItemService : IOrderItemService
    {
        private DataClasses1DataContext _dbContext = new DataClasses1DataContext();

        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> allOrderItems = (from p in _dbContext.OrderItems select p).ToList();
            return allOrderItems;
        }

        public List<OrderItemViewModel> CovertOrderItemToViewModel(List<Order> orders) 
        {
            List<OrderItem> orderItems = GetActiveOrderItems(orders);
            List<OrderItemViewModel> orderItemViewModels = new List<OrderItemViewModel>();

            PizzaService pizzaService = new PizzaService();
            List<Pizza> pizzas = new List<Pizza>();
            foreach (OrderItem item in orderItems)
            {
                Pizza pizza = pizzaService.GetPizzaById(item.PizzaId);
                orderItemViewModels.Add(new OrderItemViewModel() { pizzaNr = pizza.Nr, orderId = item.OrderId });
            }

            return orderItemViewModels;
        }

        public List<OrderItem> GetActiveOrderItems(List<Order> orders)
        {
            List<int> orderIdList = new List<int>();
            foreach (Order item in orders)
            {
                orderIdList.Add(item.Id);
            }
            List<OrderItem> orderItems = _dbContext.OrderItems.Where(x => orderIdList.Contains(x.OrderId)).ToList();

            return orderItems;
        }
    }
}