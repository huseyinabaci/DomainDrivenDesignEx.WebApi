using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public EfOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges(); // Id burada otomatik atanır
            order.RaiseOrderCreatedEvent();
            Debug.WriteLine($"Event tetiklendi, Id: {order.Id}, Event sayısı: {order.DomainEvents.Count}");
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }

    //public class InMemorsyOrderRepository : IOrderRepository
    //{
    //    private readonly List<Order> _orders = new();
    //    public void Add(Order order)
    //    {
    //        _orders.Add(order);
    //    }

    //    public Order GetById(int id)
    //    {
    //        return _orders.FirstOrDefault(o => o.Id == id);
    //    }
    //}
}
