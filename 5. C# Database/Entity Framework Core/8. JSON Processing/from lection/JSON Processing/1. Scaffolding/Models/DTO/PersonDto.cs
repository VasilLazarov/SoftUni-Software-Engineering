//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace _1._Scaffolding.Models.DTO
{
    public class PersonDto
    {
        //[JsonPropertyName("firstName")]// for system.text.json
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressText { get; set; }

        public string TownName { get; set; }

        [JsonIgnore]
        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
