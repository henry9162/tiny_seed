using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.StyleSubCategoryDto
{
    public class StyleSubCategoryResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public StyleCategory? StyleCategory { get; set; }
        public List<Style>? Styles { get; set; }
    }
}