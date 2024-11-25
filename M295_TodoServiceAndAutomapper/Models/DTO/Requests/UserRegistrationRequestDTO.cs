using System.ComponentModel.DataAnnotations;

namespace M295_TodoServiceAndAutomapper.Models.DTO.Requests;

public class UserRegistrationRequestDTO
{
    [MaxLength(50)]
    public string Username { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }
}