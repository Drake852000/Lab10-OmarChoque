namespace Lab10_OmarChoque.Application.DTOs;

public class CreateTicketDto
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}