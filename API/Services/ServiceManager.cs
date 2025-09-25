using API.Entities;
using API.Entities.ConfigurationModels;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDeckService> _deckService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
        UserManager<AppUser> userManager, IOptions<JwtConfiguration> configuration)
    {
        _deckService = new Lazy<IDeckService>(() => new DeckService(repositoryManager, userManager));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, userManager, configuration));
    }

    public IDeckService DeckService => _deckService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}