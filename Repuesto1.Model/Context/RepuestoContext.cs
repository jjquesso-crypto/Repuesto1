using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;

namespace Repuesto1.Data.Context;

public partial class RepuestoContext : DbContext
{
    public RepuestoContext()
    {
    }

    public RepuestoContext(DbContextOptions<RepuestoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCompra> TblCompras { get; set; }

    public virtual DbSet<TblDetalleCompra> TblDetalleCompras { get; set; }

    public virtual DbSet<TblFactura> TblFacturas { get; set; }

    public virtual DbSet<TblIngreso> TblIngresos { get; set; }

    public virtual DbSet<TblProducto> TblProductos { get; set; }

    public virtual DbSet<TblProveedore> TblProveedores { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VTIDNVJ\\SQLEXPRESS;Database=Repuesto;User Id=sa;Password=123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCompr__3214EC07425A0AEB");

            entity.Property(e => e.Estado).HasDefaultValue("PENDIENTE");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Iva).HasDefaultValue(0m);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TblCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblCompra__IdPro__628FA481");
        });

        modelBuilder.Entity<TblDetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDetal__3214EC077F163ED3");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.TblDetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblDetall__IdCom__656C112C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TblDetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblDetall__IdPro__66603565");
        });

        modelBuilder.Entity<TblFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblFactu__3214EC0718595B1C");

            entity.Property(e => e.Estado).HasDefaultValue("PENDIENTE");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Iva).HasDefaultValue(0m);
        });

        modelBuilder.Entity<TblIngreso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblIngre__3214EC074180EB41");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblProducto>(entity =>
        {
            entity.Property(e => e.Inactivo).HasDefaultValue(false, "DF_tblProductos_Inactivo");
        });

        modelBuilder.Entity<TblProveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblProve__3214EC0792BE9452");

            entity.Property(e => e.Inactivo).HasDefaultValue(false);
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUsuar__3214EC07CEF82015");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Rol).HasDefaultValue("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
