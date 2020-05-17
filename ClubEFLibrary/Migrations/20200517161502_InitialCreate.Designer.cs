﻿// <auto-generated />
using System;
using ClubEFLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubEFLibrary.Migrations
{
    [DbContext(typeof(ClubContext))]
    [Migration("20200517161502_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("libraryClubEF.Speler", b =>
                {
                    b.Property<int>("SpelerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RugNummer")
                        .HasColumnType("int");

                    b.Property<string>("SpelerNaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamStamNummer")
                        .HasColumnType("int");

                    b.Property<double>("Waarde")
                        .HasColumnType("float");

                    b.HasKey("SpelerId");

                    b.HasIndex("TeamStamNummer");

                    b.ToTable("Spelers");
                });

            modelBuilder.Entity("libraryClubEF.Team", b =>
                {
                    b.Property<int>("StamNummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamBijnaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamNaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trainer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StamNummer");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("libraryClubEF.Transfer", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SpelerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TransferPrijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TransferId");

                    b.HasIndex("SpelerId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("libraryClubEF.Speler", b =>
                {
                    b.HasOne("libraryClubEF.Team", "Team")
                        .WithMany("spelers")
                        .HasForeignKey("TeamStamNummer");
                });

            modelBuilder.Entity("libraryClubEF.Transfer", b =>
                {
                    b.HasOne("libraryClubEF.Speler", "Speler")
                        .WithMany()
                        .HasForeignKey("SpelerId");
                });
#pragma warning restore 612, 618
        }
    }
}
