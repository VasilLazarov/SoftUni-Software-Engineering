using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;


namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDto
    {

        [Required]
        [MaxLength(ClientNameMaxLength)] 
        [MinLength(ClientNameMinLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClientNumberVatMaxLength)] 
        [MinLength(ClientNumberVatMinLength)]
        [XmlElement("NumberVat")]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public ImportAddressDto[] Addresses { get; set; }


    }



  //  <Clients>
  //<Client>
  //  <Name>LiCB</Name>
  //  <NumberVat>BG5464156654654654</NumberVat>
  //  <Addresses>
  //    <Address>
  //      <StreetName>Gnigler strasse</StreetName>
  //      <StreetNumber>57</StreetNumber>
  //      <PostCode>5020</PostCode>
  //      <City>Salzburg</City>
  //      <Country>Austria</Country>
  //    </Address>
  //  </Addresses>
  //</Client>
}
