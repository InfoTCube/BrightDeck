namespace API.DTOs;

public record FlashcardDto
{
    public Guid Id { get; init; }
    public string Front { get; init; }
    public string Back { get; init; }
}