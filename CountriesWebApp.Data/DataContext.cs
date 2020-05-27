using CountriesWebApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesWebApp.Data
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Represents database table for regions.
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Represents database table for cities.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Represents database table for countries.
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// The default DbContext constructor.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Configures models.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Country>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>() 
                .HasOne(e => e.Capital)
                .WithMany()
                .HasForeignKey(e => e.CapitalId)
                .IsRequired(false);
            modelBuilder.Entity<Country>()
                .HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .IsRequired(false);
        }
    }
}
