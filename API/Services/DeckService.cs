using API.DTOs;
using API.Entities;
using API.Entities.Exceptions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;

namespace API.Services;

public sealed class DeckService : IDeckService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeckService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<DeckDto> decks, MetaData metaData)> GetPublicDecksAsync(DeckParameters deckParameters, bool trackChanges)
    {
        var decksWithMetaData = await _repository.DeckRepository.GetDecksAsync(deckParameters, trackChanges);

        var decksDtos = _mapper.Map<IEnumerable<DeckDto>>(decksWithMetaData);

        return (decks: decksDtos, metaData: decksWithMetaData.MetaData);
    }

    public async Task<DeckDto> CreateDeckAsync(DeckForCreationDto deckForCreation, bool trackChanges)
    {
        var deckEntity = _mapper.Map<Deck>(deckForCreation);
        deckEntity.CreatedAt = DateTime.UtcNow;

        _repository.DeckRepository.CreateDeck(deckEntity);
        await _repository.SaveAsync();

        var deckResponse = _mapper.Map<DeckDto>(deckEntity);
        return deckResponse;
    }

    public async Task DeleteDeckAsync(Guid id, bool trackChanges)
    {
        var deck = await _repository.DeckRepository.GetDeckByIdAsync(id, trackChanges);

        if (deck is null)
            throw new DeckNotFoundException(id);

        _repository.DeckRepository.DeleteDeck(deck);
        await _repository.SaveAsync();
    }
}