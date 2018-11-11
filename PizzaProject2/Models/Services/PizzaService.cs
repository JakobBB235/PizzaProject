using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaProject2.Models.Database;
using PizzaProject2.Models.GraphData;

namespace PizzaProject2.Models.Services
{
    public class PizzaService : IPizzaService
    {
        private DataClasses1DataContext _dbContext = new DataClasses1DataContext();

        private void DeleteAllPizzas(List<Pizza> pizzas)
        {
            try
            {
                _dbContext.Pizzas.DeleteAllOnSubmit(pizzas);
            }
            catch
            {

            }
        }

        public void DeletePizzaById(int id)
        {
            var thePizza = GetPizzaById(id);
            try
            {
                _dbContext.Pizzas.DeleteOnSubmit(thePizza);
                _dbContext.SubmitChanges();
            }
            catch
            {

            }
        }

        public List<Pizza> GetAllPizzas()
        {
            //try
            //{
            //    var pizzas = (from p in _dbContext.Pizzas select p).ToList();
            //    return pizzas;
            //}
            //catch
            //{

            //}
            var pizzas = (from p in _dbContext.Pizzas select p).ToList();
            return pizzas;
        }

        public Pizza GetPizzaById(int id)
        {
            //try
            //{
            //    var thePizza = (from p in _dbContext.Pizzas where p.Id == id select p).First();
            //    return thePizza;
            //}
            //catch
            //{

            //}
            var thePizza = (from p in _dbContext.Pizzas where p.Id == id select p).First();
            return thePizza;
        }

        public void InsertAllPizzas(List<Pizza> pizzas)
        {
            try
            {
                _dbContext.Pizzas.InsertAllOnSubmit(pizzas);
                _dbContext.SubmitChanges();
            }
            catch
            {

            }
        }

        //Deletes all existing pizzas and inserts the 27 default pizzas
        public void ResetPizzaList()
        {
            List<Pizza> defaultPizzas = new List<Pizza>
            {
                new Pizza() { Nr = 1, Name = "Margherita", Toppings = "Tomat, dobbelt ost, oregano", Price = 47},
                new Pizza() { Nr = 2, Name = "Margherita Special", Toppings = "Tomat, ost, mozarellaost, fetaost, gorgonzole, parmasanost, cheddarost, frisk tomat, pesto", Price = 71},
                new Pizza() { Nr = 3, Name = "Vesuvio", Toppings = "Tomat, ost, skinke", Price = 55},
                new Pizza() { Nr = 4, Name = "Pepperoni", Toppings = "Tomat, ost, pepperoni", Price = 55},
                new Pizza() { Nr = 5, Name = "Capricciosa", Toppings = "Tomat, ost, champignon", Price = 57},
                new Pizza() { Nr = 6, Name = "Hawaii", Toppings = "Tomat, ost, skinke, ananas", Price = 57},
                new Pizza() { Nr = 7, Name = "Amerikaner", Toppings = "Tomat, ost, hakket oksekød, chili", Price = 58},
                new Pizza() { Nr = 8, Name = "Princess", Toppings = "Tomat, ost, cocktailpølser, bacon, løg", Price = 63},
                new Pizza() { Nr = 9, Name = "Omelet", Toppings = "Tomat, ost, skinke, bacon, løg, æg", Price = 64},
                new Pizza() { Nr = 10, Name = "Kødsauce", Toppings = "Tomat, ost, kødsauce, løg", Price = 55},
                new Pizza() { Nr = 11, Name = "Pollo", Toppings = "Tomat, ost, kylling, champignon, paprika", Price = 58},
                new Pizza() { Nr = 12, Name = "Parmaskinke", Toppings = "Tomat, ost, parmaskinke, pesto, parmesanost, rucola", Price = 61},
                new Pizza() { Nr = 13, Name = "Karry", Toppings = "Tomat, ost, kylling, bacon, karrypulver, ananas", Price = 63},
                new Pizza() { Nr = 14, Name = "Salatpizza", Toppings = "Tomat, ost, (vælg mellem: kebab, kylling, skinke, falafel, pepperoni & gorgonzola, kødsauce)", Price = 62},
                new Pizza() { Nr = 15, Name = "Fyns", Toppings = "Tomat, ost, friskhakket oksekød, bacon, paprika, hvidløg, chili", Price = 61},
                new Pizza() { Nr = 16, Name = "London", Toppings = "Tomat, ost, skinke, kødsauce, bacon, paprika, hvidløg", Price = 63},
                new Pizza() { Nr = 17, Name = "Venus", Toppings = "Tomat, ost, skinke, pepperoni, kødsauce, fetaost", Price = 59},
                new Pizza() { Nr = 18, Name = "Gorgonzola", Toppings = "Tomat, ost, skinke, kebab, gorgonzola, løg, salat, dressing", Price = 73},
                new Pizza() { Nr = 19, Name = "A-Town", Toppings = "Tomat, ost, kebab, champignon, paprika, løg, chili", Price = 67},
                new Pizza() { Nr = 20, Name = "Dansk Cocktail", Toppings = "Tomat, ost, skinke, bacon, pepperoni, cocktailpølser", Price = 67},
                new Pizza() { Nr = 21, Name = "Paris", Toppings = "Tomat, ost, pepperoni, hakket oksekød, gorgonzola", Price = 67},
                new Pizza() { Nr = 22, Name = "The Lux", Toppings = "Tomat, ost, spinat, parmaskinke, frisk tomat, pesto, rucola, parmesanost", Price = 65},
                new Pizza() { Nr = 23, Name = "Kartoffel", Toppings = "Tomat, ost, kebab, kartofler, peberfrugt, frisk tomat, rucola, pesto", Price = 69},
                new Pizza() { Nr = 24, Name = "Mexicano", Toppings = "Tomat, ost, kebab, løg, champignon, paprika, hvidløg, jalapenos, tacosauce", Price = 65},
                new Pizza() { Nr = 25, Name = "Aubergine", Toppings = "Tomat, ost, hakket kød, grillet aubergine, frisk tomat, fetaost", Price = 71},
                new Pizza() { Nr = 26, Name = "Johnny", Toppings = "Tomat, ost, nachos, kebab, salsa, jalapenos", Price = 71},
                new Pizza() { Nr = 27, Name = "Aladdin", Toppings = "Tomat, ost, kebab, champignon, løg, bearnaisesauce", Price = 69}
            };
         
            var pizzasToDelete = GetAllPizzas();
            DeleteAllPizzas(pizzasToDelete);
            InsertAllPizzas(defaultPizzas);
        }

        public void CreatePizza(Pizza newPizza)
        {
            try
            {
                _dbContext.Pizzas.InsertOnSubmit(newPizza);
                _dbContext.SubmitChanges();
            }
            catch
            {
                
            }
        }

        public void EditPizza(Pizza updatedPizza)
        {
            Pizza oldPizza = GetPizzaById(updatedPizza.Id);
            oldPizza.Nr = updatedPizza.Nr;
            oldPizza.Name = updatedPizza.Name;
            oldPizza.Toppings = updatedPizza.Toppings;
            oldPizza.Price = updatedPizza.Price;
            try
            {
                _dbContext.SubmitChanges();
            }
            catch
            {

            }
        }

        ////NEW
        //public List<GraphDataViewModel> ReplacePizzaIdWithPizzaNr(List<GraphDataViewModel> graphDataViewModel)
        //{
        //    List<int> pizzaIdList = new List<int>();
        //    foreach (GraphDataViewModel item in graphDataViewModel)
        //    {
        //        pizzaIdList.Add(item.PizzaNr);
        //    }
        //    List<Pizza> pizzaList = null;//Insert stackoverflow code
        //    foreach (GraphDataViewModel item in graphDataViewModel)
        //    {
        //        if (pizzaIdList.Contains(Convert.ToInt32(item.Pizza)))
        //        {

        //        }
        //    }
        //    return graphDataViewModel;
        //}

        //NEW
        public List<GraphDataViewModel> ReplacePizzaIdWithPizzaNr(List<GraphDataViewModel> graphDataViewModel) //Add to interface
        {  
            foreach(GraphDataViewModel item in graphDataViewModel)
            {
                Pizza pizza = GetPizzaById(Convert.ToInt32(item.Pizza)); //Get pizza in DB
                item.Pizza = pizza.Nr.ToString(); //Set the correct pizza nr.
            }

            return graphDataViewModel;
        }
    }
}