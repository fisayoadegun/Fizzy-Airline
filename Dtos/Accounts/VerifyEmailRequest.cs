using System.ComponentModel.DataAnnotations;

namespace Fizzy_Airline.Dtos.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}