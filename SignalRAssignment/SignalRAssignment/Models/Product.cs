using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey("Catelogy")]
        public int CateloryID { get; set; }
        public Catelogy Catelogy { get; set; }

        public int QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
