using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

public partial class TblDetalleVentas
{
    public int Id { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public string? ProductoNombre { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioVenta { get; set; }

    public decimal? SubTotal { get; set; }

    [ForeignKey("IdVenta")]
    public virtual TblVentas? IdVentaNavigation { get; set; }

    [ForeignKey("IdProducto")]
    public virtual TblProducto? IdProductoNavigation { get; set; }
}
