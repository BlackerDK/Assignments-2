using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
