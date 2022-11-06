using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API3.Controllers.v1;

[ApiController]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}