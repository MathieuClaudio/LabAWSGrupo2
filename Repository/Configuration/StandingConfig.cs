using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class StandingConfig : IEntityTypeConfiguration<Standing>
    {
        public void Configure(EntityTypeBuilder<Standing> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            // Configurar ClubId como requerido
            builder.Property(e => e.IdClub).IsRequired();

            // Configurar la relación con Club
            builder.HasOne(e => e.Club)
                   .WithMany()
                   .HasForeignKey(e => e.IdClub)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seedyng
            builder.HasData(
                new Standing
                {
                    Id = 1,
                    Position = 1,
                    Points = 12,
                    MatchesPlayed = 6,
                    IdClub = 1
                },
                new Standing
                {
                    Id = 2,
                    Position = 2,
                    Points = 10,
                    MatchesPlayed = 5,
                    IdClub = 2
                },
                new Standing
                {
                    Id = 3,
                    Position = 3,
                    Points = 8,
                    MatchesPlayed = 4,
                    IdClub = 3
                },
                new Standing
                {
                    Id = 4,
                    Position = 4,
                    Points = 7,
                    MatchesPlayed = 4,
                    IdClub = 4
                }
                );
        }
    }
}
