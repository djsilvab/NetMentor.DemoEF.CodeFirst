using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               //new User { Id = 2, Name = "User-2", Email = "user_2@gmail.com" },
               //new User { Id = 3, Name = "User-3", Email = "user_3@gmail.com" }
               BuildUsers()
           );

            //builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        }

        private List<User> BuildUsers()
        {
            var users = new List<User>();
            foreach (var index in Enumerable.Range(5, 55))
            {
                users.Add(new User
                {
                    Email = $"example-{index}@gmail.com",
                    Id = index ,
                    UserName =$"user-name-{index}" 
                });
            }

            return users;
        }
    }
}
