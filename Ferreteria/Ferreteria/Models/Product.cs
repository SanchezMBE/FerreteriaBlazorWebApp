using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferreteria.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El código es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El código debe ser un número positivo")]
        public int Code { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "El precio de compra es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de compra debe ser un número positivo")]
        public decimal BuyPrice { get; set; }
        [Required(ErrorMessage = "El precio de venta es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta debe ser un número positivo")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "La cantidad en stock es requerida")]
        public int StockQuantity { get; set; }
        // Propiedad de navegación EF
        virtual public ICollection<SaleDetail>? SaleDetails { get; set; }
    }
}