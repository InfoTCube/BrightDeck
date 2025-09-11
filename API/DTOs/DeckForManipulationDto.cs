using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public record DeckForManipulationDto
{
    [Required(ErrorMessage = "Deck title is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Title is 50 characters.")]
    public string Title { get; init; }

    [MaxLength(500, ErrorMessage = "Maximum length for the Description is 500 characters.")]
    public string? Description { get; init; }
    
    public bool Public { get; init; }
}