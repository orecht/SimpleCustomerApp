using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SimpleCustomerApp.Models
{
    public partial class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base (options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.JoiningDate)
                    .HasName("IX_Customer_JoiningDate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            });
        }
    }
}