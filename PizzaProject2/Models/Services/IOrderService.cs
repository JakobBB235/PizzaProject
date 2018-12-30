using PizzaProject2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject2.Models.Services
{
    interface IOrderService
    {
        void EndOrder(int orderId);
        Order GetOrderById(int orderId);
        List<Order> GetAllOrders();
        void PayCreateOrder(List<OrderItemViewModel> sessionPizzas, String userId); //int userId
        List<OrderViewModel> ConvertOrderToOrderViewModel(List<Order> orders);
    }
}
