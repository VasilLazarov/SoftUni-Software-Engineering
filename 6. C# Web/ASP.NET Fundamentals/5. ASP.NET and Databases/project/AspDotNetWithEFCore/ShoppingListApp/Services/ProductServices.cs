using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public class ProductServices : IProductService
    {
        private readonly ShoppingListDbContext context;

        public ProductServices(ShoppingListDbContext _context)
        {
            context = _context;
        }


        public async Task AddProductAsync(ProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
            };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await context.Products
                .FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException("Invalid product id!");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var products = await context.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .AsNoTracking()
                .ToListAsync();

            return products;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await context.Products
                .FindAsync(id);
            if(product == null)
            {
                throw new ArgumentException("Invalid product id!");
            }

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        public async Task UpdateProductAsync(ProductViewModel model)
        {
            var product = await context.Products
                .FindAsync(model.Id);

            if (product == null)
            {
                throw new ArgumentException("Invalid product id!");
            }

            product.Name = model.Name;
            
            await context.SaveChangesAsync();
        }
    }
}
