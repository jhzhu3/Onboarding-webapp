using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.Data
{
    public class WasteDbContext : DbContext
    {
        public WasteDbContext(DbContextOptions<WasteDbContext> options) : base(options) 
        { 
        }

        public DbSet<Garbage> Garbage { get; set; }
        public DbSet<Bin> Bin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garbage>()
                .HasOne(g => g.Bin)
                .WithMany(b => b.Garbages)
                .HasForeignKey(g => g.BinId);
        }
    }
}
