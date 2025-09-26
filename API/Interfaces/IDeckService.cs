using API.DTOs;
using API.Helpers;

namespace API.Interfaces;

public interface IDeckService
{
    Task<DeckDto> GetDeckById(Guid id, string username, bool trackChanges);
    Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetPublicDecksAsync(DeckParameters deckParameters, bool trackChanges);
    Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetPublicDecksByUserId(Guid userId, DeckParameters deckParameters, bool trackChanges);
    Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetDecksForCurrentUser(DeckParameters deckParameters, string username, bool trackChanges);
    Task<ListedDeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, string username, bool trackChanges);
    Task UpdateDeck(Guid id, DeckForUpdateDto deckForUpdate, string username, bool trackChanges);
    Task DeleteDeckAsync(Guid id, string username, bool trackChanges);
}