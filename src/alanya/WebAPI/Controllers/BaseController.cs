using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebAPI.Controllers
{
    public class BaseController:ControllerBase
    {
        
        protected IMediator? Mediator => _mediator ??=HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

    }
}
