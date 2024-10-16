using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.RequestDtos.FabricDto
{
    public class PutFabricRequestDto : FabricRequestDto
    {
        public int Id { get; set; }
        public List<FabricImage>? FabricImages { get; set; }
        public FabricSubCategory? FabricSubCategory { get; set; }
    }
}