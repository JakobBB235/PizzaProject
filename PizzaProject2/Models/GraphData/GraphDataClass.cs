using PizzaProject2.Models.Database;
using PizzaProject2.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaProject2.Models.GraphData
{
    public class GraphDataClass
    {
        private OrderItemService _orderItemService = new OrderItemService();
        private PizzaService _pizzaService = new PizzaService();
    
        public List<GraphDataViewModel> GetGraphDataViewModels()
        {  
            List<GraphDataViewModel> viewModels = new List<GraphDataViewModel>(); //Init list to return
            List<OrderItem> orderItems = _orderItemService.GetAllOrderItems(); //Get all orderItems
            List<Pizza> allPizzas = _pizzaService.GetAllPizzas(); //Get all pizzas
            DataClasses1DataContext _dbContext = new DataClasses1DataContext();

            foreach (var item in allPizzas)
            {
                try { 
                    int amount = (from p in _dbContext.OrderItems where p.PizzaId == item.Id select p).Sum(x => x.Amount);
                    if (amount > 0) {
                        viewModels.Add(new GraphDataViewModel(item.Nr.ToString(), amount));
                    }
                }
                catch(InvalidOperationException e)
                {

                }
            }
            
            return viewModels;
        }
    }
}