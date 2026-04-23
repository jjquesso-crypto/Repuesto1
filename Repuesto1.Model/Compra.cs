using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Data
{
    [Table("tblCompras")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroFactura { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        public decimal Iva { get; set; } = 0;

        [Required]
        public decimal Total { get; set; }

        [StringLength(20)]
        public string Estado { get; set; } = "PENDIENTE";

        [ForeignKey("IdProveedor")]
        public virtual Proveedor? Proveedor { get; set; }
    }
}