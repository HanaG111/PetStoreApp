using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreApp.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();
}