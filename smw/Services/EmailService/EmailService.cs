using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.VisualBasic;
using MimeKit;
using MimeKit.Text;
using SMW.Dtos.RequestDtos.Email;
using SMW.Models;

namespace SMW.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            this._config = config;
        }
        public ServiceResponse<int> SendEmail(EmailRequestDto request)
        {
            var response = new ServiceResponse<int>();
            var email = new MimeMessage();
            var emailHost = _config.GetSection("Email:EmailHost").Value;
            var emailUsername = _config.GetSection("Email:EmailUsername").Value;
            var emailPassword = _config.GetSection("Email:EmailPassword").Value;

            email.From.Add(MailboxAddress.Parse(emailUsername));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            try
            {
                using var smtp = new SmtpClient();
                smtp.Timeout = 10000;
                smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailUsername, emailPassword);
                smtp.Send(email);
                smtp.Disconnect(true);

                response.Success = true;
                response.Message = "Email sent successfully";
                response.Data = 1;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = 0;
            }

            return response;
        }
    }
}