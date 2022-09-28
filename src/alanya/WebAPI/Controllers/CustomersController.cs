using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Models;
using Application.Features.Customers.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomer)
        {
            CreatedCustomerDto result = await Mediator.Send(createCustomer);
            return Created("", result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomer)
        {
            UpdatedCustomerDto result = await Mediator.Send(updateCustomer);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomer)
        {
            DeletedCustomerDto result = await Mediator.Send(deleteCustomer);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCustomerQuery query = new() { PageRequest = pageRequest };
            CustomerListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
