using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IWorkingExperienceRepository WorkingExperienceRepository { get; }

        Task<int> Save();
    }
}
