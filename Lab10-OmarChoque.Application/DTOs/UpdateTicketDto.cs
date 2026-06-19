namespace Lab10_OmarChoque.Application.DTOs;

public class UpdateTicketDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = string.Empty;
}