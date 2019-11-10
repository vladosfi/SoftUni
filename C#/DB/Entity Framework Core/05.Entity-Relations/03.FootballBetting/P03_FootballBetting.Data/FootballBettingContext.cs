
namespace P03_FootballBetting.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringTeam(modelBuilder);
            OnConfiguringColor(modelBuilder);
            OnConfiguringTown(modelBuilder);
            OnConfiguringCountry(modelBuilder);
            OnConfiguringPlayer(modelBuilder);
            OnConfiguringPosition(modelBuilder);
            OnConfiguringPlayerStatistic(modelBuilder);
            OnConfiguringPlayerGame(modelBuilder);
            OnConfiguringPlayerBet(modelBuilder);
            OnConfiguringPlayerUser(modelBuilder);
        }

        private void OnConfiguringPlayerUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
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
            });
        }

        private void OnConfiguringPlayerBet(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Bet>(entity =>
                {
                    entity
                        .HasKey(b => b.BetId);

                    entity
                        .Property(b => b.Amount)
                        .IsRequired();

                    entity
                        .Property(b => b.Prediction)
                        .IsRequired();

                    entity
                        .Property(b => b.Prediction)
                        .IsRequired();

                    entity
                        .Property(b => b.DateTime)
                        .IsRequired();

                    entity
                        .HasOne(b => b.User)
                        .WithMany(u => u.Bets)
                        .HasForeignKey(b => b.UserId);

                    entity
                        .HasOne(b => b.Game)
                        .WithMany(g => g.Bets)
                        .HasForeignKey(b => b.GameId);
                });
        }

        private void OnConfiguringPlayerGame(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>(entity =>
                {
                    entity
                        .HasKey(g => g.GameId);

                    entity
                        .Property(g => g.HomeTeamGoals)
                        .IsRequired();

                    entity
                        .Property(g => g.AwayTeamGoals)
                        .IsRequired();

                    entity
                        .Property(g => g.DateTime)
                        .IsRequired();

                    entity
                        .Property(g => g.HomeTeamBetRate)
                        .IsRequired();

                    entity
                        .Property(g => g.AwayTeamBetRate)
                        .IsRequired();

                    entity
                        .Property(g => g.DrawBetRate)
                        .IsRequired();

                    entity
                        .Property(g => g.Result)
                        .HasMaxLength(10)
                        .IsRequired()
                        .IsUnicode(false);

                    entity
                        .HasOne(g => g.HomeTeam)
                        .WithMany(t => t.HomeGames)
                        .HasForeignKey(g => g.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity
                        .HasOne(g => g.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(g => g.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }

        private void OnConfiguringPlayerStatistic(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId});

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
            });
        }

        private void OnConfiguringPosition(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Position>(entity =>
                {
                    entity
                        .HasKey(p => p.PositionId);

                    entity
                        .Property(p => p.Name)
                        .HasMaxLength(20)
                        .IsRequired()
                        .IsUnicode();
                });
        }

        private void OnConfiguringPlayer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
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
            });
        }

        private void OnConfiguringCountry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity
                    .HasKey(c => c.CountryId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode();
            });
        }

        private void OnConfiguringTown(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>(entity =>
            {
                entity
                    .HasKey(t => t.TownId);

                entity
                    .Property(t => t.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

                entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId);
            });
        }

        private void OnConfiguringColor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity
                    .HasKey(c => c.ColorId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(30)
                    .IsRequired()
                    .IsUnicode();
            });
        }

        private void OnConfiguringTeam(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Team>(entity =>
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
               });
        }
    }
}
