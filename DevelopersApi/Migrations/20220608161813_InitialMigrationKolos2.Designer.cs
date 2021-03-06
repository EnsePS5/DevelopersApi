// <auto-generated />
using System;
using DevelopersApi.Entities_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevelopersApi.Migrations
{
    [DbContext(typeof(DevStudioDbContext))]
    [Migration("20220608161813_InitialMigrationKolos2")]
    partial class InitialMigrationKolos2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevelopersApi.Entities_Models.Developer", b =>
                {
                    b.Property<int>("IdDeveloper")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDeveloper")
                        .HasName("Developer_pk");

                    b.ToTable("Developer");

                    b.HasData(
                        new
                        {
                            IdDeveloper = 1,
                            DateOfJoin = new DateTime(2022, 6, 8, 18, 18, 13, 10, DateTimeKind.Local).AddTicks(826),
                            Firstname = "James",
                            Lastname = "Scott"
                        },
                        new
                        {
                            IdDeveloper = 2,
                            DateOfJoin = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Kacper",
                            Lastname = "Godlewski"
                        });
                });

            modelBuilder.Entity("DevelopersApi.Entities_Models.DeveloperGame", b =>
                {
                    b.Property<int>("IdDeveloper")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDeveloper", "IdGame")
                        .HasName("DeveloperGame_pk");

                    b.HasIndex("IdGame");

                    b.ToTable("Developer_Game");

                    b.HasData(
                        new
                        {
                            IdDeveloper = 2,
                            IdGame = 1,
                            Role = "Main Developer"
                        },
                        new
                        {
                            IdDeveloper = 1,
                            IdGame = 1,
                            Role = "Assistant"
                        });
                });

            modelBuilder.Entity("DevelopersApi.Entities_Models.Game", b =>
                {
                    b.Property<int>("IdGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("NeedVrImplement")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RealeseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdGame")
                        .HasName("Game_pk");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            IdGame = 1,
                            Name = "The Party Hub",
                            NeedVrImplement = (byte)0,
                            RealeseDate = new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DevelopersApi.Entities_Models.DeveloperGame", b =>
                {
                    b.HasOne("DevelopersApi.Entities_Models.Developer", "IdDeveloperNavigation")
                        .WithMany("DeveloperGames")
                        .HasForeignKey("IdDeveloper")
                        .HasConstraintName("DeveloperGame_Developer")
                        .IsRequired();

                    b.HasOne("DevelopersApi.Entities_Models.Game", "IdGameNavigation")
                        .WithMany("DeveloperGames")
                        .HasForeignKey("IdGame")
                        .HasConstraintName("DeveloperGame_Game")
                        .IsRequired();

                    b.Navigation("IdDeveloperNavigation");

                    b.Navigation("IdGameNavigation");
                });

            modelBuilder.Entity("DevelopersApi.Entities_Models.Developer", b =>
                {
                    b.Navigation("DeveloperGames");
                });

            modelBuilder.Entity("DevelopersApi.Entities_Models.Game", b =>
                {
                    b.Navigation("DeveloperGames");
                });
#pragma warning restore 612, 618
        }
    }
}
