using PizzaProject2.Models.Database;
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
    }
}