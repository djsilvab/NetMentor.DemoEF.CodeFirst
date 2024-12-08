using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

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
