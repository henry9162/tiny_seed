using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.AddressDto
{
    public class AddressResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string? State { get; set; } 
        public string? LocalGovernment { get; set; }
    }
}