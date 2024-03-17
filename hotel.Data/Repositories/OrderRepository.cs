using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        Order IOrderRepository.AddOrder(Order order)
        {
                _context.Orders.Add(new Order
                {
                    OrderId = order.OrderId,
                    NameClient = order.NameClient,
                    Date = order.Date,
                    DosesCount = order.DosesCount,
                    Doses = order.Doses,
                    Employes = order.Employes
                });
            _context.SaveChanges();
            return order;

        }
        void IOrderRepository.DeleteOrder(int id)
        {
            var temp = _context.Orders.Find(id);
            _context.Orders.Remove(temp);
            _context.SaveChanges();

        }
        IEnumerable<Order> IOrderRepository.GetOrders()
        {
            return _context.Orders;
        }
        Order IOrderRepository.GetById(int id)
        {
            return _context.Orders.Find(id);
        }
        Order IOrderRepository.UpdateOrder(int id, Order Order)
        {
            var temp = _context.Orders.Find(id);
            temp.NameClient=Order.NameClient;
            temp.OrderId=id; 
            temp.Date=Order.Date;
            temp.DosesCount=Order.DosesCount;
            temp.Doses = Order.Doses;
            temp.Employes = Order.Employes;
            _context.SaveChanges();

            return temp;
        }
    }
}
