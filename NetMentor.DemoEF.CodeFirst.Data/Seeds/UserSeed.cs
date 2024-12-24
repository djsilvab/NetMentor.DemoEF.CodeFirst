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
                    Id = index,
                    Email = $"example-{index}@gmail.com",                    
                    UserName =$"user-name-{index}",
                    State = 1
                });
            }            

            return users;
        }
    }
}
