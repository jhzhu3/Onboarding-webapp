using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.Data
{
    public class SortWasteVictoria_WebAppContext : DbContext
    {
        public SortWasteVictoria_WebAppContext (DbContextOptions<SortWasteVictoria_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SortWasteVictoria_WebApp.Models.Bin> Bin { get; set; } = default!;

        public DbSet<SortWasteVictoria_WebApp.Models.Garbage> Garbage { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Garbage>()
            .HasOne(g => g.Bin)
            .WithMany(b => b.garbages)
            .HasForeignKey(g => g.BinId);
    }
    }
}
