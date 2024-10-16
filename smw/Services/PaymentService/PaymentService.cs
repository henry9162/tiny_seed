using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SMW.Data;
using SMW.Dtos.RequestDtos.PaymentDto;
using SMW.Models;

namespace SMW.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PaymentService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> Add(PaymentRequestDto PaymentData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var payment = _mapper.Map<Payment>(PaymentData);
                
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                response.Data = 1;

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }
    }
}