using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Model
{
    [Table("tblDetalleFactura")]
    public class DetalleFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioVenta { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [ForeignKey("IdFactura")]
        public virtual Factura? Factura { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
    }
}