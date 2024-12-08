using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NorthwindContext context;

        public UserRepository(NorthwindContext context)
        {
            this.context = context;            
        }

        public async Task<User> Create(User user)
        {
            EntityEntry<User> insertedUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return insertedUser.Entity;
        }

        public async Task<User?> ReadById(int id)
            => await context.Users.Include(x => x.WorkingExperiences).FirstOrDefaultAsync(x => x.Id == id);
    }
}
