using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;


namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {
        [Required]
        [MaxLength(AddressStreetNameMaxLength)] 
        [MinLength(AddressStreetNameMinLength)]
        [XmlElement("StreetName")]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(AddressCityMaxLength)] 
        [MinLength(AddressCityMinLength)]
        [XmlElement("City")]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(AddressCountryMaxLength)] 
        [MinLength(AddressCountryMinLength)]
        [XmlElement("Country")]
        public string Country { get; set; } = null!;


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
