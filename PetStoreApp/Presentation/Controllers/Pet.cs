using PetStoreApp.Application.Commands;
using PetStoreApp.Application.Models;
using PetStoreApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreApp.Presentation.Controllers;

[Route("[controller]")]
[ApiController]

public class Pet : ControllerBase
{
    private readonly IMediator _mediator;

    public Pet(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<PetController>
    [HttpGet]
    public async Task<List<PetModel>> Get()
    {
        return await _mediator.Send(new GetPetListQuery());
    }
    
    [HttpGet("FindById")]
    public async Task<PetModel> Get(int petId)
    {
        return await _mediator.Send(new FindByIdQuery(petId));
    }
    
    [HttpPost(template:"AddPet")]
    public async Task<PetModel> Post([FromBody] PetModel value)
    {
        var model = new AddPetCommand(value.PetName, value.Category, value.Status);
        return await _mediator.Send(model);
    }
    
   
}

