namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(u => u.UserId);

            entity
                .Property(u => u.Balance)
                .IsRequired();

            entity
                .Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode();

            entity
                .Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);

            entity
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            entity
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
        }
    }

}
