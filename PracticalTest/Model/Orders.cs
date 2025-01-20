using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderBy { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
