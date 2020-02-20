namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            entity
                .HasKey(p => p.PositionId);

            entity
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired()
                .IsUnicode();
        }
    }

}
