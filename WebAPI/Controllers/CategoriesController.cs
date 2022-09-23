using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategory)
        {
            CreatedCategoryDto result = await Mediator.Send(createCategory);
            return Created ("",result);
        }

        [HttpPost("Update")]
        
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategory )
        {
            UpdatedCategoryDto result = await Mediator.Send(updateCategory);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deletedCategory)
        {
            DeletedCategoryDto result = await Mediator.Send(deletedCategory);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest )
        {
            GetListCategoryQuery query  = new() { PageRequest = pageRequest };
            CategoryListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
