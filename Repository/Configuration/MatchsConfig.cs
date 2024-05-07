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
            builder.HasOne(e => e.LocalClub)
                   .WithMany()
                   .HasForeignKey(e => e.LocalClubId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.VisitorClub)
                   .WithMany()
                   .HasForeignKey(e => e.VisitorClubId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con Stadium
            builder.HasOne(e => e.Venue)
                   .WithMany()
                   .HasForeignKey(e => e.IdStadium)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seeding
            builder.HasData(
                new Match
                {
                    Id = 1,
                    MatchDate = new DateTime(2024, 4, 15), // (año, mes, día),
                    LocalClubId = 1,
                    VisitorClubId = 2,
                    IdTournament = 1,
                    IdStadium = 1
                    
                },
                new Match
                {
                    Id = 2,
                    MatchDate = new DateTime(2024, 4, 16),
                    LocalClubId = 3,
                    VisitorClubId = 4,
                    IdTournament = 1,
                    IdStadium = 1
                }
                );
        }
    }
}
