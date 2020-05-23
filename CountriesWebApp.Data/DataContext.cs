using CountriesWebApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesWebApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

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
                .IsRequired(true);
            modelBuilder.Entity<Country>()
                .HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .IsRequired(true);
        }
    }
}
