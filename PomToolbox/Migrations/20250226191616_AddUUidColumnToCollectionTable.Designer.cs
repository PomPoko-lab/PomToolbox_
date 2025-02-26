﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PomToolbox.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250226191616_AddUUidColumnToCollectionTable")]
    partial class AddUUidColumnToCollectionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("PomToolbox.Data.Models.PokeCollectionCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonCardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonCollectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonCardId");

                    b.HasIndex("PokemonCollectionId");

                    b.ToTable("PokeCollectionCards");
                });

            modelBuilder.Entity("PomToolbox.Data.Models.PokemonCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiId")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<double?>("AverageTcgPlayerPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TcgPlayerPriceLastUpdated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PokemonCards");
                });

            modelBuilder.Entity("PomToolbox.Data.Models.PokemonCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PokemonCollections");
                });

            modelBuilder.Entity("PomToolbox.Data.Models.PokeCollectionCard", b =>
                {
                    b.HasOne("PomToolbox.Data.Models.PokemonCard", "PokemonCard")
                        .WithMany("PokeCollectionCards")
                        .HasForeignKey("PokemonCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PomToolbox.Data.Models.PokemonCollection", "PokemonCollection")
                        .WithMany("PokeCollectionCards")
                        .HasForeignKey("PokemonCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonCard");

                    b.Navigation("PokemonCollection");
                });

            modelBuilder.Entity("PomToolbox.Data.Models.PokemonCard", b =>
                {
                    b.Navigation("PokeCollectionCards");
                });

            modelBuilder.Entity("PomToolbox.Data.Models.PokemonCollection", b =>
                {
                    b.Navigation("PokeCollectionCards");
                });
#pragma warning restore 612, 618
        }
    }
}
