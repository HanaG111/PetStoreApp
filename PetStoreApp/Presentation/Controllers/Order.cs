using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Application.Orders.Queries;
using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class Order : ControllerBase
{
    private readonly IMediator _mediator;

    public Order(IMediator mediator)
    {
        _mediator = mediator;
    }
   
    // GET: api/<OrderController>
    [HttpGet]
    public async Task<List<OrderModel>> Get()
    {
        return await _mediator.Send(new GetOrderListQuery());
    }
    
    [HttpPost(template: "createOrder")]
    public async Task<ActionResult<OrderModel>> Create([FromBody]OrderModelDto orderDto)
    {
        try
        {
            return Ok(await _mediator.Send(new CreateOrderCommand
            {
                OrderDto = orderDto,
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{orderId}")]
    public async Task<IActionResult> FindById(int orderId)
    {
        try
        {
            return Ok(await _mediator.Send(new FindByIdQuery()
            {
                OrderId = orderId
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}


