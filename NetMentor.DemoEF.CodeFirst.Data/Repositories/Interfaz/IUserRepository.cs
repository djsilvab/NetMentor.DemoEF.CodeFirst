using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IUserRepository : IGenericRepository<User, int>
    {   
        Task<List<User>> ReadAllWithPagination(int pageNumber, int pageSize, string emailFilter);
        Task<User?> ReadOneByIdWithWorkingExperiences(int userId);
    }
}
