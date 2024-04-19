﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240414230953_Add-Standing")]
    partial class AddStanding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
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

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdClubA")
                        .HasColumnType("int");

                    b.Property<int>("IdClubB")
                        .HasColumnType("int");

                    b.Property<int>("IdStadium")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdClubA");

                    b.HasIndex("IdClubB");

                    b.HasIndex("IdStadium");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdClubA = 1,
                            IdClubB = 2,
                            IdStadium = 1,
                            MatchDate = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Result = "1 a 0"
                        },
                        new
                        {
                            Id = 2,
                            IdClubA = 3,
                            IdClubB = 4,
                            IdStadium = 1,
                            MatchDate = new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Result = "3 a 1"
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

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdClub")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClub");

                    b.ToTable("Standings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdClub = 1,
                            MatchesPlayed = 6,
                            Points = 12,
                            Position = 1
                        },
                        new
                        {
                            Id = 2,
                            IdClub = 2,
                            MatchesPlayed = 5,
                            Points = 10,
                            Position = 2
                        },
                        new
                        {
                            Id = 3,
                            IdClub = 3,
                            MatchesPlayed = 4,
                            Points = 8,
                            Position = 3
                        },
                        new
                        {
                            Id = 4,
                            IdClub = 4,
                            MatchesPlayed = 4,
                            Points = 7,
                            Position = 4
                        });
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Claudio",
                            Password = "123",
                            UserName = "claudio"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nicolás",
                            Password = "123",
                            UserName = "nicolas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Emanuel",
                            Password = "123",
                            UserName = "emanuel"
                        });
                });

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.HasOne("Model.Entities.Club", "ClubA")
                        .WithMany()
                        .HasForeignKey("IdClubA")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entities.Club", "ClubB")
                        .WithMany()
                        .HasForeignKey("IdClubB")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entities.Stadium", "Venue")
                        .WithMany()
                        .HasForeignKey("IdStadium")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClubA");

                    b.Navigation("ClubB");

                    b.Navigation("Venue");
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

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithMany()
                        .HasForeignKey("IdClub")
                        .OnDelete(DeleteBehavior.Restrict)
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
