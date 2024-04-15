using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

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
            builder.HasOne(e => e.ClubA)
                   .WithMany()
                   .HasForeignKey(e => e.IdClubA)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ClubB)
                   .WithMany()
                   .HasForeignKey(e => e.IdClubB)
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
                    Result = "1 a 0",
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
