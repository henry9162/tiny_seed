using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.FabricDto
{
    public class FabricResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Colors { get; set; }
        public List<FabricImage>? FabricImages { get; set; }
        public double Price { get; set; }
        public FabricSubCategory? FabricSubCategory { get; set; }
    }
}