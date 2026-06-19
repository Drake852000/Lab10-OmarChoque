using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Responses;

public record GetAllResponsesQuery() : IRequest<IEnumerable<Response>>;

internal sealed class GetAllResponsesQueryHandler
    : IRequestHandler<GetAllResponsesQuery, IEnumerable<Response>>
{
    private readonly IResponseRepository _repository;

    public GetAllResponsesQueryHandler(IResponseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Response>> Handle(GetAllResponsesQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAsync();
}