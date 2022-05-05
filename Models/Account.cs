using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fizzy_Airline.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        public Role Role { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token) 
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}