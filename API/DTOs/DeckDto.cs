namespace API.DTOs;

public record DeckDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public bool Public { get; init; }
    public DateTime CreatedAt { get; init; }
    public string? AuthorUsername { get; init; }
}