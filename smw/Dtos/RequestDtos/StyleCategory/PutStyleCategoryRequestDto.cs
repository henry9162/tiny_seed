using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.StyleCategory
{
    public class PutStyleCategoryRequestDto : StyleCategoryRequestDto
    {
        public int Id { get; set; }
    }
}