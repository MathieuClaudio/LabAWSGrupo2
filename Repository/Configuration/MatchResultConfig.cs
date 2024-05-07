using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Repository.Configuration
{
    public class MatchResultConfig : IEntityTypeConfiguration<MatchResult>
    {
        public void Configure(EntityTypeBuilder<MatchResult> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Match)
                   .WithMany()
                   .HasForeignKey(e => e.MatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new MatchResult
                {
                    Id = 1,
                    MatchId = 1,
                    LocalClubGoals = 3,
                    VisitorClubGoals = 1,

                },
                new MatchResult
                {
                    Id = 2,
                    MatchId = 2,
                    LocalClubGoals = 1,
                    VisitorClubGoals = 0,
                }
            );
        }
    }
}
