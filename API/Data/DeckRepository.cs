using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DeckRepository : RepositoryBase<Deck>, IDeckRepository
{
    public DeckRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<Deck> GetDeckByIdAsync(Guid id, bool trackChanges)
    {
        var deck = await FindByCondition(d => d.Id == id, trackChanges)
            .SingleOrDefaultAsync();

        return deck;
    }

    public async Task<IList<Deck>> GetDecksAsync(bool trackChanges)
    {
        var decks = await FindByCondition(d => d.Public, trackChanges)
            .ToListAsync();

        return decks;
    }

    public void CreateDeck(Deck deck) => Create(deck);

    public void DeleteDeck(Deck deck) => Delete(deck);
}