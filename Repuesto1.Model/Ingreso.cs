using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Model
{
    [Table("tblIngresos")]
    public class Ingreso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; } = string.Empty; // INGRESO o EGRESO

        [Required]
        [StringLength(200)]
        public string Concepto { get; set; } = string.Empty;

        [Required]
        public decimal Monto { get; set; }

        public int? IdReferencia { get; set; }

        [StringLength(20)]
        public string? TipoReferencia { get; set; } // FACTURA o COMPRA
    }
}
