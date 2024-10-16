using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.StyleAttributeDto
{
    public class StyleAttributeRequestDto
    {
        [Required]
        public string? Name {get; set;}
        [Required]
        public string? Sex { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
    }
}