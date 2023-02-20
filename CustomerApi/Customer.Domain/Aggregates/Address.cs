using Customer.Domain.DomainObjects;
using Customer.Domain.Responses;

namespace Customer.Domain.Aggregates
{
    public class Address
    {
        protected Address(string addressLine, string neighborhood, string city, string state)
        {
            AddressLine = addressLine;
            Neighborhood = neighborhood;
            City = city;
            State = state;

        }

        public Address(Cep cep, string addressLine, string neighborhood, string city, string state) : this(addressLine, neighborhood, city, state)
        {
            Cep = cep;
        }

        public Guid Id { get; private set; }
        public string Identifier { get; private set; } = string.Empty;
        public Cep Cep { get; private set; }
        public string AddressLine { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Complement { get; private set; } = string.Empty;
        public string Reference { get; private set; } = string.Empty;

        public AddressDetailResponse GetAddressDetail()
        {
            return new AddressDetailResponse(Cep.Value, AddressLine, Neighborhood, City, State);
        }

        public void AddSpecifications(string identifier, string number, string complement, string reference)
        {
            Identifier = identifier;
            Complement = complement;
            Reference = reference;
            Number = number;
        }

    }
}
