namespace _1._Scaffolding.Models.DTO
{
    public class PersonDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressText { get; set; }

        public string TownName { get; set; }

        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
