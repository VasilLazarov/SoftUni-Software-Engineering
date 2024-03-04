namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderItem
    {
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [Required]
        public Order Order { get; set; } = null!;

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [Required]
        public Item Item { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}