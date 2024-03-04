using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models
{
    [Comment("Shopping List Product")]
    public class Product
    {

        public Product()
        {
            ProductNotes = new List<ProductNote>();
            Name = string.Empty;
        }

        [Key]
        [Comment("Product Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public ICollection<ProductNote> ProductNotes { get; set; }



    }
}
