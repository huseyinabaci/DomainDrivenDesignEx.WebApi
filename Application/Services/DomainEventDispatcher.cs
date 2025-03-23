using Application.EventHandlers;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Dispatch(IEnumerable<IDomainEvent> events)
        {
            Debug.WriteLine($"Dispatch’e gelen event sayısı: {events.Count()}");
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handler = _serviceProvider.GetService(handlerType);
                if (handler != null)
                {
                    Debug.WriteLine($"Handler bulundu: {handlerType.Name}");
                    await (Task)handlerType.GetMethod("Handle")!.Invoke(handler, new[] { domainEvent });
                }
                else
                {
                    Debug.WriteLine($"Handler bulunamadı: {handlerType.Name}");
                }
            }
        }
    }
}
