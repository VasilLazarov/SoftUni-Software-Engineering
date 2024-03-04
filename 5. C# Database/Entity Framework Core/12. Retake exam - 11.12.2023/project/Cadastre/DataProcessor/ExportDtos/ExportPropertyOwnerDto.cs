using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class ExportPropertyOwnerDto
    {

        public string LastName { get; set; } = null!;


        public string MaritalStatus { get; set; } = null!;

    }
}
