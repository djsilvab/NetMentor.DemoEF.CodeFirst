using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class PeliculaActor
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
