using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext context;

        public IUserRepository UserRepository { get; }
        public IWorkingExperienceRepository WorkingExperienceRepository { get; }

        public UnitOfWork(NorthwindContext context, 
                            IUserRepository UserRepository, 
                            IWorkingExperienceRepository WorkingExperienceRepository)
        {
            this.context = context;
            this.UserRepository = UserRepository;
            this.WorkingExperienceRepository = WorkingExperienceRepository;
        }

        public async Task<int> Save()
        {            
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Conflicto de concurrencia");                  
            }
            return 0;
        }

        public void Dispose() => context.Dispose();
    }
}
