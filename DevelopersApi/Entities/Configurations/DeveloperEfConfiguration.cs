using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopersApi.Entities_Models
{
    public class DeveloperEfConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(e => e.IdDeveloper).HasName("Developer_pk");
            builder.Property(e => e.IdDeveloper).UseIdentityColumn();

            builder.Property(e => e.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DateOfJoin).IsRequired();

            builder.ToTable("Developer");

            builder.HasData(new Developer { 
                IdDeveloper = 1,
                Firstname = "James",
                Lastname = "Scott",
                DateOfJoin = System.DateTime.Now
            });
            builder.HasData(new Developer
            {
                IdDeveloper = 2,
                Firstname = "Kacper",
                Lastname = "Godlewski",
                DateOfJoin = new System.DateTime(2022, 1, 1)
            });
            builder.HasData(new Developer
            {
                IdDeveloper = 3,
                Firstname = "Maciej",
                Lastname = "Wrzosek",
                DateOfJoin = new System.DateTime(2022, 2, 1)
            });
        }
    }
}