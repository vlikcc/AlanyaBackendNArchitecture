using Application.Features.StockInRecieps.Dtos;
using Application.Features.StockInRecieps.Queries;
using Application.Features.Stockpiles.Commands.Create;
using Application.Features.Stockpiles.Commands.Delete;
using Application.Features.Stockpiles.Commands.Update;
using Application.Features.Stockpiles.Dtos;
using Application.Features.Stockpiles.Models;
using Application.Features.Stockpiles.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockpilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateStockpileCommand createStockpile)
        {
            CreatedStockpileDto result = await Mediator.Send(createStockpile);
            return Created("",result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStockpileCommand updateStockpile)
        {
            UpdatedStockpileDto result = await Mediator.Send(updateStockpile);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStockpileCommand deleteStockpile)
        {
            DeletedStockpileDto result = await Mediator.Send(deleteStockpile);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult > GetList([FromQuery] PageRequest pageRequest)
        {
            GetStockpileListQuery query = new() { PageRequest = pageRequest };
            StockpileListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
