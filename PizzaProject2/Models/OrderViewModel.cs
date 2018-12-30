using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models
{
    public class OrderViewModel
    {
        //public List<Order> orders { get; set; }
        //public List<OrderItemViewModel> orderItemViewModels { get; set; }

        //public OrderViewModel(List<Order> orders, List<OrderItemViewModel> orderItemViewModels)
        //{
        //    this.orders = orders;
        //    this.orderItemViewModels = orderItemViewModels;
        //}
        public Order order { get; set; }
        public List<OrderItemViewModel> orderItemViewModels { get; set; }

        public OrderViewModel(Order order, List<OrderItemViewModel> orderItemViewModels)
        {
            this.order = order;
            this.orderItemViewModels = orderItemViewModels;
        }

        public OrderViewModel()
        {
        }
    }
}