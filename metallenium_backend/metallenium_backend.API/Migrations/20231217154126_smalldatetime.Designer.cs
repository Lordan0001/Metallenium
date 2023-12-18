﻿// <auto-generated />
using System;
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
    [Migration("20231217154126_smalldatetime")]
    partial class smalldatetime
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

            modelBuilder.Entity("metallenium_backend.Domain.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.ConfirmedTicket", b =>
                {
                    b.Property<int>("ConfirmedTicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfirmedTicketId"), 1L, 1);

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("ConfirmedTicketId");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("ConfirmedTickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaceId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("smalldatetime");

                    b.HasKey("PlaceId");

                    b.HasIndex("CityId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserPasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("UserPasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserSecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("metallenium_backend.Domain.Models.City", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.ConfirmedTicket", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.Ticket", "Ticket")
                        .WithMany("ConfirmedTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Place", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.City", "City")
                        .WithMany("Places")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Ticket", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.City", "City")
                        .WithMany("Tickets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("metallenium_backend.Domain.Models.Country", "Country")
                        .WithMany("Tickets")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("metallenium_backend.Domain.Models.Place", "Place")
                        .WithMany("Tickets")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("metallenium_backend.Domain.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.User", b =>
                {
                    b.HasOne("metallenium_backend.Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Band", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.City", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Place", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.Ticket", b =>
                {
                    b.Navigation("ConfirmedTickets");
                });

            modelBuilder.Entity("metallenium_backend.Domain.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
