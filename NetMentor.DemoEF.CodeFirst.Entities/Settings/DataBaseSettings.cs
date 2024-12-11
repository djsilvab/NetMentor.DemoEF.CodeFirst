using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.Settings
{
    public class DataBaseSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool AllowUserVariables { get; set; }
    }
}
