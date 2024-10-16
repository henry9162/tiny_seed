using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.ResponseDtos.StyleDto;
using SMW.Models;

namespace SMW.Dtos.RequestDtos.StyleDto
{
    public class PutStyleRequestDto : StyleRequestDto
    {
        public int Id { get; set; }
        public List<StyleImage>? StyleImages { get; set; }
        public StyleSubCategory? StyleSubCategory { get; set; }
        public List<StyleAttribute>? StyleAttributes { get; set; }
    }
}