using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Seeds;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using NetMentor.DemoEF.CodeFirst.Entities.ResponseBd;

namespace NetMentor.DemoEF.CodeFirst.Data.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkingExperience> WorkingExperiences { get; set; }
        public DbSet<UserResponseBd> UsersResponseBd { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //        .HasQueryFilter(a => a.State > 0);

            //builder.Entity<User>()
            //    .HasData(
            //        new User { UserId = 1, Name = "User-1", Email = "user_1@gmail.com" },
            //        new User { UserId = 2, Name = "User-2", Email = "user_2@gmail.com" }
            //    );

            //builder.ApplyConfigurationsFromAssembly(); //=> net 2.2
            builder.ApplyConfiguration(new UserSeed());
            builder.ApplyConfiguration(new WorkingExperienceSeed());

        }

    }
}
