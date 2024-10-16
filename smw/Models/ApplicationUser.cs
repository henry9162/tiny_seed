using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SMW.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public DateTime EmailConfirmedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime PasswordResetExpiry { get; set; }
        public DateTime PasswordResetAt { get; set; }
        public List<Address>? Addresses { get; set; }
        public SizeChart? SizeChart { get; set; }
        public List<CustomRequest>? CustomRequests { get; set; }
        public List<Payment>? Payment { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public string? OriginalImageName { get; set; }
    }
}