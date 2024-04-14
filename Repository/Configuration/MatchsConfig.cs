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
    public class MatchsConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.MatchDate).IsRequired();

            // Relación con Club
            builder.HasOne(e => e.Club)
                   .WithMany()
                   .HasForeignKey(e => e.IdClubA)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con Stadium
            builder.HasOne(e => e.Venue)
                   .WithMany()
                   .HasForeignKey(e => e.IdStadium)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seedyng
            builder.HasData(
                new Match
                {
                    Id = 1,
                    MatchDate = new DateTime(2024, 4, 15), // (año, mes, día),
                    IdClubA = 1,
                    IdClubB = 2,
                    IdStadium = 1,
                    Result = "1 a 0"
                },
                new Match
                {
                    Id = 2,
                    MatchDate = new DateTime(2024, 4, 16),
                    IdClubA = 3,
                    IdClubB = 4,
                    IdStadium = 1,
                    Result = "3 a 1"
                }
                );
        }
    }
}
