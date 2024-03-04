using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        //private static IMapper mapper; // Judge dont like this
        public static void Main()
        {
            var context = new ProductShopContext();
            string result = "";
            //mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //})); // Dont work in Judge - create this in every method

            // Exercise 1
            //string jsonFile = File.ReadAllText("../../../Datasets/users.json");
            //result = ImportUsers(context, jsonFile);

            // Exercise 2
            //string jsonFile = File.ReadAllText("../../../Datasets/products.json");
            //result = ImportProducts(context, jsonFile);

            // Exercise 3
            //string jsonFile = File.ReadAllText("../../../Datasets/categories.json");
            //result = ImportCategories(context, jsonFile);

            // Exercise 4
            //string jsonFile = File.ReadAllText("../../../Datasets/categories-products.json");
            //result = ImportCategoryProducts(context, jsonFile);

            // Exercise 5
            //result = GetProductsInRange(context);
            //File.WriteAllText("../../../Results/products-in-range.json", result);

            // Exercise 
            result = GetSoldProducts(context);
            File.WriteAllText("../../../Results/users-sold-products.json", result);



            Console.WriteLine(result);

        }

        // Exercise 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            //IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //})); // If we use Automapper - but I map object manual
            var userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            //From Kriskata
            #region from Kriskata
            //ICollection<User> validUsers = new HashSet<User>();
            //foreach (var userDto in userDtos)
            //{
            //    User user = mapper.Map<User>(userDto);
            //    validUsers.Add(user);
            //}
            //context.Users.AddRange(validUsers);
            #endregion

            //my test
            #region my code

            ICollection<User> validUsers = userDtos
                .Select(udto => new User()
                {
                    FirstName = udto.FirstName,
                    LastName = udto.LastName,
                    Age = udto.Age,
                })
                .ToList();

            //With auto mapper
            //ICollection<User> validUsers = userDtos
            //    .Select(udto => mapper.Map<User>(udto))
            //    .ToList();

            context.Users.AddRange(validUsers);

            context.SaveChanges();

            #endregion

            return $"Successfully imported {validUsers.Count}";
        }


        // Exercise 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productDtos = JsonConvert
               .DeserializeObject<ImportProductDto[]>(inputJson);


            ICollection<Product> validProducts = productDtos
                .Select(udto => new Product()
                {
                    Name = udto.Name,
                    Price = udto.Price,
                    SellerId = udto.SellerId,
                    BuyerId = udto.BuyerId,
                })
                .ToList();

            context.Products.AddRange(validProducts);

            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }


        // Exercise 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoryDtos = JsonConvert
               .DeserializeObject<ImportCategoryDto[]>(inputJson);


            ICollection<Category> validCategories = categoryDtos
                .Where(udto => udto.Name != null)
                .Select(udto => new Category()
                {
                    Name = udto.Name
                })
                .ToList();

            context.Categories.AddRange(validCategories);

            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";


        }


        // Exercise 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductDtos = JsonConvert
               .DeserializeObject<ImportCategoryProduct[]>(inputJson);


            ICollection<CategoryProduct> validCategoryProducts = categoryProductDtos
                //Check ids of products and categories are valid with Where
                //.Where(udto => context.Categories.Any(c => c.Id == udto.CategoryId)
                //        && context.Products.Any(p => p.Id == udto.ProductId)) // For Judge without this
                .Select(udto => new CategoryProduct()
                {
                    CategoryId = udto.CategoryId,
                    ProductId = udto.ProductId,
                })
                .ToList();

            context.CategoriesProducts.AddRange(validCategoryProducts);

            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";

        }


        // Exercise 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            // Without DTO
            //var products = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //    {
            //        Name = p.Name,
            //        Price = p.Price,
            //        Seller = p.Seller.FirstName + " " + p.Seller.LastName,
            //    })
            //    .AsNoTracking()
            //    .ToArray();

            // With DTO
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDto
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price,
                    SellerFullName = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .AsNoTracking()
                .ToArray();

            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            string result = JsonConvert.SerializeObject(products, serializerSettings);

            return result;
        }


        // Exercise 6
        public static string GetSoldProducts(ProductShopContext context)
        {

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName,
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            string result = JsonConvert.SerializeObject(users, serializerSettings);

            return result;
        }




    }
}