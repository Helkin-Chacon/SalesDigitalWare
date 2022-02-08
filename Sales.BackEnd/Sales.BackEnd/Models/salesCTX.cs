using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sales.BackEnd.Models
{
    public partial class salesCTX : DbContext
    {
        public salesCTX()
        {
        }

        public salesCTX(DbContextOptions<salesCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<DetailInvoice> DetailInvoice { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Product> Product { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Client__A6A610D41DC4F988");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.BirthDatevarchar)
                    .HasColumnName("birthDatevarchar")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdentificationNumberClient)
                    .HasColumnName("identificationNumberClient")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastnameClient)
                    .HasColumnName("lastnameClient")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameClient)
                    .HasColumnName("nameClient")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameCompleteClient)
                    .IsRequired()
                    .HasColumnName("nameCompleteClient")
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([nameClient],' ',[lastnameClient]))");

                entity.Property(e => e.RegisterDatevarchar)
                    .HasColumnName("registerDatevarchar")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DetailInvoice>(entity =>
            {
                entity.HasKey(e => e.IdDetailInvoice)
                    .HasName("PK__DetailIn__5F8673CA9372C24C");

                entity.Property(e => e.IdDetailInvoice).HasColumnName("idDetailInvoice");

                entity.Property(e => e.CostProduct)
                    .HasColumnName("costProduct")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateSale)
                    .HasColumnName("dateSale")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdInvoice).HasColumnName("idInvoice");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.NameProduct)
                    .HasColumnName("nameProduct")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.QuantityProduct)
                    .HasColumnName("quantityProduct")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.DetailInvoice)
                    .HasForeignKey(d => d.IdInvoice)
                    .HasConstraintName("FK__DetailInv__idInv__2A4B4B5E");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.DetailInvoice)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__DetailInv__idPro__2B3F6F97");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice)
                    .HasName("PK__Invoice__D3631FCEF20EFAE2");

                entity.Property(e => e.IdInvoice).HasColumnName("idInvoice");

                entity.Property(e => e.CostInvoice)
                    .HasColumnName("costInvoice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateInvoice)
                    .HasColumnName("dateInvoice")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdentificationNumberClient)
                    .HasColumnName("identificationNumberClient")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__Invoice__idClien__2C3393D0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__5EEC79D1A38F395D");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.NameProduct)
                    .HasColumnName("nameProduct")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseCostProdutc)
                    .HasColumnName("purchaseCostProdutc")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SaleCostProdutc)
                    .HasColumnName("saleCostProdutc")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StockProduct)
                    .HasColumnName("stockProduct")
                    .HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
