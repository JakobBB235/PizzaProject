using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models
{
    public class OrderViewModel
    {
        //Make private?
        public List<Order> orders { get; set; }
        public List<OrderItem> orderItems { get; set; }

        public OrderViewModel(List<Order> orders, List<OrderItem> orderItems)
        {
            this.orders = orders;
            this.orderItems = orderItems;
        }
    }
}