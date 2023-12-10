﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using metallenium_backend.Infrastructure;

#nullable disable

namespace metallenium_backend.API.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20231203084725_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("metallenium_backend.Domain.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<string>("AlbumDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlbumImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.HasKey("AlbumId");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Band", b =>
                {
                    b.Property<int>("BandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BandId"), 1L, 1);

                    b.Property<string>("BandDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BandId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Album", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.Band", "Band")
                        .WithMany("Albums")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Band", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
