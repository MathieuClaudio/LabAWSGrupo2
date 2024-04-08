using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    // Configurando API Fluent para Club
    internal class ClubConfig : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.Property(c => c.Name).IsRequired();

            // Seedyng
            builder.HasData(
                new Club
                { 
                    Id = 1,
                    Name = "Boca Juniors",
                },
                new Club
                {
                    Id = 2,
                    Name = "River Plate",
                },
                new Club
                {
                    Id = 3,
                    Name = "Argentinos Juniors",
                },
                new Club
                {
                    Id = 4,
                    Name = "Belgrano",
                },
                new Club
                {
                    Id = 5,
                    Name = "Estudiantes",
                },
                new Club
                {
                    Id = 6,
                    Name = "Huracán",
                },
                new Club
                {
                    Id = 7,
                    Name = "Independiente",
                },
                new Club
                {
                    Id = 8,
                    Name = "Lanús",
                },
                new Club
                {
                    Id = 9,
                    Name = "Tigre",
                },
                new Club
                {
                    Id = 10,
                    Name = "Vélez",
                }
                );
        }
    }
}
