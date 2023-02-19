using Customer.Domain.DomainObjects;
using Customer.Domain.Responses;

namespace Customer.Domain.Aggregates
{
    public class DeliveryAddress
    {
        public DeliveryAddress(string identifier, string cep, string address, long number, string neighborhood, string city, string state, string complement, string reference)
        {
            Identifier = identifier;
            Cep = new Cep(cep);
            Address = address;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
        }

        public DeliveryAddress(Cep cep, string address, string neighborhood, string city, string state)
        {
            Cep = cep;
            Address = address;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Identifier { get; private set; } = string.Empty;
        public Cep Cep { get; private set; }
        public string Address { get; private set; }
        public long Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; } 
        public string Complement { get; private set; } = string.Empty; 
        public string Reference { get; private set; } = string.Empty;

        public AddressDetailResponse GetAddressDetail()
        {
            return new AddressDetailResponse(Cep.Value, Address, Neighborhood, City, State);
        }

    }
}
