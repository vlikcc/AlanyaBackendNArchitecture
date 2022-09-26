using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProduct)
        {
            CreatedProductDto result = await Mediator.Send(createProduct);
            return Created("", result);
        }
        [HttpPost("Uptade")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            UpdatedProductDto result = await Mediator.Send(updateProduct);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProduct)
        {
            DeletedProductDto result = await Mediator.Send(deleteProduct);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetProductListQuery query = new() { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
