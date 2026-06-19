using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Tickets;

public record GetTicketByIdQuery(Guid Id) : IRequest<Ticket?>;

internal sealed class GetTicketByIdQueryHandler
    : IRequestHandler<GetTicketByIdQuery, Ticket?>
{
    private readonly ITicketRepository _repository;

    public GetTicketByIdQueryHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Ticket?> Handle(
        GetTicketByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}