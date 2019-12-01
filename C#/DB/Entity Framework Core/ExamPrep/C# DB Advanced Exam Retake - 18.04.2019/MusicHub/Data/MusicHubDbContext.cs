namespace MusicHub.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<SongPerformer> SongPerformers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureAlbumEntity(builder);

            ConfigurePerformerEntity(builder);

            ConfigureProducerEntity(builder);

            ConfigureSongEntity(builder);

            ConfigureSongPerformerEntity(builder);

            ConfigureWriterPerformerEntity(builder);
        }

        private void ConfigureWriterPerformerEntity(ModelBuilder builder)
        {
            builder
                .Entity<Writer>(entity =>
                {
                    entity.HasKey(p => p.Id);

                    entity
                        .HasMany(p => p.Songs)
                        .WithOne(p => p.Writer);
                });
        }


        private void ConfigureSongPerformerEntity(ModelBuilder builder)
        {
            builder
                .Entity<SongPerformer>(entity =>
                {
                    entity.HasKey(sp => new { sp.SongId, sp.PerformerId});

                    entity
                        .HasOne(p => p.Performer)
                        .WithMany(sp => sp.PerformerSongs)
                        .HasForeignKey(p=>p.PerformerId)
                        .OnDelete(DeleteBehavior.Restrict); ;

                    entity
                        .HasOne(p => p.Song)
                        .WithMany(sp => sp.SongPerformers)
                        .HasForeignKey(p => p.SongId)
                        .OnDelete(DeleteBehavior.Restrict); ;
                });
        }

        private void ConfigureSongEntity(ModelBuilder builder)
        {
            builder
                .Entity<Song>(entity =>
                {
                    entity.HasKey(p => p.Id);
                });
        }

        private void ConfigureProducerEntity(ModelBuilder builder)
        {
            builder
                .Entity<Producer>(entity =>
                {
                    entity.HasKey(p => p.Id);

                    entity
                        .HasMany(p => p.Albums)
                        .WithOne(s => s.Producer);
                });
        }

        private void ConfigurePerformerEntity(ModelBuilder builder)
        {
            builder
                .Entity<Performer>(entity =>
                {
                    entity.HasKey(p => p.Id);
                });
        }

        private void ConfigureAlbumEntity(ModelBuilder builder)
        {
            builder
                .Entity<Album>(entity =>
                {
                    entity.HasKey(a => a.Id);

                    entity
                        .HasMany(a => a.Songs)
                        .WithOne(s => s.Album);
                });
        }

    }
}
