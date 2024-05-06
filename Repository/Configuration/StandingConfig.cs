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

            builder.HasOne(e => e.Tournament)
                   .WithMany()
                   .HasForeignKey(e => e.TournamentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seedyng
            builder.HasData(
                new Standing
                {
                    Id = 1,
                    TournamentId = 1,
                    IdClub = 1

                },
                new Standing
                {
                    Id = 2,
                    TournamentId = 1,
                    IdClub = 2
                },
                new Standing
                {
                    Id = 3,
                    TournamentId = 1,
                    IdClub = 3
                },
                new Standing
                {
                    Id = 4,
                    TournamentId = 1,
                    IdClub = 4
                }
                );
        }
    }
}