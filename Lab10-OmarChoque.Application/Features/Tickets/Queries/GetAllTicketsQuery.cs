using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Tickets;

public record GetAllTicketsQuery : IRequest<List<Ticket>>;

internal sealed class GetAllTicketsQueryHandler
    : IRequestHandler<GetAllTicketsQuery, List<Ticket>>
{
    private readonly ITicketRepository _repository;

    public GetAllTicketsQueryHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Ticket>> Handle(
        GetAllTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return result.ToList();
    }
}