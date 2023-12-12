using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>()
                 .HasMany<Album>(g => g.Albums)
                 .WithOne(a => a.Band)
                 .HasForeignKey(q => q.BandId);

            modelBuilder.Entity<City>()
                .HasMany<Place>(c => c.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>()
                .HasMany<Ticket>(c => c.Tickets)
                .WithOne(t => t.City)
                .HasForeignKey(t => t.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Place>()
                .HasMany<Ticket>(p => p.Tickets)
                .WithOne(t => t.Place)
                .HasForeignKey(t => t.PlaceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Country>()
                .HasMany<City>(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Country>()
                .HasMany<Ticket>(c => c.Tickets)
                .WithOne(t => t.Country)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany<Ticket>(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>()
                .HasMany<User>(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.UserRoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasMany<ConfirmedTicket>(t => t.ConfirmedTickets)
                .WithOne(ct => ct.Ticket)
                .HasForeignKey(ct => ct.TicketId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Country)
                 .WithMany(c => c.Tickets)
                  .HasForeignKey(t => t.CountryId)
                    .OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ConfirmedTicket> ConfirmedTickets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


    }
}
