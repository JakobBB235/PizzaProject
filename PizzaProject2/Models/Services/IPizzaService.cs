using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject2.Models.Services
{
    interface IPizzaService
    {
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        void DeletePizzaById(int id);
        void InsertAllPizzas(List<Pizza> pizzas);
        void CreatePizza(Pizza newPizza);
        //void DeleteAllPizzas();
        void EditPizza(Pizza updatedPizza);
    }
}
