using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject2.Models.Services
{
    interface IOrderItemService
    {
        //void Pay();
        List<OrderItem> GetAllOrderItems();
        List<OrderItemViewModel> CovertOrderItemToViewModel(List<Order> orders);
        List<OrderItem> GetActiveOrderItems(List<Order> orders);
    }
}
