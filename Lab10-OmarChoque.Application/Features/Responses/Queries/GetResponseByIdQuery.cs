using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Responses;

public record GetResponseByIdQuery(Guid Id) : IRequest<Response?>;

internal sealed class GetResponseByIdQueryHandler
    : IRequestHandler<GetResponseByIdQuery, Response?>
{
    private readonly IResponseRepository _repository;

    public GetResponseByIdQueryHandler(IResponseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response?> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetByIdAsync(request.Id);
}