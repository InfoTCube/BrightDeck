using API.Interfaces;

namespace API.Data;

public class RepositoryManager : IRepositoryManager
{
    private readonly DataContext _dataContext;
    private readonly Lazy<IDeckRepository> _deckRepository;

    public RepositoryManager(DataContext dataContext)
    {
        _dataContext = dataContext;
        _deckRepository = new Lazy<IDeckRepository>(() => new DeckRepository(dataContext));
    }

    public IDeckRepository DeckRepository => _deckRepository.Value;

    public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
}