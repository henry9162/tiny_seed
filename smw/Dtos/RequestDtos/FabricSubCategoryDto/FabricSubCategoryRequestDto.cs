using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.FabricSubCategoryDto
{
    public class FabricSubCategoryRequestDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int FabricCategoryId { get; set; }
    }
}