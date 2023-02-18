using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Responses
{
    public class AddressDetailResponse
    {
        public AddressDetailResponse(string cep, string address, string neighborhood, string city, string state)
        {
            Cep = cep;
            Address = address;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public string Cep { get; }
        public string Address { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }

    }
}
