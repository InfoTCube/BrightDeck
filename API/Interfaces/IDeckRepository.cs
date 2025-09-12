using System.Security.Cryptography;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IDeckRepository
{
    Task<Deck> GetDeckByIdAsync(Guid id, bool trackChanges);
    Task<PagedList<Deck>> GetDecksAsync(DeckParameters deckParameters, bool trackChanges);
    void CreateDeck(Deck deck);
    void DeleteDeck(Deck deck);
}