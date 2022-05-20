using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Services.Settings
{
    public interface IMailService
    {
        string GeneratePassword();
        string GenerateEmail();
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
