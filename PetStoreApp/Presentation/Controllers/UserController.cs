using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Application.Users.Commands;
using PetStoreApp.Application.Users.Queries;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Presentation.Controllers;

public class UserController : BaseController
{
    private readonly IMediator _mediator;
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<List<UserModel>> Get()
    {
        return await _mediator.Send(new GetUserListQuery());
    }

    [HttpPost(template: "createUser")]
    public async Task<ActionResult<UserModel>> Create([FromBody]UserModelDto userDto)
    {
        try
        {
            return Ok(await _mediator.Send(new CreateUserCommand
            {
                UserDto = userDto,
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{username}")]
    public async Task<IActionResult> FindByUsername(string username)
    {
        try
        {
            return Ok(await _mediator.Send(new FindByUsernameQuery()
            {
                Username = username
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("editUser/{userId}")]
    public async Task<ActionResult<UserModel>> EditUser(int userId,[FromBody]UserModelDto userDto)
    {
        try
        {
            return Ok(await _mediator.Send(new EditUserCommand
            {
                UserId = userId,
                UserDto = userDto,
            }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("deleteUser/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            return Ok(await _mediator.Send(new DeleteUserCommand()
            {
                UserId = userId
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}