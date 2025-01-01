using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetMentor.DemoEF.CodeFirst.Data.Context;
using NetMentor.DemoEF.CodeFirst.Data.Repositories.Interfaz;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using Npgsql;

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

        public override async Task<User?> ReadOneById(int id)
            => await Entities.FromSqlInterpolated($"select * from get_user_by_id({id})")
                .FirstOrDefaultAsync();

        //public async Task<User?> GetById(int userId)
        //{
        //    using (var conn = new NpgsqlConnection(""))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand("select * from get_user_by_id(@user_id)", conn))
        //        {
        //            cmd.Parameters.AddWithValue("user_id", userId);

        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                if (reader.Read())
        //                {
        //                    int id = reader.GetInt32(reader.GetOrdinal("Id"));
        //                    string userName = reader.GetString(reader.GetOrdinal("UserName"));
        //                    string email = reader.GetString(reader.GetOrdinal("Email"));
        //                    byte state = reader.GetByte(reader.GetOrdinal("State"));
        //                    //DateTime? deletedTimeUtc = reader.IsDBNull(reader.GetOrdinal("DeletedTimeUtc"));
        //                    DateTime lastUpdateUtc = reader.GetDateTime(reader.GetOrdinal("LastUpdateTimeUtc"));

        //                    return new User(id, userName);
        //                }
        //            }

        //        }
        //    }
        //}
    }
}
