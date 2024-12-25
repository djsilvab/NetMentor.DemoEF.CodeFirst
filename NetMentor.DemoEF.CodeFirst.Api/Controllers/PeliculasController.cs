using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Entities.Dtos;
using NetMentor.DemoEF.CodeFirst.Entities.ResponseBd;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly NorthwindContext context;
        private readonly IMapper mapper;

        public PeliculasController(NorthwindContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("eagerLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDto>> GetEagerLoading(int id)
        {
            /*recomendable-utilizar*/
            var pelicula = await context
                                    .Peliculas
                                    .Include(p => p.Generos.OrderByDescending(x => x.Nombre))
                                    .Include(p => p.SalasDeCine)
                                        .ThenInclude(sc => sc.Cine)
                                    .Include(p => p.PeliculaActores)
                                        .ThenInclude(pa => pa.Actor)
                                    .FirstOrDefaultAsync(p => p.Id.Equals(id));

            var pelicutaDto = mapper.Map<PeliculaDto>(pelicula);
            //pelicutaDto.Cines = pelicutaDto.Cines.DistinctBy(x => x.Id).ToList();
            return pelicutaDto;
        }

        [HttpGet("selectLoading/{id:int}")]
        public async Task<ActionResult> GetSelectLoading(int id)
        {
            /*recomendable-utilizar*/
            var pelicula = await context
                                    .Peliculas
                                    .Select(p => new
                                    {
                                        p.Id,
                                        p.Titulo,
                                        Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre),
                                        PeliculasActores = p.PeliculaActores.Select(pa => new { 
                                            pa.ActorId,
                                            pa.Personaje,
                                            NombreActor = pa.Actor.Nombre
                                        }),
                                        CantCines = p.SalasDeCine.Select(sc => sc.Cine).Distinct().Count()
                                    })
                                    .FirstOrDefaultAsync(p => p.Id.Equals(id));

            return Ok(pelicula);
        }

        [HttpGet("explicitLoading/{id:int}")]
        public async Task<ActionResult<PeliculaDto>> GetExplicitLoading(int id)
        {
            var pelicula = await context.Peliculas.FirstOrDefaultAsync(p => p.Id.Equals(id));
            int CantGeneros = 0;

            if (pelicula is not null)
            {
                //await context.Entry(pelicula)
                //        .Collection(p => p.Generos)
                //        .LoadAsync();

                CantGeneros = await context.Entry(pelicula).Collection(p => p.Generos).Query().CountAsync();
            }

            var peliculaDto = mapper.Map<PeliculaDto>(pelicula);

            //return peliculaDto;

            return Ok(new
            {
                Pelicula = peliculaDto,
                CantGeneros
            });
           
        }

        [HttpGet("lazyLoading/{id:int}")]
        public async Task<ActionResult<List<PeliculaDto>>> GetLazyLoading(int id) 
        {
            var peliculas = await context.Peliculas.ToListAsync();
            var peliculasDto = mapper.Map<List<PeliculaDto>>(peliculas);
            return peliculasDto;
        }
    }
}
