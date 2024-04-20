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
    public class TournamentClubConfig : IEntityTypeConfiguration<TournamentClub>
    {
        public void Configure(EntityTypeBuilder<TournamentClub> builder)
        {
            
            builder.Property(tc => tc.Id).ValueGeneratedOnAdd();
            builder.HasKey(tc => new { tc.IdClub, tc.IdTournament });
            builder
                .HasOne(t => t.Tournament)
                .WithMany(tc => tc.TournamentsClubs)
                .HasForeignKey(t => t.IdTournament);
            builder
                .HasOne(t => t.Club)
                .WithMany(tc => tc.Tournaments)
                .HasForeignKey(c => c.IdClub);
            builder.Property(tc => tc.Position);
            builder.Property(tc => tc.Points);
            builder.Property(tc => tc.MatchesPlayed);
            builder.Property(tc => tc.Wins);
            builder.Property(tc => tc.Loses);
            builder.Property(tc => tc.Draws);
            builder.Property(tc => tc.Goals);
            builder.Property(tc => tc.GoalsAgainst);
               
        }   

               
    }
}
