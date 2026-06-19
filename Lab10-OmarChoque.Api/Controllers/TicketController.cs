using Lab10_OmarChoque.Application.Features.Tickets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_OmarChoque.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/ticket
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllTicketsQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    // GET: api/ticket/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTicketByIdQuery(id);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // POST: api/ticket
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { ticketId = id });
    }

    // PUT: api/ticket/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTicketCommand command)
    {
        if (id != command.TicketId)
            return BadRequest("El ID no coincide");

        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return Ok();
    }

    // DELETE: api/ticket/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTicketCommand(id);
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }
}