namespace API.Entities.Exceptions;

public sealed class DeckNotFoundException : NotFoundException
{
    public DeckNotFoundException(Guid deckId) : base($"Deck with id: {deckId} doesn't exist in the database.")
    {
    }
}