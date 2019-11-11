namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> entity)
        {
            entity.HasKey(ps => new { ps.PlayerId, ps.GameId });

            entity
                .Property(ps => ps.ScoredGoals)
                .IsRequired();

            entity
                .Property(ps => ps.Assists)
                .IsRequired();

            entity
                .Property(ps => ps.MinutesPlayed)
                .IsRequired();

            entity
                .HasOne(ps => ps.Game)
                .WithMany(b => b.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            entity
                .HasOne(ps => ps.Player)
                .WithMany(c => c.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);
        }
    }

}
