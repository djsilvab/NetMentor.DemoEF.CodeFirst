using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NorthwindContext context;

        public UserRepository(NorthwindContext context)
        {
            this.context = context;            
        }

        public async Task<User> CreateOne(User user)
        {
            EntityEntry<User> insertedUser = await context.Users.AddAsync(user);
            //await context.SaveChangesAsync();
            return insertedUser.Entity;
        }        

        public async Task<User?> ReadOneById(int id)
            => await context.Users.Include(x => x.WorkingExperiences).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<User>> ReadAll()
            => await context.Users.ToListAsync();

        public async Task UpdateOne(User user)
            => await Task.FromResult(() => context.Users.Update(user));

        public async Task<bool> Delete(int userId)
        {
            User? user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null) context.Users.Remove(user);
            return true;
        }
    }
}
