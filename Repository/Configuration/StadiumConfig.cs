using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Repository.Configuration
{
    public class StadiumConfig : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            // Seeding
            builder.HasData(
                new Stadium
                {
                    Id = 1,
                    Name = "Monumental",
                },
                new Stadium
                {
                    Id = 2,
                    Name = "Libertadores de América",
                },
                new Stadium
                {
                    Id = 3,
                    Name = "Malvinas Argentinas",
                },
                new Stadium
                {
                    Id = 4,
                    Name = "Nueva Chicago",
                },
                new Stadium
                {
                    Id = 5,
                    Name = "Diego Armando Maradona",
                }
                );
        }
    }
}
