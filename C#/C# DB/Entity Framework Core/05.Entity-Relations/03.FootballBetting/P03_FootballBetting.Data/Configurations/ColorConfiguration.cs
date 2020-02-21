namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> entity)
        {
            entity
                .HasKey(c => c.ColorId);

            entity
                .Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode();
        }
    }

}
