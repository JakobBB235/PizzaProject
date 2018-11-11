using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models
{
    public class OrderViewModel
    {
        public List<Order> orders { get; set; }
        //public List<OrderItem> orderItems { get; set; }
        //public List<Pizza> pizzas { get; set; }
        public List<OrderItemViewModel> orderItemViewModels { get; set; }

        public OrderViewModel(List<Order> orders, List<OrderItemViewModel> orderItemViewModels)
        {
            this.orders = orders;
            this.orderItemViewModels = orderItemViewModels;
        }

        //public OrderViewModel(List<Order> orders, List<Pizza> pizzas)
        //{
        //    this.orders = orders;
        //    this.pizzas = pizzas;
        //}

        //public OrderViewModel(List<Order> orders, List<OrderItem> orderItems)
        //{
        //    this.orders = orders;
        //    this.orderItems = orderItems;
        //}

    }
}