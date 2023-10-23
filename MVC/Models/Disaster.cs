using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Disaster
    {
        [Key]
        public int disasterId { get; set; }
        [Required]
        public string disasterName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string disasterDescription { get; set; }
        [Required]
        public string aidType { get; set; }
    }
}
