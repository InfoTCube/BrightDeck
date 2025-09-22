namespace API.Interfaces;

public interface IServiceManager
{
    IDeckService DeckService { get; }
    IAuthenticationService AuthenticationService { get; }
}