using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.ModelsDbF;

public partial class SqldataContext : DbContext
{
    public SqldataContext()
    {
    }

    public SqldataContext(DbContextOptions<SqldataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HELLO-WORLD;Database=Assignment2;uid=sa;pwd=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomersCustomerId, "IX_Orders_CustomersCustomerId");

            entity.HasOne(d => d.CustomersCustomer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomersCustomerId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.HasIndex(e => e.OrdersOrderId, "IX_OrderDetails_OrdersOrderId");

            entity.HasIndex(e => e.ProductsProductId, "IX_OrderDetails_ProductsProductId");

            entity.HasOne(d => d.OrdersOrder).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrdersOrderId);

            entity.HasOne(d => d.ProductsProduct).WithMany(p => p.OrderDetails).HasForeignKey(d => d.ProductsProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierId");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasForeignKey(d => d.SupplierId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
