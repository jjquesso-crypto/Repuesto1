using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblProveedores")]
public partial class TblProveedore
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("RUC")]
    [StringLength(20)]
    public string? Ruc { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    public bool? Inactivo { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<TblCompra> TblCompras { get; set; } = new List<TblCompra>();
}
