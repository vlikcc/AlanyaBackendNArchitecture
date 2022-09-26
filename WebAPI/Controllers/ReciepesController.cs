using Application.Features.Reciepes.Commands.Create;
using Application.Features.Reciepes.Commands.Delete;
using Application.Features.Reciepes.Commands.Update;
using Application.Features.Reciepes.Dtos;
using Application.Features.Reciepes.Models;
using Application.Features.Reciepes.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateReciepeCommand createReciepe)
        {
            CreatedReciepeDto result = await Mediator.Send(createReciepe);
            return Created("",result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateReciepeCommand updateReciepe)
        {
            UpdatedReciepeDto result = await Mediator.Send(updateReciepe);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteReciepeCommand deleteReciepe)
        {
            DeletedReciepeDto result = await Mediator.Send(deleteReciepe);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult > GetList([FromQuery] PageRequest pageRequest)
        {
            GetReciepeListQuery query = new () { PageRequest = pageRequest };
            ReciepeListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
