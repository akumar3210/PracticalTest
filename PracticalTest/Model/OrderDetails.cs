using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Model
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public decimal ItemAmount { get; set; }

        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime CreatedOn { get; set; }

        public Orders Order { get; set; }
    }
}
