using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblProductos")]
public partial class TblProducto
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public bool? Inactivo { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<TblDetalleCompra> TblDetalleCompras { get; set; } = new List<TblDetalleCompra>();
}
