using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.ResponseDtos.Account
{
    public class UserImageResponseDto
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
    }
}