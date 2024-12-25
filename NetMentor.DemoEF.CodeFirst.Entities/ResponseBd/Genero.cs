using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Entities.ResponseBd
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual HashSet<Pelicula> Peliculas { get; set; }
    }
}
