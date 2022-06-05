using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course.Models.Database
{
    public partial class snookerContext : DbContext
    {
        public snookerContext()
        {
        }

        public snookerContext(DbContextOptions<snookerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\sitni\\Downloads\\snooker.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("match");

                entity.Property(e => e.Date)
                    .HasColumnName("date");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Result)
                    .WithMany()
                    .HasForeignKey(d => d.ResultId);

                entity.HasOne(d => d.Tournament)
                    .WithMany()
                    .HasForeignKey(d => d.TournamentId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Country)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.Titles)
                    .HasColumnName("titles");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Round)
                    .HasColumnName("round");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.PlayerId);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournament");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Location)
                    .HasColumnName("location");

                entity.Property(e => e.Period)
                    .HasColumnName("period");

                entity.Property(e => e.Sponsor)
                    .HasColumnName("sponsor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
