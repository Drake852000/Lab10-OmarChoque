using MediatR;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Application.Features.Responses;

public record CreateResponseCommand(
    Guid TicketId,
    Guid ResponderId,
    string Message
) : IRequest<Guid>;

internal sealed class CreateResponseCommandHandler
    : IRequestHandler<CreateResponseCommand, Guid>
{
    private readonly IResponseRepository _repository;

    public CreateResponseCommandHandler(IResponseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Response
        {
            ResponseId = Guid.NewGuid(),
            TicketId = request.TicketId,
            ResponderId = request.ResponderId,
            Message = request.Message,
            CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified)
        };

        await _repository.AddAsync(response);

        return response.ResponseId;
    }
}