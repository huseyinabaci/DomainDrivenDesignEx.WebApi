using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int BookId { get; private set; }
        public int Quantity { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public string Status { get; private set; } = "Pending";

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        // EF Core için parametresiz constructor
        private Order() { } // EF Core’un kullanması için private

        // İş mantığı için public constructor
        public Order(int bookId, int quantity, Address deliveryAddress)
        {
            BookId = bookId;
            Quantity = quantity;
            DeliveryAddress = deliveryAddress;
        }
        public void RaiseOrderCreatedEvent()
        {
            AddDomainEvent(new OrderCreatedEvent(Id));
        }

        public void Confirm()
        {
            Status = "Confirmed";
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
