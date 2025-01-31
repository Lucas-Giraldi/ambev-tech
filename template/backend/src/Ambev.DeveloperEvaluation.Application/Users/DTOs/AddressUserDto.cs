namespace Ambev.DeveloperEvaluation.Application.Users.DTOs
{
    public class AddressUserDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string ZipCode { get; set; }

        public LocationUsersDto GeoLocation { get; set; }
    }
}
