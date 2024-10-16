using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.ResponseDtos.Account
{
    public class UpdateUserResponseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string? State { get; set; }
        public string? LocalGovernment { get; set; } 
    }
}