namespace API.Entities;

public class Flashcard
{
    public Guid Id { get; set; }
    public string Front { get; set; }
    public string Back { get; set; }
    public Deck? Deck { get; set; }
    public Guid DeckId { get; set; }
}
