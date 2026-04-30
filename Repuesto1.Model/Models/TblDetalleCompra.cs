using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblDetalleCompra")]
public partial class TblDetalleCompra
{
    [Key]
    public int Id { get; set; }

    public int IdCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioCompra { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SubTotal { get; set; }

    [ForeignKey("IdCompra")]
    [InverseProperty("TblDetalleCompras")]
    public virtual TblCompra IdCompraNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("TblDetalleCompras")]
    public virtual TblProducto IdProductoNavigation { get; set; } = null!;
}
