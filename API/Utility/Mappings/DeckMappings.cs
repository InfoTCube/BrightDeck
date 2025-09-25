using API.DTOs;
using API.Entities;

namespace API.Utility.Mappings;

public static class DeckMappings
{
    public static DeckDto ToDto(this Deck from) =>
        new DeckDto
        {
            Id = from.Id,
            Title = from.Title,
            Description = from.Description,
            Public = from.Public,
            CreatedAt = from.CreatedAt,
            AuthorUsername = from.Author.UserName,
            Flashcards = from.Flashcards.ToDto()
        };

    public static ListedDeckDto ToListedDto(this Deck from) =>
        new ListedDeckDto
        {
            Id = from.Id,
            Title = from.Title,
            Description = from.Description,
            Public = from.Public,
            CreatedAt = from.CreatedAt,
            AuthorUsername = from.Author.UserName
        };

    public static IEnumerable<ListedDeckDto> ToListedDto(this IEnumerable<Deck> from) =>
        from.Select(ToListedDto);

    public static Deck ToEntity(this DeckForCreationDto from) =>
        new Deck
        {
            Title = from.Title,
            Description = from.Description,
            Public = from.Public,
            Flashcards = from.Flashcards.ToEntity()
        };
}