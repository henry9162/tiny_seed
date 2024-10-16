using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.FabricDto
{
    public class FabricRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public List<IFormFile>? ImageFiles { get; set; }
        [Required]
        public string? Colors { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
        [Required]
        public int FabricSubCategoryId { get; set; }
    }
}