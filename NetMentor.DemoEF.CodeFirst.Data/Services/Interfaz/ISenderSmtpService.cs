using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ROP;

namespace NetMentor.DemoEF.CodeFirst.Data.Services.Interfaz
{
    public interface ISenderSmtpService
    {
        Task<Result<bool>> SendEmail(string to, string subject, string body);
    }
}
