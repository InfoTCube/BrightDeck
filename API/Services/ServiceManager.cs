using API.Interfaces;
using AutoMapper;

namespace API.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IDeckService> _deckService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _deckService = new Lazy<IDeckService>(() => new DeckService(repositoryManager, mapper));
    }

    public IDeckService DeckService => _deckService.Value;
}