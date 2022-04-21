using System.ComponentModel.DataAnnotations;

namespace Fizzy_Airline.Dtos.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}