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
             
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

    }
}
