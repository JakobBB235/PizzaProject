using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models
{
    public class OrderItemViewModel
    {
        public int pizzaNr { get; set; }
        public int orderId { get; set; }

        public OrderItemViewModel(int pizzaNr, int orderId)
        {
            this.pizzaNr = pizzaNr;
            this.orderId = orderId;
        }

        public OrderItemViewModel()
        {
        }
    }
}