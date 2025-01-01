using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories
{
    public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId>
        where T : BaseEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly NorthwindContext context;
        protected DbSet<T> Entities => context.Set<T>();

        protected GenericRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public virtual async Task<T?> ReadOneById(TId id)
            => await Entities.FirstOrDefaultAsync(x => x.Id.Equals(id));                     

        public IQueryable<T> ReadAll()
           => Entities;

        public async Task<T> CreateOne(T value)
        {            
            EntityEntry<T> result = await Entities.AddAsync(value);
            return result.Entity;
        }

        public void UpdateOne(T value)
        {
            value.LastUpdateTimeUtc = DateTime.UtcNow;
            Entities.Update(value);
        }

        public async Task<bool> DeleteOneHard(TId id)
        {
            T? entity = await ReadOneById(id);
            if(entity is null) return false;

            Entities.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteOneSof(TId id)
        {
            T? entity = await ReadOneById(id);

            if (entity == null) return false;
            
            entity.State = 0;
            entity.DeletedTimeUtc = DateTime.UtcNow;

            UpdateOne(entity);
            return true;
        }
       
    }
}
