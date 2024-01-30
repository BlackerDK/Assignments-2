using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Passwords { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
