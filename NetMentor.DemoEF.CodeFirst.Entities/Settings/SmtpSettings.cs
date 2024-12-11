using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.Settings
{
    public class SmtpSettings
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string De { get; set; }
        public string Alias { get; set; }
    }
}
