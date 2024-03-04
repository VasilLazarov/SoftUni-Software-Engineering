using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Internal;
using Castle.Core.Resource;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string result = "";
            // Exercise 9
            //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //result = ImportSuppliers(context, inputXml);

            // Exercise 10
            //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //result = ImportParts(context, inputXml);

            // Exercise 11
            //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //result = ImportCars(context, inputXml);

            // Exercise 12
            //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //result = ImportCustomers(context, inputXml);

            // Exercise 13
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            //result = ImportSales(context, inputXml);

            // Exercise 14
            //result = GetCarsWithDistance(context);

            // Exercise 15, 16, 17, 18, 19
            result = GetSalesWithAppliedDiscount(context);



            Console.WriteLine(result/*.Substring(190, 100)*/);

        }

        // Exercise 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ImportSupplierDto[] supplierDtos =
                XmlConverter.Deserializer<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = supplierDtos
                .Where(s => !string.IsNullOrEmpty(s.Name))
                .Select(s => new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter,
                })
                .ToArray();

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();
            return $"Successfully imported {validSuppliers.Count}";
        }


        // Exercise 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ImportPartDto[] importPartDtos =
                XmlConverter.Deserializer<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = importPartDtos
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId
                            && p.SupplierId != null))
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = (int)p.SupplierId,
                })
                .ToArray();

            context.Parts.AddRange(validParts);
            context.SaveChanges();


            return $"Successfully imported {validParts.Count}";
        }


        // Exercise 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            //IMapper mapper = InializeAutoMapper();
            ImportCarDto[] importCarDtos =
                XmlConverter.Deserializer<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = importCarDtos
                .Where(c => !string.IsNullOrEmpty(c.Make)
                            && !string.IsNullOrEmpty(c.Model))
                .Select(c => new Car()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    PartsCars = c.Parts
                    .DistinctBy(p => p.PartId)
                    .Where(p => context.Parts.Any(pr => pr.Id == p.PartId))
                    .Select(p => new PartCar()
                    {
                        PartId = p.PartId,
                    })
                    .ToArray(),
                })
                .ToArray();

            context.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}"; ;
        }


        // Exercise 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomersDto[] importCustomersDtos =
                XmlConverter.Deserializer<ImportCustomersDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = importCustomersDtos
                .Where(c => !string.IsNullOrEmpty(c.Name))
                .Select(c => new Customer()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToArray();

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";

        }


        // Exercise 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ImportSaleDto[] importSaleDtos =
                XmlConverter.Deserializer<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<Sale> validSales = importSaleDtos
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale()
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount,
                })
                .ToArray();

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }


        // Exercise 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarWithDistanceDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            string result = XmlConverter.Serialize(cars, "cars");

            return result;
        }


        // Exercise 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBmwCarsDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportBmwCarsDto()
                {
                    CarId = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            string result = XmlConverter.Serialize(cars, "cars");

            return result;
        }


        // Exercise 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupplierDto[] suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToArray();

            string result = XmlConverter.Serialize(suppliers, "suppliers");

            return result;
        }


        // Exercise 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarWithPartsDto[] cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .OrderByDescending(pc => pc.Part.Price)
                        .Select(pc => new ExportCarPartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price,
                        })
                        .ToArray()
                })
                .ToArray();


            string result = XmlConverter.Serialize(cars, "cars");

            return result;
        }


        // Exercise 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            #region one way
            //var customers = context.Customers
            //    .Where(c => c.Sales.Any())
            //    .Select(c => new
            //    {
            //        Name = c.Name,
            //        BougthCarsCount = c.Sales.Count(),
            //        MoneyCars = c.IsYoungDriver
            //        ? c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => Math.Round(pc.Part.Price * 0.95m, 2))).Sum()
            //        : c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => Math.Round(pc.Part.Price, 2))).Sum(),

            //    })
            //    .ToArray();
            //ExportCustomerWithTotalSalesDto[] outputCustomers = customers
            //    .Select(c => new ExportCustomerWithTotalSalesDto()
            //    {
            //        Name = c.Name,
            //        BougthCarsCount = c.BougthCarsCount,
            //        SpentMoney = c.MoneyCars.Sum(),
            //    })
            //    .OrderByDescending(oc => oc.SpentMoney)
            //    .ToArray();
            #endregion

            //same but simply with directly get Sum() without anonymous object
            ExportCustomerWithTotalSalesDto[] outputCustomers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerWithTotalSalesDto()
                {
                    Name = c.Name,
                    BougthCarsCount = c.Sales.Count,
                    SpentMoney = c.IsYoungDriver
                    ? c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => Math.Round(pc.Part.Price * 0.95m, 2))).Sum()
                    : c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => Math.Round(pc.Part.Price, 2))).Sum(),
                })
                .OrderByDescending(oc => oc.SpentMoney)
                .ToArray();

            string result = XmlConverter.Serialize(outputCustomers, "customers");

            return result;
        }


        // Exercise 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] sales = context.Sales
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportSaleCarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance,
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round(s.Car.PartsCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount)/100), 2).ToString("F2"),
                })
                .ToArray();

            string result = XmlConverter.Serialize(sales, "sales");

            return result;
        }






        //private static IMapper InializeAutoMapper()
        //    => new Mapper(new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<CarDealerProfile>();
        //    }));


    }
}