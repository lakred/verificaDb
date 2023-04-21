using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET.CORE.Models.DB;

public partial class ArtworkContext : DbContext
{
    public ArtworkContext()
    {
    }

    public ArtworkContext(DbContextOptions<ArtworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Museum> Museums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Artwork; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.IdArtist).HasName("PK_ARTIST");

            entity.ToTable("ARTIST");

            entity.Property(e => e.IdArtist)
                .ValueGeneratedNever()
                .HasColumnName("Id_Artist");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Artwork>(entity =>
        {
            entity.HasKey(e => e.IdArtwork).HasName("PK_ARTWORK");

            entity.ToTable("ARTWORK");

            entity.Property(e => e.IdArtwork)
                .ValueGeneratedNever()
                .HasColumnName("ID_Artwork");
            entity.Property(e => e.IdArtist).HasColumnName("ID_Artist");
            entity.Property(e => e.IdCharacter).HasColumnName("ID_Character");
            entity.Property(e => e.IdMuseum).HasColumnName("ID_Museum");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArtistNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdArtist)
                .HasConstraintName("FK_ARTWORK_Arti");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdCharacter)
                .HasConstraintName("FK_ARTWORK_Char");

            entity.HasOne(d => d.IdMuseumNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdMuseum)
                .HasConstraintName("FK_ARTWORK_Mus");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.IdCharacter).HasName("PK_CHARACTER");

            entity.ToTable("CHARACTER");

            entity.Property(e => e.IdCharacter)
                .ValueGeneratedNever()
                .HasColumnName("ID_Character");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Museum>(entity =>
        {
            entity.HasKey(e => e.IdMuseum).HasName("PK_MUSEUM");

            entity.ToTable("MUSEUM");

            entity.Property(e => e.IdMuseum)
                .ValueGeneratedNever()
                .HasColumnName("Id_Museum");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MuseumName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
