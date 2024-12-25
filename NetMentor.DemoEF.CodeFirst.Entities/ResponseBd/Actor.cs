using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public virtual HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
