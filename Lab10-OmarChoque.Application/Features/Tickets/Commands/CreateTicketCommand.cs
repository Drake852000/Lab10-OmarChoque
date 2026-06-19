using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Tickets;

public record CreateTicketCommand(
    Guid UserId,
    string Title,
    string? Description
) : IRequest<Guid>;

internal sealed class CreateTicketCommandHandler
    : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly ITicketRepository _repository;

    public CreateTicketCommandHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateTicketCommand request,
        CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            TicketId = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Status = "abierto",
            
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(ticket);

        return ticket.TicketId;
    }
}