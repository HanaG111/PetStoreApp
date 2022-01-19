using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Pets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Domain.Dtos;

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
    
    [HttpGet("status/{status}")]
    public async Task<IActionResult> FindByStatus(string status)
    {
        try
        {
            return Ok(await _mediator.Send(new FindByStatusQuery()
            {
                Status = status
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{petId}")]
    public async Task<IActionResult> FindById(int petId)
    {
        try
        {
            return Ok(await _mediator.Send(new FindByIdQuery()
            {
                PetId = petId
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost(template: "addPet")]
    public async Task<ActionResult<PetModel>> AddPet([FromBody]PetModelDto petDto)
    {
        try
        {
            return Ok(await _mediator.Send(new AddPetCommand
            {
                PetDto = petDto,
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("delete/{petId}")]

    public async Task<IActionResult> DeletePet(int petId)
    {
        try
        {
            return Ok(await _mediator.Send(new DeletePetCommand()
            {
                PetId = petId
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("editPet/{petId}")]
    public async Task<ActionResult<PetModel>> EditPet(int petId,[FromBody]PetModelDto petDto)
    {
        try
        {
            return Ok(await _mediator.Send(new EditPetCommand
            {
            PetId = petId,
            PetDto = petDto,
            }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

