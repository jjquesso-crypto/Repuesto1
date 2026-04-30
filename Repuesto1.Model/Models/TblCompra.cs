using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblCompras")]
public partial class TblCompra
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string NumeroFactura { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    public int IdProveedor { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Iva { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [StringLength(20)]
    public string? Estado { get; set; }

    [ForeignKey("IdProveedor")]
    [InverseProperty("TblCompras")]
    public virtual TblProveedore IdProveedorNavigation { get; set; } = null!;

    [InverseProperty("IdCompraNavigation")]
    public virtual ICollection<TblDetalleCompra> TblDetalleCompras { get; set; } = new List<TblDetalleCompra>();
}
