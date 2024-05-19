using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ferreteria.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        [Required(ErrorMessage = "El total es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar productos para confirmar la venta")]
        public decimal TotalAmount { get; set; }
        virtual public ICollection<SaleDetail>? SaleDetails { get; set; }
    }
}