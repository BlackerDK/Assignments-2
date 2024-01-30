using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
