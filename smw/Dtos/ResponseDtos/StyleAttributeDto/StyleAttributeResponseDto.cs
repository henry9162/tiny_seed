using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.ResponseDtos.StyleAttributeDto
{
    public class StyleAttributeResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public double? Price { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
    }
}