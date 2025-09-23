using API.Entities;
using API.Helpers;
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

    public async Task<PagedList<Deck>> GetDecksAsync(DeckParameters deckParameters, bool trackChanges)
    {
        var decks = await FindByCondition(d => d.Public, trackChanges)
            .Include(d => d.Author)
            .ToListAsync();

        return PagedList<Deck>
            .ToPagedList(decks, deckParameters.PageNumber, deckParameters.PageSize);
    }

    public async Task<PagedList<Deck>> GetDecksForUserAsync(DeckParameters deckParameters, string username, bool trackChanges)
    {
        var decks = await FindByCondition(d => d.Author.UserName == username, trackChanges)
            .Include(d => d.Author)
            .ToListAsync();

        return PagedList<Deck>
            .ToPagedList(decks, deckParameters.PageNumber, deckParameters.PageSize);
    }

    public void CreateDeck(Deck deck) => Create(deck);

    public void DeleteDeck(Deck deck) => Delete(deck);
}