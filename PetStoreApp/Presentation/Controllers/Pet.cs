using System.ComponentModel;
using System.Net;
using PetStoreApp.Application.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Queries;
using PetStoreApp.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Application.Handlers;
using PetStoreApp.Infrastructure.Repositories;


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

    [HttpGet("FindById/{petId}")]
    public async Task<IActionResult> FindById([FromQuery] int petId)
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

    [HttpGet("FindByStatus/{status}")]
    public async Task<IActionResult> FindByStatus([FromQuery] string[] status)
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
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
    public async Task<PetModel> AddPet([FromBody] PetModel value)
    {
        try
        {
            return await _mediator.Send(new AddPetCommand(value.PetName, value.Category, value.Status)
            {
                PetName = petName,
                Category = category,
                Status = status,

            });
        }
        catch (AppException ex)
        {
            return BadRequest(ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "GenerateWordForRatingPlates in Word", projectId, enclosureId, bomDto);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }



        return await _mediator.Send(model);
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
}

