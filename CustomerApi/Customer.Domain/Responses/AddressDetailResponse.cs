namespace Customer.Domain.Responses
{
    public class AddressDetailResponse
    {
        public AddressDetailResponse(string cep, string addressLine, string neighborhood, string city, string state)
        {
            Cep = cep;
            AddressLine = addressLine;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public string Cep { get; }
        public string AddressLine { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }

    }
}
