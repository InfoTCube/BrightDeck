using API.DTOs;

namespace API.Interfaces;

public interface IDeckService
{
    Task<IEnumerable<DeckDto>> GetPublicDecksAsync(bool trackChanges);
    Task<DeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, bool trackChanges);
    Task DeleteDeckAsync(Guid id, bool trackChanges);
}