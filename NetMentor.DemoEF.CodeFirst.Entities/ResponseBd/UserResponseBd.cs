using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class UserResponseBd
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte State { get; set; }
    }
}
