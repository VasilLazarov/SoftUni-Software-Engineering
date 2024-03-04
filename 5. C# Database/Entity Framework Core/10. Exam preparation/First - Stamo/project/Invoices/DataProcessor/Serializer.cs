namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                //.Include(c => c.Invoices)
                .Where(c => c.Invoices.Any(i => i.IssueDate >= date))
                .OrderByDescending(c => c.Invoices.Count)
                .ThenBy(c => c.Name)
                .Select(c => new ExportClientDto()
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportClientInvoiceDto()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = decimal.Parse(i.Amount.ToString("G29")),
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            Currency = i.CurrencyType.ToString(),
                        })
                        .ToArray()
                })
                .ToArray();

            string result = XmlConverter.Serialize(clients, "Clients");

            return result;
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Include(p => p.ProductsClients)
                .ThenInclude(pc => pc.Client)
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = decimal.Parse(p.Price.ToString("G29")),
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .OrderBy(pc => pc.Client.Name)
                        .Select(pc => new ExportProductClientDto()
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat,
                        })
                        .ToArray(),
                })
                .OrderByDescending(p => p.Clients.Count())
                .ThenBy(p => p.Name)
                .Take(5)
                .AsNoTracking()
                .ToArray();

            string result = JsonConverter.Serialize(products, true);

            return result;
        }
    }
}