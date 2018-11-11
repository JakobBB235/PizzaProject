using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject2.Models.Database
{
    interface IPizza
    {
        [Required(ErrorMessage = "Indtast pizzanummer")]
        //[Display(Name="Pizza #")]
        //[StringLength(50, ErrorMessage = "Nr cannot exceed 50 characters")]
        int Nr { get; set; }

        [Required(ErrorMessage = "Indtast toppings")]
        //[Display(Name = "Fyld")]
        string Toppings { get; set; }

        [Required(ErrorMessage = "Indtast navn")]
        //[Display(Name = "Navn")]
        string Name { get; set; }

        [Required(ErrorMessage = "Indtast pris")]
        //[Display(Name = "Pris")]
        //[DataType(DataType.Currency)]
        int Price { get; set; }
    }
}
