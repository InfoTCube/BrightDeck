using System.Security.Cryptography;
using API.Entities;

namespace API.Interfaces;

public interface IDeckRepository
{
    Task<Deck> GetDeckByIdAsync(Guid id, bool trackChanges);
    Task<IList<Deck>> GetDecksAsync(bool trackChanges);
    void CreateDeck(Deck deck);
    void DeleteDeck(Deck deck);
}