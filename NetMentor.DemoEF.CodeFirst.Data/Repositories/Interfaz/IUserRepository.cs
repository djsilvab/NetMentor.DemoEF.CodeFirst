using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> ReadById(int id);
    }

}
