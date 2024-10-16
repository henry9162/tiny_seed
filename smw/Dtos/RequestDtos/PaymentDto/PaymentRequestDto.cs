using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.PaymentDto
{
    public class PaymentRequestDto
    {
        public int GatewayRequestId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public int CustomRequestId { get; set; }
        public string? UserId { get; set; }
    }
}