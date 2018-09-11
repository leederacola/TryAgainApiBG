using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TryAgainApiBG.Models
{
    public partial class APIGameDBContext : DbContext
    {
        public APIGameDBContext()
        {
        }

        public APIGameDBContext(DbContextOptions<APIGameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventGames> EventGames { get; set; }
        public virtual DbSet<EventPlayers> EventPlayers { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameNight> GameNight { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Player> Player { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=APIGameDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventGames>(entity =>
            {
                entity.HasKey(e => new { e.GameNightId, e.GameId });

                entity.Property(e => e.EventGamesId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.EventGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventGame__GameI__2E1BDC42");

                entity.HasOne(d => d.GameNight)
                    .WithMany(p => p.EventGames)
                    .HasForeignKey(d => d.GameNightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventGame__GameN__2D27B809");
            });

            modelBuilder.Entity<EventPlayers>(entity =>
            {
                entity.HasKey(e => new { e.GameNightId, e.PlayerId });

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.EventPlayersId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.GameNight)
                    .WithMany(p => p.EventPlayers)
                    .HasForeignKey(d => d.GameNightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlay__GameN__30F848ED");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.EventPlayers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlay__Playe__31EC6D26");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ImgPath).HasMaxLength(100);

                entity.Property(e => e.ThumbPath).HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GameNight>(entity =>
            {
                entity.Property(e => e.EventTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(280);
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId });

                entity.Property(e => e.LibraryId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Library__GameId__286302EC");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Library__PlayerI__276EDEB3");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
