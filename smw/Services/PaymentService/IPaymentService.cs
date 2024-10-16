using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.PaymentDto;
using SMW.Models;

namespace SMW.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ServiceResponse<int>> Add(PaymentRequestDto PaymentData);
    }
}