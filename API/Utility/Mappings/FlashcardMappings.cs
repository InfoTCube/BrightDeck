using API.DTOs;
using API.Entities;

namespace API.Utility.Mappings;

public static class FlashcardMappings
{
    public static FlashcardDto ToDto(this Flashcard from) =>
        new FlashcardDto
        {
            Id = from.Id,
            Front = from.Front,
            Back = from.Back
        };

    public static IEnumerable<FlashcardDto> ToDto(this IEnumerable<Flashcard> from) =>
        from.Select(ToDto);

    public static Flashcard ToEntity(this FlashcardForCreationDto from) =>
        new Flashcard
        {
            Front = from.Front,
            Back = from.Back
        };

    public static ICollection<Flashcard> ToEntity(this IEnumerable<FlashcardForCreationDto> from) =>
        from.Select(ToEntity).ToList();
}