using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Repository.Configuration
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Age).IsRequired().HasPrecision(2, 0); // 0 a 99
            builder.Property(p => p.Number).IsRequired().HasPrecision(2, 0);

            // Seeding
            builder.HasData(
                // Boca Juniors
                new Player
                {
                    Id = 1,
                    FullName = "ROMERO Sergio",
                    Age = 37,
                    Number = 1,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 2,
                    FullName = "LEMA Cristian",
                    Age = 34,
                    Number = 2,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 3,
                    FullName = "SARACCHI Marcelo",
                    Age = 25,
                    Number = 3,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 4,
                    FullName = "FIGAL Nicolás",
                    Age = 34,
                    Number = 4,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 5,
                    FullName = "BULLAUDE Ezequiel",
                    Age = 23,
                    Number = 5,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 6,
                    FullName = "ROJO Marcos",
                    Age = 34,
                    Number = 6,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 7,
                    FullName = "ZEBALLOS Exequiel",
                    Age = 21,
                    Number = 7,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 8,
                    FullName = "FERNÁNDEZ Guillermo",
                    Age = 32,
                    Number = 8,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 9,
                    FullName = "BENEDETTO Darío",
                    Age = 34,
                    Number = 9,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 10,
                    FullName = "CAVANI Edison",
                    Age = 37,
                    Number = 10,
                    ClubId = 1,
                },
                new Player
                {
                    Id = 11,
                    FullName = "JANSON Lucas",
                    Age = 34,
                    Number = 11,
                    ClubId = 1,
                },
                // River Plate
                new Player
                {
                    Id = 12,
                    FullName = "ARMANI Franco",
                    Age = 37,
                    Number = 1,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 13,
                    FullName = "BOSELLI Sebastián",
                    Age = 21,
                    Number = 2,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 14,
                    FullName = "FUNES MORI Ramiro",
                    Age = 33,
                    Number = 3,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 15,
                    FullName = "FONSECA Nicolás",
                    Age = 35,
                    Number = 4,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 16,
                    FullName = "KRANEVITTER Matías",
                    Age = 30,
                    Number = 5,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 17,
                    FullName = "MARTÍNEZ David",
                    Age = 26,
                    Number = 6,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 18,
                    FullName = "PALAVECINO Agustín",
                    Age = 27,
                    Number = 8,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 19,
                    FullName = "LANZINI Manuel",
                    Age = 31,
                    Number = 10,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 20,
                    FullName = "DÍAZ Enzo",
                    Age = 28,
                    Number = 13,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 21,
                    FullName = "GONZÁLEZ PIREZ Leandro",
                    Age = 32,
                    Number = 14,
                    ClubId = 2,
                },
                new Player
                {
                    Id = 22,
                    FullName = "HERRERA Marcelo Andrés",
                    Age = 25,
                    Number = 14,
                    ClubId = 2,
                },


                // Argentinos Juniors
                   new Player
                   {
                       Id = 23,
                       FullName = "Diego Rodríguezs",
                       Age = 34,
                       Number = 50,
                       ClubId = 3,
                   },
                   new Player
                    {
                          Id = 24,
                          FullName = "Fernando Meza",
                          Age = 34,
                          Number = 18,
                          ClubId = 3,
                    },
                    new Player
                     {
                        Id = 25,
                        FullName = "Francisco Álvarez",
                        Age = 24,
                        Number = 16,
                         ClubId = 3,
                     },
                    new Player
                     {
                          Id = 26,
                          FullName = "Jonathan Galván",
                          Age = 31,
                          Number = 19,
                          ClubId = 3,
                     },
                    new Player
                    {
                        Id = 27,
                        FullName = "Román Vega",
                        Age = 20,
                        Number = 6,
                        ClubId = 3,
                    },
                     new Player
                     {
                         Id = 28,
                         FullName = "Alan Lescano ",
                         Age = 22,
                         Number = 22,
                         ClubId = 3,
                     },
                     new Player
                     {
                         Id = 29,
                         FullName = "Franco Moyano",
                         Age = 26,
                         Number = 17,
                         ClubId = 3,
                     },
                     new Player
                     {
                         Id = 30,
                         FullName = "Nicolás Oroz",
                         Age = 30,
                         Number = 21,
                         ClubId = 3,
                     },
                     new Player
                     {
                         Id = 31,
                         FullName = "José Herrera",
                         Age = 20,
                         Number = 26,
                         ClubId = 3,
                     },
                     new Player
                     {
                         Id = 32,
                         FullName = "Luciano Gondou",
                         Age = 22,
                         Number = 32,
                         ClubId = 3,
                     },
                     new Player
                     {
                         Id = 33,
                         FullName = "Maximiliano Romero",
                         Age = 25,
                         Number = 9,
                         ClubId = 3,
                     }
                );
        }
    }
}
