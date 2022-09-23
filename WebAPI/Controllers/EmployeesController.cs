using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Dtos;
using Application.Features.Employees.Models;
using Application.Features.Employees.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateEmployeeCommand createEmployee)
        {
            CreatedEmployeeDto result = await Mediator.Send(createEmployee);
            return Created("",result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployee)
        {
            UpdatedEmployeeDto result = await Mediator.Send(updateEmployee);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommand deleteEmployee)
        {
            DeletedEmployeeDto result = await Mediator.Send(deleteEmployee);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListEmployeeQuery query = new() { PageRequest = pageRequest };
            EmployeeListModel result = await Mediator.Send(query);
            return Ok(result);  
        }
    }
}
