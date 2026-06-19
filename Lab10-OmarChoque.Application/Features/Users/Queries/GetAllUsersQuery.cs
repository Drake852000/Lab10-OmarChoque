using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Users;

public record GetAllUsersQuery() : IRequest<List<User>>;

internal sealed class GetAllUsersQueryHandler
    : IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _repository;

    public GetAllUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync()).ToList();
    }
}