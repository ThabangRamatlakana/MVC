using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class GoodsDonation
    {
        [Key]
        public int goodsId { get; set; }

        public string? donatorName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime donationDate { get; set; }

        [Required]
        public string goodsCategory { get; set; }
        public string? otherCategory { get; set; }

        [Required]
        public int numberOfItems { get; set; }

        [Required]
        public string goodsDescription { get; set; }
    }
}
