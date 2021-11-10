﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FINALP.Products
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:product4server.database.windows.net,1433;Initial Catalog=Product;Persist Security Info=False;User ID=santhoshg;Password=Helloworld1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductExpiryDate)
                    .HasColumnName("product_expiry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductManufacturingDate)
                    .HasColumnName("product_manufacturing_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
