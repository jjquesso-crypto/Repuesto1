using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Data.Models;

[Table("tblUsuarios")]
[Index("NombreUsuario", Name = "UQ__tblUsuar__6B0F5AE0A25AEB82", IsUnique = true)]
public partial class TblUsuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string NombreUsuario { get; set; } = null!;

    [StringLength(255)]
    public string Contraseña { get; set; } = null!;

    [StringLength(100)]
    public string? NombreCompleto { get; set; }

    [StringLength(50)]
    public string? Rol { get; set; }

    public bool? Activo { get; set; }
}
