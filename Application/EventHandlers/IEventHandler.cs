using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandlers
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
