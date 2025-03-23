using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateOrderCommand
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDomainEventDispatcher _eventDispatcher;

        public CreateOrderCommand(IOrderRepository orderRepository, IDomainEventDispatcher eventDispatcher)
        {
            _orderRepository = orderRepository;
            _eventDispatcher = eventDispatcher;
        }

        public async Task Execute(int bookId, int quantity, Address address)
        {
            var order = new Order(bookId, quantity, address); // Id yok
            _orderRepository.Add(order); // Repository Id’yi atar ve eventi tetikler
            Debug.WriteLine($"Dispatch öncesi event sayısı: {order.DomainEvents.Count}");
            await _eventDispatcher.Dispatch(order.DomainEvents);
            order.ClearDomainEvents();
        }
    }
}
