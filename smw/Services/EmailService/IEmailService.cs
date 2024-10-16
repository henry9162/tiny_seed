using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.Email;
using SMW.Models;

namespace SMW.Services.EmailService
{
    public interface IEmailService
    {
        ServiceResponse<int> SendEmail(EmailRequestDto request);
    }
}