using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {        

        public UserRepository(NorthwindContext context)
            : base(context)
        {
            
        }

        public async Task<User?> ReadOneByIdWithWorkingExperiences(int userId)
            => await ReadAll()
                        .Include(x => x.WorkingExperiences)
                        .FirstOrDefaultAsync(x => x.Id.Equals(userId));

        public async Task<List<User>> ReadAllWithPagination(int pageNumber, int pageSize, string emailFilter)
        {
            IQueryable<User> queryable = Entities;

            if (!string.IsNullOrEmpty(emailFilter))
                queryable = queryable.Where(x => x.Email.Contains(emailFilter, StringComparison.OrdinalIgnoreCase));

            queryable = queryable.Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize);

            return await queryable.ToListAsync();
        }

        public async Task<List<User>> GovernmentUsers()
            => await Entities.Include(x => x.WorkingExperiences.Where(y => y.Name == "Government"))               
                             .ToListAsync();
    }
}
