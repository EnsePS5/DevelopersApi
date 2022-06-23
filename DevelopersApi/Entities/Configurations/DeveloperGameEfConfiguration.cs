using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopersApi.Entities_Models
{
    public class DeveloperGameEfConfiguration : IEntityTypeConfiguration<DeveloperGame>
    {
        public void Configure(EntityTypeBuilder<DeveloperGame> builder)
        {
            builder.HasKey(e => new { e.IdDeveloper, e.IdGame }).HasName("DeveloperGame_pk");

            builder.Property(e => e.Role).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.IdDeveloperNavigation)
                .WithMany(e => e.DeveloperGames)
                .HasForeignKey(e => e.IdDeveloper)
                .HasConstraintName("DeveloperGame_Developer")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.IdGameNavigation)
                .WithMany(e => e.DeveloperGames)
                .HasForeignKey(e => e.IdGame)
                .HasConstraintName("DeveloperGame_Game")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Developer_Game");

            builder.HasData(new DeveloperGame { 
            
                IdDeveloper = 2,
                IdGame = 1,
                Role = "Main Developer"

            });
            builder.HasData(new DeveloperGame
            {

                IdDeveloper = 1,
                IdGame = 1,
                Role = "Assistant"

            });
        }
    }
}