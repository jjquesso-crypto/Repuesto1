using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblIngresos")]
public partial class TblIngreso
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [StringLength(20)]
    public string Tipo { get; set; } = null!;

    [StringLength(200)]
    public string Concepto { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Monto { get; set; }

    public int? IdReferencia { get; set; }

    [StringLength(20)]
    public string? TipoReferencia { get; set; }
}
