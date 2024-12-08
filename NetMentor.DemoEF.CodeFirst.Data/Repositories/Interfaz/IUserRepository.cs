using NetMentor.DemoEF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> ReadById(int id);
    }

}
