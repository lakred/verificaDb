﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET.CORE.Models.DB;

#nullable disable

namespace NET.CORE.Migrations
{
    [DbContext(typeof(ArtworkContext))]
    partial class ArtworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NET.CORE.Models.DB.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artist");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdArtist")
                        .HasName("PK_ARTIST");

                    b.ToTable("ARTIST", (string)null);
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Artwork", b =>
                {
                    b.Property<int>("IdArtwork")
                        .HasColumnType("int")
                        .HasColumnName("ID_Artwork");

                    b.Property<int?>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("ID_Artist");

                    b.Property<int?>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("ID_Character");

                    b.Property<int?>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("ID_Museum");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdArtwork")
                        .HasName("PK_ARTWORK");

                    b.HasIndex("IdArtist");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdMuseum");

                    b.ToTable("ARTWORK", (string)null);
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Character", b =>
                {
                    b.Property<int>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("ID_Character");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdCharacter")
                        .HasName("PK_CHARACTER");

                    b.ToTable("CHARACTER", (string)null);
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Museum", b =>
                {
                    b.Property<int>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("Id_Museum");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MuseumName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdMuseum")
                        .HasName("PK_MUSEUM");

                    b.ToTable("MUSEUM", (string)null);
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Artwork", b =>
                {
                    b.HasOne("NET.CORE.Models.DB.Artist", "IdArtistNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdArtist")
                        .HasConstraintName("FK_ARTWORK_Arti");

                    b.HasOne("NET.CORE.Models.DB.Character", "IdCharacterNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdCharacter")
                        .HasConstraintName("FK_ARTWORK_Char");

                    b.HasOne("NET.CORE.Models.DB.Museum", "IdMuseumNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdMuseum")
                        .HasConstraintName("FK_ARTWORK_Mus");

                    b.Navigation("IdArtistNavigation");

                    b.Navigation("IdCharacterNavigation");

                    b.Navigation("IdMuseumNavigation");
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Character", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("NET.CORE.Models.DB.Museum", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
