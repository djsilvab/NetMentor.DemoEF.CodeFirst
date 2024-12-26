using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual HashSet<SalaDeCine> SalasDeCine { get; set; }


    }
}
