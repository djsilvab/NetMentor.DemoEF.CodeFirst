using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories
{
    public class WorkingExperienceRepository : IWorkingExperienceRepository
    {
        private readonly NorthwindContext context;

        public WorkingExperienceRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public async Task Create(List<WorkingExperience> workingExperiences)
            => await context.WorkingExperiences.AddRangeAsync(workingExperiences);
    }
}
