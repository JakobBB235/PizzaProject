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

        public List<GraphDataViewModel> ConvertToViewModels()
        {
            List<GraphDataViewModel> viewModels = new List<GraphDataViewModel>(); //Init list to return
            List<OrderItem> orderItems = _orderItemService.GetAllOrderItems(); //Get all orderItems

            foreach (var item in orderItems)
            {
                if (viewModels.Count == 0)
                { 
                    viewModels.Add(new GraphDataViewModel(item.PizzaId.ToString(), 1)); //Add new viewmodel if list is empty to avoid nullpointer exception
                    continue;
                }
                for (int i = 0; i < viewModels.Count; i++)
                {
                    //If pizza does not exist in viewModels, add it to viewModels. i == viewModels.count-1 to ensure list has been checked
                    if (i == viewModels.Count - 1 && item.PizzaId.ToString() != viewModels[i].Pizza)
                    {
                        viewModels.Add(new GraphDataViewModel(item.PizzaId.ToString(), 1)); 
                        break; //Remove?
                    }

                    //If the pizza exists in viewModels, add 1 to amount
                    if (item.PizzaId.ToString() == viewModels[i].Pizza) // else if without break?
                    {
                        viewModels[i].Amount = viewModels[i].Amount + 1;
                        break; //Remove?
                    }
                }
            }
            List<GraphDataViewModel> viewModelsWithCorrectNr = _pizzaService.ReplacePizzaIdWithPizzaNr(viewModels);
            return viewModelsWithCorrectNr;
        }
    }
}