using System;

namespace SerializationWorkshop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product product = Serializator.Load<Product>();
            
            if(product == null)
            {
                product = new Product()
                {
                    Id = 1,
                    Price = 200m,
                    Quantity = 37,
                    Model = "DDZ"
                };
            }
            

            Serializator.Safe(product);
        }
    }
}
