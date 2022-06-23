using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopersApi.Entities_Models
{
    public class GameEfConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.IdGame).HasName("Game_pk");
            builder.Property(e => e.IdGame).UseIdentityColumn();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RealeseDate).IsRequired();
            builder.Property(e => e.NeedVrImplement);

            builder.ToTable("Game");

            builder.HasData(new Game
            {
                IdGame = 1,
                Name = "The Party Hub",
                RealeseDate = new System.DateTime(2023, 3, 29),
                NeedVrImplement = 0
            });
        }
    }
}