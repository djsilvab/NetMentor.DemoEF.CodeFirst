using Microsoft.Extensions.Options;
using NetMentor.DemoEF.CodeFirst.Data.Services.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Settings;
using ROP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Services
{
    public class SenderSmptService : ISenderSmtpService
    {
        private readonly SmtpSettings smtpSettings;

        //public SenderSmptService(SmtpSettings smptSettings)
        //{
        //    this.smptSettings = smptSettings;
        //}

        //public SenderSmptService(IOptions<SmtpSettings> config)
        //{
        //    smptSettings = config.Value;                                           
        //}

        //public SenderSmptService(IOptionsSnapshot<SmtpSettings> config)
        //{
        //    this.smptSettings = config.Value;                
        //}

        private SmtpSettings smtpSettingsMonitor => optionsMonitor.CurrentValue;
        private readonly IOptionsMonitor<SmtpSettings> optionsMonitor;
        public SenderSmptService(IOptionsMonitor<SmtpSettings> config)
        {
            this.optionsMonitor = config;
        }

        public async Task<Result<bool>> SendEmail(string to, string subject, string body)
        {
            Console.WriteLine("this simulates the an email being sent");
            Console.WriteLine($"Email configuration Server: {smtpSettings.Servidor}, From: {smtpSettings.De}");
            Console.WriteLine($"Email data To: {to}, subject: {subject}, body: {body}");

            return await Task.FromResult(true);
        }

        private async Task<Result<bool>> SendEmail2(string to, string subject, string body)
        {
            Console.WriteLine("this simulates the an email being sent");
            Console.WriteLine($"Email configuration Server: {smtpSettingsMonitor.Servidor}, From: {smtpSettingsMonitor.De}");
            Console.WriteLine($"Email data To: {to}, subject: {subject}, body: {body}");

            return await Task.FromResult(true);
        }

    }
}
