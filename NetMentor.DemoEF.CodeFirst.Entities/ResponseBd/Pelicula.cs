using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }
        public virtual List<Genero> Generos { get; set; }
        public virtual HashSet<SalaDeCine> SalasDeCine { get; set; }
        public virtual HashSet<PeliculaActor> PeliculaActores { get; set; }
    }
}
