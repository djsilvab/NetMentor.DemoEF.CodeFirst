using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadDataPostController : ControllerBase
    {
        private readonly NorthwindContext context;

        public LoadDataPostController(NorthwindContext context)
        {
            this.context = context;
        }

        [HttpGet("eager-loading")]
        public async Task<List<User>> EagerLoading()
            => await context.Users
                      .Include(x => x.WorkingExperiences)
                      .ToListAsync();

        [HttpGet("lazy-loading/{userId}")]
        public async Task<User?> LazyLoading(int userId)
        {
            User? user = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));

            if (user is not null)
            {
                var experiences = user.WorkingExperiences;
                if (experiences is not null && experiences.Any())
                {
                    Console.WriteLine("This user has experiences");
                }
            }

            return user;
        }

        [HttpGet("explicit-loading/{userId}")]
        public async Task<User?> ExplicitLoading(int userId)
        {
            User? user = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));

            if (user is not null)
            {
                await context.Entry(user)
                             .Collection(x => x.WorkingExperiences)
                             .LoadAsync();
                
                if (user.WorkingExperiences is not null && user.WorkingExperiences.Any())
                {
                    Console.WriteLine("This user has experiences");
                }
            }

            return user;
        }

    }
}
