using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public record FlashcardForManipulationDto
{
    [Required(ErrorMessage = "Flashcard front is a required field.")]
    [MaxLength(80, ErrorMessage = "Maximum length for the flashcard's Front is 80 characters.")]
    public string Front { get; init; }

    [Required(ErrorMessage = "Flashcard back is a required field.")]
    [MaxLength(80, ErrorMessage = "Maximum length for the flashcard's Back is 80 characters.")]
    public string Back { get; init; }
}