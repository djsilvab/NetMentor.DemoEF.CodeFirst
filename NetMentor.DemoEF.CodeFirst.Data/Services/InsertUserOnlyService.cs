using NetMentor.DemoEF.CodeFirst.Data.UnitOfWork;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Services
{
    public class InsertUserOnlyService
    {
        private readonly IUnitOfWork unitOfWork;

        public InsertUserOnlyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(int id)
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
                },
                new WorkingExperience {
                    User = user,
                    Name = $"experience3 user {id}",
                    Details = "details-3",
                    Environment = "environment"
                }
            };

            _ = await unitOfWork.UserRepository.CreateOne(user);
            await unitOfWork.WorkingExperienceRepository.CreateOne(workingExperiences);
            _ = await unitOfWork.Save();
            return true;
        }

    }
}
