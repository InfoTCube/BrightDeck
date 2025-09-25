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
            AuthorUsername = from.Author.UserName
        };

    public static IEnumerable<DeckDto> ToDto(this IEnumerable<Deck> from) =>
        from.Select(ToDto);

    public static Deck ToEntity(this DeckForCreationDto from) =>
        new Deck
        {
            Title = from.Title,
            Description = from.Description,
            Public = from.Public,
            Flashcards = from.Flashcards.ToEntity()
        };
}