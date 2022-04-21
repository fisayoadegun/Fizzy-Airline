using System.ComponentModel.DataAnnotations;

namespace Fizzy_Airline.Dtos.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}