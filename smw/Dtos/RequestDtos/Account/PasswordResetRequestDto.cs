using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos
{
    public class PasswordResetRequestDto
    {
        public string? Token { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}