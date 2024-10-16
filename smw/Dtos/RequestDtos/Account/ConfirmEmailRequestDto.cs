using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos
{
    public record struct ConfirmEmailRequestDto(string Token);
}