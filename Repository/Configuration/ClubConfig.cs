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
            // modelBuilder.Entity<Club>().HasKey(c => c.Id); // Existe por convención
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
