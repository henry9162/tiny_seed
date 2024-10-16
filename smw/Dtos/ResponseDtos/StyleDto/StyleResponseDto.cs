using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.ResponseDtos.StyleCategoryDto;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.StyleDto
{
    public class StyleResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Sex { get; set; }
        public string? Colors { get; set; }
        public int FabricSet { get; set; } // two piece, 3 piece. important for frontend to know
        public List<StyleImage>? StyleImages { get; set; }
        public StyleSubCategory? StyleSubCategory { get; set; }
        public List<StyleAttribute>? StyleAttributes { get; set; }
        public double Amount { get; set; }
    }
}