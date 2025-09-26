namespace API.DTOs;

public record DeckForCreationDto : DeckForManipulationDto
{
    public IEnumerable<FlashcardForCreationDto>? Flashcards { get; set; }
}