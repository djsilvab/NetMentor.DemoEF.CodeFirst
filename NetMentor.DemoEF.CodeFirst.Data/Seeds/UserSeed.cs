using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetMentor.DemoEF.CodeFirst.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           // builder.HasData(               
           //    new User { Id = 2, Name = "User-2", Email = "user_2@gmail.com" },
           //    new User { Id = 3, Name = "User-3", Email = "user_3@gmail.com" }
           //);

            //builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        }
    }
}
