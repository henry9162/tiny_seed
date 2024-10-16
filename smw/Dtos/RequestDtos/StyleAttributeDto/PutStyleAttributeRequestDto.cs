using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.StyleAttributeDto
{
    public class PutStyleAttributeRequestDto : StyleAttributeRequestDto
    {
        public int Id { get; set; }
    }
}