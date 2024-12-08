using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Data.UnitOfWork;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Services
{
    public class CreateUserWithExperiencesService
    {        
        private readonly IUnitOfWork unitOfWork;

        public CreateUserWithExperiencesService(IUnitOfWork unitOfWork)
        {            
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(int id)
        {
            var user = new User
            {
                Email = $"{Guid.NewGuid()}@gmail.com",
                UserName = $"id-{id}"
            };

            var workingExperiences = new List<WorkingExperience>()
            {
                new WorkingExperience {
                    User = user,
                    Name = $"experience1 user {id}",
                    Details = "details-1",
                    Environment = "environment"
                },
                new WorkingExperience {
                    User = user,
                    Name = $"experience2 user {id}",
                    Details = "details-2",
                    Environment = "environment"
                }

            };

            await unitOfWork.UserRepository.Create(user);
            await unitOfWork.WorkingExperienceRepository.Create(workingExperiences);
            await unitOfWork.Save();            
        }
    }
}
