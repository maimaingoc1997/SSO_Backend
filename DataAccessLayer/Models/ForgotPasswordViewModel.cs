using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class ForgotPasswordViewModel
{
    [Required]
    public string? Username { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}