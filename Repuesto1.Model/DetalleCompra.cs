using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Model
{
    [Table("tblDetalleCompra")]
    public class DetalleCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCompra { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [ForeignKey("IdCompra")]
        public virtual Compra? Compra { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
    }
}