using Application.Features.StockInRecieps.Commands.Create;
using Application.Features.StockInRecieps.Commands.Delete;
using Application.Features.StockInRecieps.Commands.Update;
using Application.Features.StockInRecieps.Dtos;
using Application.Features.StockInRecieps.Models;
using Application.Features.StockInRecieps.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInReciepesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateStockInReciepeCommand createStockInReciepe)
        {
            CreatedStockInReciepeDto result = await Mediator.Send(createStockInReciepe);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStockInReciepeCommand updateStockInReciepe)
        {
            UpdatedStockInReciepeDto result = await Mediator.Send(updateStockInReciepe);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStockInReciepeCommand deleteStockInReciepe)
        {
            DeletedStockInReciepeDto result = await Mediator.Send(deleteStockInReciepe);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetStockInReciepeListQuery query = new() { PageRequest = pageRequest };
            StockInReciepeListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
