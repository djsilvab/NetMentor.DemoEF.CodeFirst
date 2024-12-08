using Microsoft.AspNetCore.Mvc;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Data.Services;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly CreateUserWithExperiencesService userExperienceService;

        public UsersController(IUserRepository userRepository,
                                CreateUserWithExperiencesService userExperienceService
        )
        {
            this.userRepository = userRepository;                
            this.userExperienceService = userExperienceService;
        }

        [HttpPost("{newId}")]
        public async Task Create(int newId)
            => await userExperienceService.Execute(newId);


        [HttpPost("add")]
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
