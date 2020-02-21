namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity
                .HasKey(p => p.PlayerId);

            entity
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            entity
                .Property(p => p.SquadNumber)
                .IsRequired();

            entity
                .Property(p => p.IsInjured)
                .IsRequired();

            entity
                .HasOne(p => p.Position)
                .WithMany(pl => pl.Players)
                .HasForeignKey(p => p.PositionId);

            entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
        }
    }

}
