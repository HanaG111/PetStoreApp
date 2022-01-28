using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Application.Orders.Queries;
using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Presentation.Controllers;

public class OrderController : BaseController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public async Task<List<Order>> GetOrders()
    {
        return await _mediator.Send(new GetOrderListQuery());
    }

    [HttpPost(template: "createOrder")]
    public async Task<ActionResult<Order>> Create([FromBody] OrderDto orderDto)
    {
        try
        {
            return Ok(await _mediator.Send(new CreateOrderCommand
            {
                petId = orderDto.PetId,
                quantity = orderDto.Quantity,
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

    [HttpDelete("deleteOrder/{orderId}")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        try
        {
            return Ok(await _mediator.Send(new DeleteOrderCommand()
            {
                OrderId = orderId
            }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("orderStatus/{status}")]
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
}