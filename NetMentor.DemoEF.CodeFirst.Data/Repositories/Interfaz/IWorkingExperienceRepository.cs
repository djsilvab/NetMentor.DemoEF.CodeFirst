using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IWorkingExperienceRepository
    {
        Task Create(List<WorkingExperience> workingExperiences);
    }
}
