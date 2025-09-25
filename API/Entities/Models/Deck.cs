namespace API.Entities;

public class Deck
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool Public { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Flashcard>? Flashcards { get; set; }
    public AppUser? Author { get; set; }
}