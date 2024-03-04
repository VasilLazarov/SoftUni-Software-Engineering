namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder output = new();

            ImportClientDto[] clientDtos =
                XmlConverter.Deserialize<ImportClientDto[]>(xmlString, "Clients");

            ICollection<Client> validClients = new List<Client>();
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Client newClient = new()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    Address address = new()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country,
                    };
                    newClient.Addresses.Add(address);
                }
                validClients.Add(newClient);
                output.AppendLine(string.Format(SuccessfullyImportedClients, newClient.Name));

            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder output = new();

            ImportInvoiceDto[] invoiceDtos = 
                JsonConverter.Deserialize<ImportInvoiceDto[]>(jsonString);

            ICollection<Invoice> validInvoices = new List<Invoice>();

            foreach (var invoiceDto in invoiceDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                //this is new
                if (invoiceDto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoiceDto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                //end new
                if (invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Invoice newInvoice = new()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId,
                };
                validInvoices.Add(newInvoice);
                output.AppendLine(string.Format(SuccessfullyImportedInvoices, newInvoice.Number));
            }
            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder output = new();

            ImportProductDto[] productDtos =
                JsonConverter.Deserialize<ImportProductDto[]>(jsonString);

            ICollection<Product> validProducts = new List<Product>();

            int[] validClientsIds = context.Clients.Select(c => c.Id).ToArray();

            foreach (var productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Product newProduct = new()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType,
                };
                foreach (var clientId in productDto.Clients.Distinct())
                {
                    if(!validClientsIds.Contains(clientId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    ProductClient productClient = new()
                    {
                        ClientId = clientId,
                    };
                    newProduct.ProductsClients.Add(productClient);
                }
                validProducts.Add(newProduct);
                output.AppendLine(string.Format(SuccessfullyImportedProducts, newProduct.Name, newProduct.ProductsClients.Count));
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();


            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
