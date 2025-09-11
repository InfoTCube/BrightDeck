namespace API.Interfaces;

public interface IRepositoryManager
{
    IDeckRepository DeckRepository { get; }
    Task SaveAsync();
}