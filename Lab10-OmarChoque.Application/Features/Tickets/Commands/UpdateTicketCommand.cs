using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;

namespace Lab10_OmarChoque.Application.Features.Tickets;

public record UpdateTicketCommand(
    Guid TicketId,
    string Title,
    string? Description,
    string Status
) : IRequest<bool>;

internal sealed class UpdateTicketCommandHandler
    : IRequestHandler<UpdateTicketCommand, bool>
{
    private readonly ITicketRepository _repository;

    public UpdateTicketCommandHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateTicketCommand request,
        CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.TicketId);

        if (ticket == null)
            return false;

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Status = request.Status;

        await _repository.UpdateAsync(ticket);

        return true;
    }
}