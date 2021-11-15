using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Travel.Application.Common.Interfaces;

namespace Travel.Shared.Services
{
    public class EmailService : IEmailService
    {


        public async Task SendAsync(EmailDto request)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(request.From ?? MailSettings.EmailFrom)
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
