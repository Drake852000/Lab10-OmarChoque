using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;

namespace Lab10_OmarChoque.Application.Features.Tickets;

public record DeleteTicketCommand(Guid Id) : IRequest<bool>;

internal sealed class DeleteTicketCommandHandler
    : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly ITicketRepository _repository;

    public DeleteTicketCommandHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteTicketCommand request,
        CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.Id);

        if (ticket == null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}