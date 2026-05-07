using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Data.Models;

[Table("tblDetalleVentas")]
public partial class TblDetalleVentas
{
    [Key]
    public int Id { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    [StringLength(100)]
    public string? ProductoNombre { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioVenta { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SubTotal { get; set; }

    [ForeignKey("IdVenta")]
    [InverseProperty("TblDetalleVentas")]
    public virtual TblVentas? IdVentaNavigation { get; set; }

    [ForeignKey("IdProducto")]
    public virtual TblProducto? IdProductoNavigation { get; set; }
}