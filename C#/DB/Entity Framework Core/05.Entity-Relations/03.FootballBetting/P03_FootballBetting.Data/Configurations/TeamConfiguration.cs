namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> entity)
        {
            entity
                    .HasKey(e => e.TeamId);

            entity
             .Property(e => e.Name)
             .HasMaxLength(50)
             .IsRequired()
             .IsUnicode();

            entity
             .Property(e => e.LogoUrl)
             .HasMaxLength(250)
             .IsRequired(false)
             .IsUnicode(false);

            entity
            .Property(e => e.Initials)
            .HasMaxLength(3)
            .IsRequired()
            .IsUnicode();

            entity
             .Property(e => e.Budget)
             .IsRequired();

            entity
             .HasOne(t => t.PrimaryKitColor)
             .WithMany(c => c.PrimaryKitTeams)
             .HasForeignKey(t => t.PrimaryKitColorId)
             .OnDelete(DeleteBehavior.Restrict);

            entity
             .HasOne(t => t.SecondaryKitColor)
             .WithMany(c => c.SecondaryKitTeams)
             .HasForeignKey(t => t.SecondaryKitColorId)
             .OnDelete(DeleteBehavior.Restrict);

            entity
             .HasOne(t => t.Town)
             .WithMany(to => to.Teams)
             .HasForeignKey(t => t.TownId);
        }
    }
}
