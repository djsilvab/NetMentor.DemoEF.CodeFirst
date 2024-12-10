using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IUserRepository
    {
        Task<User> CreateOne(User user);
        Task<User?> ReadOneById(int id);
        Task<List<User>> ReadAll();
        Task UpdateOne(User user);
        Task<bool> Delete(int userId);
    }
}
