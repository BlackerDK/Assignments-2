using System.ComponentModel.DataAnnotations;

namespace SignalRAssignment.Models
{
    public class Catelogy
    {
        [Key]
        public int CateloryID { get; set; }
        public string CatelogyName { get; set; }
        public string Descriptions { get; set; }
    }
}
