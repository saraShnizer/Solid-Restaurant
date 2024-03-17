
using AutoMapper;
using lesson3.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant.Core.Models;
using Restaurant.Core.DTOs;
using Restaurant.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            var orders = _orderService.GetOrders();
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(ordersDTO);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var order = _orderService.GetById(id);
            var orderDTO=_mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderPostModel order)
        {
            var orderToAdd=(new Order
            {
                OrderId = order.OrderId,
                NameClient = order.NameClient,
                Date = order.Date,
                DosesCount = order.DosesCount,
            });
            return Ok( _orderService.AddOrder(orderToAdd));
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrderPostModel order)
        {
            var orderToUpdate = (new Order
            {
                OrderId = order.OrderId,
                NameClient = order.NameClient,
                Date = order.Date,
                DosesCount = order.DosesCount,
            });
            return Ok( _orderService.UpdateOrder(id, orderToUpdate));    
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
