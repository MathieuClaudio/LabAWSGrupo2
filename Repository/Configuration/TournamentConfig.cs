using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Configuration
{
    public class TournamentConfig : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Tournament
                {
                    Id = 1,
                    Name= "Apertura 2024",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2024,12,10),

                }
            );
        }
    }
}
