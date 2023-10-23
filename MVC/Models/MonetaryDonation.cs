using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class MonetaryDonation
    {
        [Key]
        public int moneyId { get; set; }

        public string? donatorName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime donationDate { get; set; }
        [Required]
        public string moneyAmount { get; set; }
    }
}
