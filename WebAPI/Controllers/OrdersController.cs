using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using Application.Features.Orders.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand  createOrder)
        {
            CreatedOrderDto result = await Mediator.Send(createOrder );
            return Created("", result);
        }

        [HttpPost("Update")]

        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand updateOrder)
        {
            UpdatedOrderDto result = await Mediator.Send(updateOrder);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand deleteOrder)
        {
            DeletedOrderDto result = await Mediator.Send(deleteOrder);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest )
        {
            GetListOrderQuery query = new () { PageRequest = pageRequest };
            OrderListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
