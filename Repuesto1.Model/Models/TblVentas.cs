using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

public partial class TblVentas
{
    public int Id { get; set; }

    public string? NumeroFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Itebis { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<TblDetalleVentas> TblDetalleVentas { get; set; } = new List<TblDetalleVentas>();
}
