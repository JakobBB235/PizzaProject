﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models.GraphData
{
    public class GraphDataViewModel
    {
        public int PizzaNr { get; set; }
        public String Pizza { get; set; }
        public int Amount { get; set; }

        public GraphDataViewModel(String pizza, int amount) //string pizzaName,
        {
            //            PizzaName = pizzaName;
            //            PizzaNr = pizzaNr;
            Pizza = pizza;
            Amount = amount;
        }
    }
}