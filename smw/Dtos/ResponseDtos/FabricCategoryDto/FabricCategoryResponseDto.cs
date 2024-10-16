using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.FabricCategoryDto
{
    public class FabricCategoryResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<FabricSubCategory>? FabricSubCategories { get; set; }
    }
}