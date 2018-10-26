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
        //[StringLength(50, ErrorMessage = "Nr cannot exceed 50 characters")]
        int Nr { get; set; }

        [Required(ErrorMessage = "Indtast toppings")]
        string Toppings { get; set; }

        [Required(ErrorMessage = "Indtast navn")]
        string Name { get; set; }

        [Required(ErrorMessage = "Indtast pris")]
        int Price { get; set; }
    }
}
