using Customer.Domain.DomainObjects;
using Customer.Domain.Responses;

namespace Customer.Domain.Aggregates
{
    public class Address
    {
        protected Address() { }
        public Address(string identifier, string cep, string addressLine, long number, string neighborhood, string city, string state, string complement, string reference)
        {
            Id = Guid.NewGuid();
            Identifier = identifier;
            Cep = new Cep(cep);
            AddressLine = addressLine;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
        }

        public Address(Cep cep, string addressLine, string neighborhood, string city, string state)
        {
            Cep = cep;
            AddressLine = addressLine;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public Guid Id { get; private set; }
        public string Identifier { get; private set; } = string.Empty;
        public Cep Cep { get; private set; }
        public string AddressLine { get; private set; }
        public long Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; } 
        public string Complement { get; private set; } = string.Empty; 
        public string Reference { get; private set; } = string.Empty;

        public AddressDetailResponse GetAddressDetail()
        {
            return new AddressDetailResponse(Cep.Value, AddressLine, Neighborhood, City, State);
        }

        public void AddComplements(string identifier, string complement, string reference) 
        {
            Identifier = identifier;
            Complement = complement;
            Reference = reference;
        }

    }
}
