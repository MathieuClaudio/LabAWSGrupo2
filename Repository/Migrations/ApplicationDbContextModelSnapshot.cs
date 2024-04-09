﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Boca Juniors"
                        },
                        new
                        {
                            Id = 2,
                            Name = "River Plate"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Argentinos Juniors"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Belgrano"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Estudiantes"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Huracán"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Independiente"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Lanús"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Tigre"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Vélez"
                        });
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Number")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 37,
                            ClubId = 1,
                            FullName = "ROMERO Sergio",
                            Number = 1
                        },
                        new
                        {
                            Id = 2,
                            Age = 34,
                            ClubId = 1,
                            FullName = "LEMA Cristian",
                            Number = 2
                        },
                        new
                        {
                            Id = 3,
                            Age = 25,
                            ClubId = 1,
                            FullName = "SARACCHI Marcelo",
                            Number = 3
                        },
                        new
                        {
                            Id = 4,
                            Age = 34,
                            ClubId = 1,
                            FullName = "FIGAL Nicolás",
                            Number = 4
                        },
                        new
                        {
                            Id = 5,
                            Age = 23,
                            ClubId = 1,
                            FullName = "BULLAUDE Ezequiel",
                            Number = 5
                        },
                        new
                        {
                            Id = 6,
                            Age = 34,
                            ClubId = 1,
                            FullName = "ROJO Marcos",
                            Number = 6
                        },
                        new
                        {
                            Id = 7,
                            Age = 21,
                            ClubId = 1,
                            FullName = "ZEBALLOS Exequiel",
                            Number = 7
                        },
                        new
                        {
                            Id = 8,
                            Age = 32,
                            ClubId = 1,
                            FullName = "FERNÁNDEZ Guillermo",
                            Number = 8
                        },
                        new
                        {
                            Id = 9,
                            Age = 34,
                            ClubId = 1,
                            FullName = "BENEDETTO Darío",
                            Number = 9
                        },
                        new
                        {
                            Id = 10,
                            Age = 37,
                            ClubId = 1,
                            FullName = "CAVANI Edison",
                            Number = 10
                        },
                        new
                        {
                            Id = 11,
                            Age = 34,
                            ClubId = 1,
                            FullName = "JANSON Lucas",
                            Number = 11
                        },
                        new
                        {
                            Id = 12,
                            Age = 37,
                            ClubId = 2,
                            FullName = "ARMANI Franco",
                            Number = 1
                        },
                        new
                        {
                            Id = 13,
                            Age = 21,
                            ClubId = 2,
                            FullName = "BOSELLI Sebastián",
                            Number = 2
                        },
                        new
                        {
                            Id = 14,
                            Age = 33,
                            ClubId = 2,
                            FullName = "FUNES MORI Ramiro",
                            Number = 3
                        },
                        new
                        {
                            Id = 15,
                            Age = 35,
                            ClubId = 2,
                            FullName = "FONSECA Nicolás",
                            Number = 4
                        },
                        new
                        {
                            Id = 16,
                            Age = 30,
                            ClubId = 2,
                            FullName = "KRANEVITTER Matías",
                            Number = 5
                        },
                        new
                        {
                            Id = 17,
                            Age = 26,
                            ClubId = 2,
                            FullName = "MARTÍNEZ David",
                            Number = 6
                        },
                        new
                        {
                            Id = 18,
                            Age = 27,
                            ClubId = 2,
                            FullName = "PALAVECINO Agustín",
                            Number = 8
                        },
                        new
                        {
                            Id = 19,
                            Age = 31,
                            ClubId = 2,
                            FullName = "LANZINI Manuel",
                            Number = 10
                        },
                        new
                        {
                            Id = 20,
                            Age = 28,
                            ClubId = 2,
                            FullName = "DÍAZ Enzo",
                            Number = 13
                        },
                        new
                        {
                            Id = 21,
                            Age = 32,
                            ClubId = 2,
                            FullName = "GONZÁLEZ PIREZ Leandro",
                            Number = 14
                        },
                        new
                        {
                            Id = 22,
                            Age = 25,
                            ClubId = 2,
                            FullName = "HERRERA Marcelo Andrés",
                            Number = 14
                        });
                });

            modelBuilder.Entity("Model.Entities.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Monumental"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Libertadores de América"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Malvinas Argentinas"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nueva Chicago"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Diego Armando Maradona"
                        });
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
