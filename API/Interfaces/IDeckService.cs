using System.Security.Claims;
using API.DTOs;
using API.Helpers;

namespace API.Interfaces;

public interface IDeckService
{
    Task<(IEnumerable<DeckDto> decks, MetaData metaData)> GetPublicDecksAsync(DeckParameters deckParameters, bool trackChanges);
    Task<(IEnumerable<DeckDto> decks, MetaData metaData)> GetDecksForCurrentUser(DeckParameters deckParameters, string username, bool trackChanges);
    Task<DeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, string username, bool trackChanges);
    Task DeleteDeckAsync(Guid id, bool trackChanges);
}