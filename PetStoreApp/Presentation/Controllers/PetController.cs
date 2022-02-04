using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Pets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Presentation.Controllers;

public class PetController : BaseController
{
    private readonly IMediator _mediator;

    public PetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<PetController>
    [HttpGet]
    public async Task<List<Pet>> GetPets()
    {
        return await _mediator.Send(new GetPetListQuery());
    }
    
    [HttpGet("petStatus/{petStatus}")]
    public async Task<IActionResult> FindByStatus(string petStatus)
    {
        try
        {
            return Ok(await _mediator.Send(new FindByStatusQuery()
            {
                PetStatus = PetStatus.Available
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
    public async Task<ActionResult<Pet>> AddPet([FromBody]PetDto petDto)
    {
        try
        {
            return Ok(await _mediator.Send(new AddPetCommand
            {
                PetName = petDto.PetName,
                Category = Category.Cat,
                PetStatus = PetStatus.Pending,
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
    public async Task<ActionResult<Pet>> EditPet(int petId,[FromBody]PetDto petDto)
    {
        try
        {
            return Ok(await _mediator.Send(new EditPetCommand
            {
                PetId = petId,
                PetName = petDto.PetName,
            }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

