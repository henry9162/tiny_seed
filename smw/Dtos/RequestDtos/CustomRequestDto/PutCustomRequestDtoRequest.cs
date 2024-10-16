using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.CustomRequestDto
{
    public class PutCustomRequestDtoRequest
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string? AdminComment { get; set; }
    }
}