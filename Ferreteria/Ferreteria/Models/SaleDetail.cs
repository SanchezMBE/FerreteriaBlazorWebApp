using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ferreteria.Models
{
    public class SaleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // Propiedades de navegacion EF
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        virtual public Product? Product { get; set; }
        virtual public Sale? Sale { get; set; }
    }
}