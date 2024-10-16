using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMW.Dtos.RequestDtos.PaymentDto;
using SMW.Services.PaymentService;

namespace SMW.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PaymentRequestDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _paymentService.Add(paymentDto);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}