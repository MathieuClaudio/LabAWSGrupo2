using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Repository.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Name).IsRequired();

            // Seedyng
            builder.HasData(
                                new User
                                {
                                    Id = 1,
                                    UserName = "claudio",
                                    Password = "123",
                                    Name = "Claudio",
                                },
                                new User
                                {
                                    Id = 2,
                                    UserName = "nicolas",
                                    Password = "123",
                                    Name = "Nicolás"
                                },
                                new User
                                {
                                    Id = 3,
                                    UserName = "emanuel",
                                    Password = "123",
                                    Name = "Emanuel"
                                }
                            );
        }
    }
}
