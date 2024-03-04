using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Invoices.Utilities;
using static Invoices.Utilities.GlobalConstants;


namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        public const decimal ProductPriceMinValue = 5m;

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        //[JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)GlobalConstants.ProductPriceMinValue, (double)GlobalConstants.ProductPriceMaxValue)]
        //[JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(CategoryType))]
        //[JsonProperty("CategoryType")]
        public CategoryType CategoryType { get; set; }

        //[JsonProperty("Clients")]
        public int[] Clients { get; set; } = null!;


    }
}
