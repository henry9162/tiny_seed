using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.PaymentDto
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public int GatewayRequestId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public CustomRequest? CustomRequest { get; set; }
        public ApplicationUser? User { get; set; }
    }
}