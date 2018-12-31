using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models
{
    public class OrderItemViewModel
    {
        //public int pizzaNr { get; set; }
        //public int orderId { get; set; }

        //public OrderItemViewModel(int pizzaNr, int orderId)
        //{
        //    this.pizzaNr = pizzaNr;
        //    this.orderId = orderId;
        //}

        public Pizza ThePizza { get; set; }
        public int Amount { get; set; } //Represents how many of the same pizza has been ordered
        //public double TotalSumPrice { get; set; }

        public OrderItemViewModel(Pizza thePizza, int amount)
        {
            ThePizza = thePizza;
            Amount = amount;
        }

        public OrderItemViewModel()
        {

        }
    }
}