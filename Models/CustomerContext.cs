using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Movolytics.Models
{
    public partial class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }

        private IConfiguration Configuration{ get; set; }

        public CustomerContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Customer;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer($"{Configuration["connectionStrings:CustomerDatabase"]}");
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