using Microsoft.AspNetCore.Mvc;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Data.Services;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System.Linq;
using System.Collections.Generic;


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

            await userRepository.CreateOne(usr1);

        }

        [HttpGet("{userId}")]
        public async Task<User?> GetOne(int userId)
            => await userRepository.ReadOneById(userId);

        [HttpGet("iqueryablepagination")]
        public async Task<ActionResult<List<User>>> QueryablePagination(int pageNumber, int pageSize, string emailFilter)
        {
            var allUsers = await userRepository.ReadAll();

            IQueryable<User> queryable = allUsers.AsQueryable();   

            if (!string.IsNullOrEmpty(emailFilter))
            {
                queryable = queryable.Where(x => x.Email.Contains(emailFilter, StringComparison.OrdinalIgnoreCase));
            }

            queryable = queryable.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);

            return queryable.ToList();
                              
        }
        
    }
}
