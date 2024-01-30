using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; } 
    }
}
