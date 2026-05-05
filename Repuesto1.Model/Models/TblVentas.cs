using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Data.Models;

[Table("tblVentas")]
public partial class TblVentas
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string? NumeroFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SubTotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Itebis { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Total { get; set; }

    [StringLength(20)]
    public string? Estado { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<TblDetalleVentas> TblDetalleVentas { get; set; } = new List<TblDetalleVentas>();
}