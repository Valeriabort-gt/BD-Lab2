using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConsoleApp.Configurations;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class AppContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Rent> rent { get; set; }
        public DbSet<Room> rooms { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LBOR\SQLEXPRESS;Database=lera_test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.Entity<Rent>().HasOne(u => u.organization).WithMany(u => u.rents).HasForeignKey(u => u.organizationID);
            modelBuilder.Entity<Rent>().HasOne(u => u.room).WithMany(u => u.rents).HasForeignKey(u => u.roomID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
