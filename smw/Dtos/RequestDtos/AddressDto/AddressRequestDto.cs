using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.AddressDto
{
    public class AddressRequestDto
    {
        public string? Title { get; set; }
        [Required]
        public string? StreetName { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public int LocalGovernmentId { get; set; } 
        [Required]
        public int StateId { get; set; }
        [Required]
        public string? UserId { get; set; }
    }
}