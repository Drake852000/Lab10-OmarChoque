using Lab10_OmarChoque.Application.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_OmarChoque.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResponseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/response
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllResponsesQuery());
        return Ok(result);
    }

    // GET: api/response/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetResponseByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // POST: api/response
    [HttpPost]
    public async Task<IActionResult> Create(CreateResponseCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { responseId = id });
    }
}