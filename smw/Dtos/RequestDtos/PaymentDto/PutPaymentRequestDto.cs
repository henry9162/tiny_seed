using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.PaymentDto
{
    public class PutPaymentRequestDto : PaymentRequestDto
    {
        public int Id { get; set; }
    }
}