using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.RequestDtos.FabricCategoryDto
{
    public class PutFabricCategoryRequestDto : FabricCategoryRequestDto
    {
        public int Id { get; set; }
        public List<FabricSubCategory>? FabricSubCategories { get; set; }
    }
}