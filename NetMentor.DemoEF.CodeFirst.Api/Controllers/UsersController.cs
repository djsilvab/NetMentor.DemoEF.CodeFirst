using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Entities;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NorthwindContext context;

        public UsersController(NorthwindContext context)
        {
            this.context = context;
        }

        [HttpPost("create")]
        public async Task AddUser()
        {
            User usr1 = new User
            {
                Email = $"{Guid.NewGuid()}@gmail.com",
                UserName = "username",
                WorkingExperiences = new List<WorkingExperience>
                {
                    new WorkingExperience{
                        Name = "experience-1",
                        Details = "details-1",
                        Environment = "Environment-1"
                    },
                    new WorkingExperience{
                        Name = "experience-2",
                        Details = "details-2",
                        Environment = "Environment-2"
                    }
                }
            };

            await context.Users.AddAsync(usr1);
            await context.SaveChangesAsync();

        }

        [HttpGet("{userId}")]
        public async Task<User?> GetOne(int userId)
            => await context.Users
                        .Include(x => x.WorkingExperiences)
                        .FirstOrDefaultAsync(x => x.Id.Equals(userId));
        
    }
}
