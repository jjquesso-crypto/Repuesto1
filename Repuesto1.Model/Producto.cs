using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repuesto1.Model
{
    [Table("tblProductos")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
         public string Nombre { get; set; } = string.Empty;
  
        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public bool Inactivo { get; set; } = false;
    }
}