using Domain.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent domainEvent)
        {
            // Örneğin, stok güncelleme veya e-posta gönderme burada olabilir
            Debug.WriteLine($"Sipariş {domainEvent.OrderId} oluşturuldu!");
            return Task.CompletedTask;
        }
    }
}
