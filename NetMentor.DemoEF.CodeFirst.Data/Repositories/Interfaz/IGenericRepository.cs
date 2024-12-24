using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz
{
    public interface IGenericRepository<T, TId>
    {
        Task<T> CreateOne(T value);
        Task<T?> ReadOneById(TId id);
        IQueryable<T> ReadAll();
        void UpdateOne(T value);
        Task<bool> DeleteOneSof(TId id);
        Task<bool> DeleteOneHard(TId id);
    }
}
