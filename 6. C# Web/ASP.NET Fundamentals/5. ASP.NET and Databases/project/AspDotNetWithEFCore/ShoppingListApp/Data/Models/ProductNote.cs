using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data.Models
{
    [Comment("Product Note")]
    public class ProductNote
    {

        public ProductNote()
        {
            Content = string.Empty;
            Product = null!;
        }

        [Key]
        [Comment("Note Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [Comment("Note Content")]
        public string Content { get; set; }

        [Required]
        [Comment("Product Identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }



    }
}