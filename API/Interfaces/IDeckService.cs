using API.DTOs;
using API.Helpers;

namespace API.Interfaces;

public interface IDeckService
{
    Task<(IEnumerable<DeckDto> decks, MetaData metaData)> GetPublicDecksAsync(DeckParameters deckParameters, bool trackChanges);
    Task<DeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, bool trackChanges);
    Task DeleteDeckAsync(Guid id, bool trackChanges);
}