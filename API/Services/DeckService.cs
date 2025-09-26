using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Entities.Exceptions;
using API.Helpers;
using API.Interfaces;
using API.Utility.Mappings;
using Microsoft.AspNetCore.Identity;

namespace API.Services;

public sealed class DeckService : IDeckService
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<AppUser> _userManager;

    public DeckService(IRepositoryManager repository, UserManager<AppUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task<DeckDto> GetDeckById(Guid id, string username, bool trackChanges)
    {
        var deck = await _repository.DeckRepository.GetDeckByIdAsync(id, trackChanges);

        if (deck is null)
            throw new DeckNotFoundException(id);

        if (!deck.Public && deck.Author?.UserName != username)
            throw new UnauthorizedException();

        var deckDto = deck.ToDto();

        return deckDto;
    }

    public async Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetPublicDecksAsync(DeckParameters deckParameters, bool trackChanges)
    {
        var decksWithMetaData = await _repository.DeckRepository.GetDecksAsync(deckParameters, trackChanges);

        var decksDtos = decksWithMetaData.ToListedDto();

        return (decks: decksDtos, metaData: decksWithMetaData.MetaData);
    }

    public async Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetPublicDecksByUserId(Guid userId, DeckParameters deckParameters, bool trackChanges)
    {
        var decksWithMetaData = await _repository.DeckRepository.GetDecksByUserIdAsync(deckParameters, userId, trackChanges);

        var decksDtos = decksWithMetaData.ToListedDto();

        return (decks: decksDtos, metaData: decksWithMetaData.MetaData);
    }

    public async Task<(IEnumerable<ListedDeckDto> decks, MetaData metaData)> GetDecksForCurrentUser(DeckParameters deckParameters, string username, bool trackChanges)
    {
        var decksWithMetaData = await _repository.DeckRepository.GetDecksForUserAsync(deckParameters, username, trackChanges);

        var decksDtos = decksWithMetaData.ToListedDto();

        return (decks: decksDtos, metaData: decksWithMetaData.MetaData);
    }

    public async Task<ListedDeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, string username, bool trackChanges)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user is null)
            throw new UserBadRequestException();

        var deckEntity = deckForCreation.ToEntity();
        deckEntity.CreatedAt = DateTime.UtcNow;
        deckEntity.Author = user;

        _repository.DeckRepository.CreateDeck(deckEntity);
        await _repository.SaveAsync();

        var deckResponse = deckEntity.ToListedDto();
        return deckResponse;
    }

    public async Task UpdateDeck(Guid id, DeckForUpdateDto deckForUpdate, string username, bool trackChanges)
    {
        var deck = await _repository.DeckRepository.GetDeckByIdAsync(id, trackChanges);
        if (deck is null)
            throw new DeckNotFoundException(id);

        if (deck.Author?.UserName != username)
            throw new UnauthorizedException();

        deck.Title = deckForUpdate.Title;
        deck.Description = deckForUpdate.Description;
        deck.Public = deckForUpdate.Public;

        await _repository.SaveAsync();
    }

    public async Task DeleteDeckAsync(Guid id, string username, bool trackChanges)
    {
        var deck = await _repository.DeckRepository.GetDeckByIdAsync(id, trackChanges);

        if (deck is null)
            throw new DeckNotFoundException(id);

        if (deck.Author?.UserName != username)
            throw new UnauthorizedException();

        _repository.DeckRepository.DeleteDeck(deck);
        await _repository.SaveAsync();
    }
}