using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public record UserForRegistrationDto
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(30, ErrorMessage = "Username is too long")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not correctly formated")]
    public string? Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }

    [Required(ErrorMessage = "Confirm password is required")]
    [Compare("Password", ErrorMessage = "Confirm password and password has to match")]
    public string? ConfirmPassword { get; init; }
}