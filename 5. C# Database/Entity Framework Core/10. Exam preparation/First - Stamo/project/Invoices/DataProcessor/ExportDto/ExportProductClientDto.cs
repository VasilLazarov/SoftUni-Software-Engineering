using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductClientDto
    {

        
        public string Name { get; set; } = null!;

        
        public string NumberVat { get; set; } = null!;

    }
}
