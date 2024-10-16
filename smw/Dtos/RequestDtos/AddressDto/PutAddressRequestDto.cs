using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.AddressDto
{
    public class PutAddressRequestDto : AddressRequestDto
    {
        public int Id { get; set; }
    }
}