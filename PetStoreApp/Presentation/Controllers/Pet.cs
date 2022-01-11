using PetStoreApp.Application.Commands;
using PetStoreApp.Domain.Models;
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

    [HttpGet("{status}")]
    public async Task<IActionResult> FindByStatus([FromQuery] string status)
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

    [HttpPost(template: "AddPet")]
    public async Task<ActionResult<PetModel>> AddPet(int petId, [FromBody] PetModel pet)
    {
        try
        {
            return Ok(await _mediator.Send(new AddPetCommand
            {
                PetName = pet.PetName,
                Category = pet.Category,
                Status = pet.Status,
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
    
        }
    }

    [HttpDelete("DeletePet/{petId}")]

    public async Task<IActionResult> DeletePet([FromBody] int petId)

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
    [HttpGet("EditPet")]
    public async Task<IActionResult> EditPet([FromBody] string petName, string category, string status )
    {
        try
        {
            return Ok(await _mediator.Send(new EditPetCommand
            {
                PetName = petName,
                Category = category,
                Status = status
            }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

