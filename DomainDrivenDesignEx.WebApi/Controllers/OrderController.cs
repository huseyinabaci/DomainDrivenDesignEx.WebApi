using Application.Commands;
using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignEx.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDomainEventDispatcher _eventDispatcher;

        public OrderController(IOrderRepository orderRepository, IDomainEventDispatcher eventDispatcher)
        {
            _orderRepository = orderRepository;
            _eventDispatcher = eventDispatcher;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int bookId, int quantity, [FromBody] Address address)
        {
            var command = new CreateOrderCommand(_orderRepository, _eventDispatcher);
            await command.Execute(bookId, quantity, address);
            return Ok("Sipariş oluşturuldu!");
        }
    }
}
