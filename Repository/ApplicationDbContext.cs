using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using System.Reflection;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Configuramos la convención MaxLength(150) para los tipo string ya que detectamos que es el que más usamos
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aplicando las configuraciones API Fluent que están en la carpeta Configuration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*
                // API Fluent Club
                modelBuilder.Entity<Club>().HasKey(c => c.Id); // Existe por convención
                modelBuilder.Entity<Club>().Property(c => c.Name).IsRequired().HasMaxLength(150);

                // API Fluent Player
                modelBuilder.Entity<Player>().HasKey(p => p.Id); // Existe por convención
                modelBuilder.Entity<Player>().Property(p => p.FullName).IsRequired().HasMaxLength(150);
                modelBuilder.Entity<Player>().Property(p => p.Age).IsRequired().HasPrecision(2, 0); // 0 a 99
                modelBuilder.Entity<Player>().Property(p => p.Number).IsRequired().HasPrecision(2, 0);
            */

        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        //public DbSet<Match> Matches { get; set; }
        //public DbSet<Stadium> Stadiums { get; set; }
        //public DbSet<Tournament> Tournaments { get; set; }

    }
}
