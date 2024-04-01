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
    internal class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Age).IsRequired().HasPrecision(2, 0); // 0 a 99
            builder.Property(p => p.Number).IsRequired().HasPrecision(2, 0);
        }
    }
}
