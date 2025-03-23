﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get;}

        public OrderCreatedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
