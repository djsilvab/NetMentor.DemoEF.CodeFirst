using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;                
        }


        [HttpPost("create")]
        public async Task AddUser()
        {
            User usr1 = new User
            {
                Email = $"{Guid.NewGuid()}@gmail.com",
                UserName = "username-djsilvab",
                WorkingExperiences = new List<WorkingExperience>
                {
                    new WorkingExperience{
                        Name = "experience-101",
                        Details = "details-101",
                        Environment = "Environment-101"
                    },
                    new WorkingExperience{
                        Name = "experience-102",
                        Details = "details-102",
                        Environment = "Environment-102"
                    }
                }
            };

            await userRepository.Create(usr1);

        }

        [HttpGet("{userId}")]
        public async Task<User?> GetOne(int userId)
            => await userRepository.ReadById(userId);
        
    }
}
